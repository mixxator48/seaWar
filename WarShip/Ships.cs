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
using System.Threading;

namespace WarShip
{
    class Ships
    {
        private int countOfDeck;
        private int xOfShip;
        private int yOfShip;

        Random rand = new Random();

        public Boxes enemyArray = new Boxes();
        public Boxes myArray = new Boxes();

        public Ships(int countOfDeck)
        {
            this.countOfDeck = countOfDeck;
        }



        public void generateShips(int countOfDeck, int countOfShips)
        {
            var ship = new Ships(countOfDeck);
            // how to create the position
            generatePosition(countOfDeck,enemyArray);
            generatePosition(countOfDeck, myArray);


            if (countOfShips != 10)
            {
                if (countOfShips == 1 || countOfShips == 3 || countOfShips == 6)
                {
                    generateShips(countOfDeck - 1, countOfShips + 1);
                }
                else generateShips(countOfDeck, countOfShips + 1);
            }
            
        }

        private void generatePosition(int countOfDeck,Boxes array)
        {
            bool BoxIsEmpty = true;

            if (rand.Next(2) == 0)
            {
                this.xOfShip = rand.Next(10);
                this.yOfShip = rand.Next(11-countOfDeck);

                for (int i = yOfShip; i < yOfShip + countOfDeck; i++)
                {
                    if (array.arrayOfBoxes[xOfShip, i].isEmpty == false) BoxIsEmpty = false;
                }

                if (BoxIsEmpty) placeVerticalShip(countOfDeck, xOfShip, yOfShip, array);
                else generatePosition(countOfDeck,array);
            }

            else
            {
                this.xOfShip = rand.Next(11-countOfDeck);
                this.yOfShip = rand.Next(10);

                for (int i = xOfShip; i < xOfShip + countOfDeck; i++)
                {
                    if (array.arrayOfBoxes[i, yOfShip].isEmpty == false) BoxIsEmpty = false;
                }

                if (BoxIsEmpty) placeHorizontalShip(countOfDeck, xOfShip, yOfShip, array);
                else generatePosition(countOfDeck,array);
            }      
        }

        private void placeHorizontalShip(int countOfDeck, int xOfShip, int yOfShip, Boxes array)
        {
            for (int j = yOfShip-1; j < yOfShip+2; j++)
            {
                for (int i = xOfShip-1; i < xOfShip+countOfDeck+1; i++)
                {
                    if (j < 0 || i < 0 || j > 9 || i > 9) continue;

                    if (i>xOfShip-1 && i<xOfShip+countOfDeck && j==yOfShip)
                    {
                        array.arrayOfBoxes[i, j].isShip = true;
                        if (array.arrayOfBoxes[i, j].isMine)
                        {
                            array.arrayOfBoxes[i, j].Background = Brushes.Red;
                            array.arrayOfBoxes[i, j].Content = countOfDeck;
                        }
                        if (!array.arrayOfBoxes[i, j].isMine) //DONT FORGET TO DELETE!!!!
                        {
                            array.arrayOfBoxes[i, j].Background = Brushes.Yellow;
                            array.arrayOfBoxes[i, j].Content = countOfDeck;
                        }
                    }                   

                    array.arrayOfBoxes[i, j].isEmpty = false;
                }
            }
            
        }

        private void placeVerticalShip(int countOfDeck, int xOfShip, int yOfShip, Boxes array)
        {
            for (int j = yOfShip - 1; j < yOfShip + countOfDeck + 1; j++)
            {
                for (int i = xOfShip - 1; i < xOfShip + 2; i++)
                {
                    if (j < 0 || i < 0 || j > 9 || i > 9) continue;

                    if (j > yOfShip - 1 && j < yOfShip + countOfDeck && i == xOfShip)
                    {
                        array.arrayOfBoxes[i, j].isShip = true;
                        if (array.arrayOfBoxes[i, j].isMine)
                        {
                            array.arrayOfBoxes[i, j].Background = Brushes.Red;
                            array.arrayOfBoxes[i, j].Content = countOfDeck;
                        }
                        if (!array.arrayOfBoxes[i, j].isMine)   //DONT FORGET TO DELETE!!!!
                        {
                            array.arrayOfBoxes[i, j].Background = Brushes.Yellow;
                            array.arrayOfBoxes[i, j].Content = countOfDeck;
                        }

                    }

                    array.arrayOfBoxes[i, j].isEmpty = false;
                }
            }

        }
    }
}
