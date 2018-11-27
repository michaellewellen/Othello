using System;
using System.Collections.Generic;
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
            CreateOthelloButtons();
            InitializeBoard();
        }





        // Programatically create the 64 buttons for the Othello Board
        public void CreateOthelloButtons()
        {
            for(int i = 5; i <13; i++)
            {
                for(int j=2; j< 10; j++)
                {
                    //Button gameButton = new Button();
                    //gameButton.Content = (i - 5).ToString() + " " + (j - 2).ToString();
                    //gameButton.Name = "Button" + (i - 5).ToString() + (j - 2).ToString();
                    //Grid.SetColumn(gameButton, j);
                    //Grid.SetRow(gameButton, i);
                    //GameGrid.Children.Add(gameButton);
                    
                }
            }

        }
        
        // Initialize the 64 squares so the center 4 are alternating white and black
        public void InitializeBoard()
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
