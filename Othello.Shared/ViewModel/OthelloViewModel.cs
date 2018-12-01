using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Othello.Shared.ViewModel
{
    public class OthelloViewModel : INotifyPropertyChanged, ICommand
    {
        public OthelloViewModel()
        {

            BlackCount = 0;
            WhiteCount = 0;
            CreateBoard();
            OnPropertyChanged(nameof(MoveList));
        }


        private int whiteCount;
        private int blackCount;
        public int WhiteCount
        {
            get { return whiteCount; }
            set { SetField(ref whiteCount, value); }
        }
        public int BlackCount
        {
            get { return blackCount; }
            set { SetField(ref blackCount, value); }
        }

        private SquareCommand squareClick;
        public SquareCommand SquareClick => squareClick ?? (squareClick = new SquareCommand(board));
            

        
        private ObservableCollection<Move> moveList;
        private Square[] board;
        public Square[] Board => board;

        public ObservableCollection<Move> MoveList
        {
            get { return moveList; }
            set { SetField(ref moveList, value); }
        }
           
        // Initialize the 64 squares so the center 4 are alternating white and black
        public void CreateBoard()
        {
            moveList = new ObservableCollection<Move>();
            board = new Square[64];
            for (int i = 0; i<64; i++)
            {
                board[i] = new Square();
            }

            board[27].SquareValue = board[36].SquareValue = -1;
            board[28].SquareValue = board[35].SquareValue = 1;
            Move turn = new Move(1,"White", "D4");
            MoveList.Add(turn);
            turn = new Move(2,"Black", "E4");
            MoveList.Add(turn);
            turn = new Move(3,"White", "E5");
            MoveList.Add(turn);
            turn = new Move(4,"White", "D5");
            MoveList.Add(turn);
            WhiteCount = 2;
            BlackCount = 2;
        }


        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

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

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
