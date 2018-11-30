using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Othello.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            var vm = new Othello.Shared.ViewModel.OthelloViewModel();
            vm.CreateBoard();
        }

        private void QuitGame(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void DisplayStats(object sender, RoutedEventArgs e)
        {
           
        }
        private void Undo(object sender, RoutedEventArgs e)
        {
            
        }
        private void Redo(object sender, RoutedEventArgs e)
        {
          
        }
        private void About(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
