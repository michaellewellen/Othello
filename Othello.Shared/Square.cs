using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Othello.Shared
{
    public class Square : INotifyPropertyChanged
    {
        public Square()
        {
            squareValue = 0;
            squareImage = new BitmapImage(new Uri(@"Resources\empty.png", UriKind.Relative));
            squareColor = "#00AB66";
            isClickable = false;
        }

        private int squareValue;
        private string squareColor;
        private BitmapImage squareImage;
        private bool isClickable;

        public int SquareValue
        {
            get { return squareValue; }
            set {
                // any time the value changes, the image needs to be updated.
                OnPropertyChanged(nameof(SquareImage));
                SetField(ref squareValue, value); }
        }

        public string SquareColor
        {
            get { return squareColor; }
            set { SetField(ref squareColor, value); }
        }

        // SquareImage changes based on the numerical value of the square.
        public BitmapImage SquareImage
        {
            get { return squareImage; }
            set
            {
                if (SquareValue == -1)
                { SquareImage = new BitmapImage(new Uri(@"Resources\blackpip.png", UriKind.Relative)); }

                else if (SquareValue == 1)
                { SquareImage = new BitmapImage(new Uri(@"Resources\whitepip.png", UriKind.Relative)); }

                else
                { SquareImage = new BitmapImage(new Uri(@"Resources\empty.png", UriKind.Relative)); }
            }
        }

        public bool IsClickable
        {
            get { return isClickable; }
            set { SetField(ref isClickable, value); }     
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
