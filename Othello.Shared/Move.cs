using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Othello.Shared.ViewModel
{
    public class Move : INotifyPropertyChanged
    {
        public Move() { }
        public Move(int moveCount, string playerColor, string playerMove)
        {
            MoveCount = moveCount;
            PlayerColor = playerColor;
            PlayerMove = playerMove;
        }

        private int moveCount;
        public int MoveCount
        {
            get { return moveCount; }
            set { SetField(ref moveCount, value); }
        }

        private string playerColor;
        public string PlayerColor
        {
            get { return playerColor; }
            set { SetField(ref playerColor,value); }
        }

        private string playerMove;
        public string PlayerMove
        {
            get { return playerMove; }
            set { SetField(ref playerMove, value); }
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