using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace Othello.Shared
{
    public class SquareCommand : ICommand, INotifyPropertyChanged
    {
        public delegate void ICommandOnExecute(object parameter);
        public delegate bool ICommandOnCanExecute(object parameter);

        private ICommandOnExecute _execute;
        private ICommandOnCanExecute _canExecute;

        private int[] flippingPieces;
        public int[] FlippingPieces
        { get { return flippingPieces; }
          set {SetField(ref flippingPieces, value); }  
        }

        private int playerTurn;
        public int PlayerTurn
        {
            get { return playerTurn; }
            set { SetField(ref playerTurn, value); }
        }



        private Square[] board;
        public Square[] Board
        {   get { return board; }
            set { SetField(ref board, value); }
        }

        public SquareCommand(Square[] board)
        {
            Board = board ?? throw new ArgumentNullException(nameof(board));
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var coordinate = parameter as String;
            int index;
            
            if (coordinate == null)
                return false;
           index = findIndex(coordinate);
           return Board[index].IsClickable;
        }

        public void Execute(object parameter)
        {
            // Execute Players selection
            int playerTurn = -1;
            int computerMove;
            var coordinate = parameter as String;
            int index;
            index = findIndex(coordinate);
            Board[index].SquareValue = playerTurn;
            Thread.Sleep(500);
            flipPieces();
            Thread.Sleep(1000);

            // Execute Computers turn
            playerTurn = 1;
            updateValid(index);
            computerMove = computersTurn();
            Board[computerMove].SquareValue = playerTurn;
            Thread.Sleep(500);
            flipPieces();
            updateValid(index);
        }

        public int findIndex(string coord)
        {
            int value1;
            int value2;
            value1 = Convert.ToInt32(coord[0]);
            value2 = Convert.ToInt32(coord[1]);
            // ascii 65 = A, thus A =0, B=1....
            value1 -= 65;
            // ascii 49 = 1, thus '0' = 0.... 
            value2 -= 49 ;
            return value1 * 8 + value2;
        }

        public void updateValid(int location)
        {
            bool valid = false;
            for (int i = 0; i< 64; i++)
            {
                if (Board[i].SquareValue == 0)
                // check surrounding squares if opposite color
                // up
                if (Board[i - 1].SquareValue != -1*PlayerTurn && ((i-1)%8 != 0))
                {
                    int j = i - 1;
                    while((j+1)%8 !=0)
                    {
                        if (Board[j].SquareValue == PlayerTurn)
                            Board[i].IsClickable = true;
                    }
                }
                
                
            }
        }
         
        public int computersTurn()
        {
            return 0;
        }

        public void flipPieces()
        {

        }

        
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        
        #endregion
    }
}
