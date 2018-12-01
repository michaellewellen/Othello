using System;
using Othello.Shared;
using Moq;
using NUnit.Framework;
using System.Windows.Media.Imaging;
using Othello.Shared.ViewModel;

namespace OthelloTests
{
   
    public class UnitTest1
    {

        // Testing functionality of 'Square'
        [Test]
        public void TestValuetoBlackPip()
        {
            Square testSquare = new Square();
            testSquare.SquareValue = -1;
            Assert.AreEqual (testSquare.SquareColor, "#00AB66");
        }

        [Test]
        public void TestValuetoWhitePip()
        {
            Square testSquare = new Square();
            testSquare.SquareValue = 1;
            Assert.AreEqual(testSquare.SquareColor, "#00AB66");
        }

        [Test]
        public void TestIsClickableInitiation()
        {
            Square testSquare = new Square();
            Assert.AreEqual(testSquare.IsClickable, false);
        }

        // test for view model 
        [Test]
        public void TestOpeningMoves()
        {
            var vm = new OthelloViewModel();
            Assert.AreEqual(vm.Board[25].SquareValue, 0);
            Assert.AreEqual(vm.Board[5].SquareValue, 0);
        }

        [Test]
        public void TestBlackWhitecount()
        {
            var vm = new OthelloViewModel();
            Assert.AreEqual(vm.BlackCount, 2);
            Assert.AreEqual(vm.WhiteCount, 2);
        }

        [Test]
        public void TestMoveList()
        {
            var vm = new OthelloViewModel();
            Move turn = new Move(1, "White", "D4");
            vm.MoveList.Add(turn);
            Assert.AreEqual(vm.MoveList[0].MoveCount, 1);
        }

        [Test]
        public void TotalMoveCount()
        {
            var vm = new OthelloViewModel();
            Assert.AreEqual(vm.MoveList.Count, 4);
        }

        // Test the SquareCommand
        [Test]
        public void TestParser()
        {
            var vm = new OthelloViewModel();
            int index = vm.SquareClick.findIndex("A1");
            Assert.AreEqual(index, 0);
        }
        [Test]
        public void TestParser2()
        {
            var vm = new OthelloViewModel();
            int index = vm.SquareClick.findIndex("H8");
            Assert.AreEqual(index, 63);
        }

        [Test]
        public void TestIsClickable()
        {
            var vm = new OthelloViewModel();
            bool valid = vm.SquareClick.CanExecute("E5");
            Assert.AreEqual(valid, false);
        }
    }
}
