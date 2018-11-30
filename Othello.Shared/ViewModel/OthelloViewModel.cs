using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;

namespace Othello.Shared.ViewModel
{
    public class OthelloViewModel : INotifyPropertyChanged
    {
        public OthelloViewModel()
        {
            moveList = new ObservableCollection<Move>();
            CreateBoard();
            
        }
        
        private ObservableCollection<Move> moveList;
        
        public ObservableCollection<Move> MoveList
        {
            get { return moveList; }
            set { SetField(ref moveList, value); }
        }
           




        
        // Initialize the 64 squares so the center 4 are alternating white and black
        public void CreateBoard()
        {
            Square[] board = new Square[64];
            for (int i = 0; i<64; i++)
            {
                board[i] = new Square();
            }

            board[27].SquareValue = board[36].SquareValue = 1;
            board[28].SquareValue = board[35].SquareValue = -1;
            Move turn = new Move("White", "D4");
            MoveList.Add(turn);
            turn = new Move("Black", "E4");
            MoveList.Add(turn);
            turn = new Move("White", "E5");
            MoveList.Add(turn);
            turn = new Move("White", "D5");
            MoveList.Add(turn);
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
