using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Othello.Shared
{
    public class SquareCommand : ICommand
    {
        public delegate void ICommandOnExecute(object parameter);
        public delegate bool ICommandOnCanExecute(object parameter);

        private ICommandOnExecute _execute;
        private ICommandOnCanExecute _canExecute;

        public Square[] Board { get; }

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
            throw new NotImplementedException();
        }

        public int findIndex(string coord)
        {
            int value1;
            int value2;
            value1 = Convert.ToInt32(coord[0]);
            value2 = Convert.ToInt32(coord[1]);
            // ascii 65 = A, thus A =0, B=1....
            value1 -= 65;
            // ascii 48 = 0, thus '0' = 0.... 
            value2 -= 48;
            return value1 * 8 + value2;
        }
    }
}
