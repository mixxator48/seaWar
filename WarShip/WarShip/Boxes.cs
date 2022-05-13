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
    public class Boxes : Button
    {
        public int x;
        public int y;
        public bool isEmpty;
        public bool isShip;
        public bool isFlag;
        public bool isMine;
        public bool wasShoot;

        public Boxes[,] arrayOfBoxes = new Boxes[10, 10];
        
        Random rand = new Random(DateTime.Now.Millisecond);

        public Boxes()
        { }

        public Boxes(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.isEmpty = true;
            this.isShip = false;
            this.isFlag = false;
            this.isMine = false;
            this.wasShoot = false;
        }   

        public void Fire(Boxes[,] myArray)  //main mechanic
        {
            doShot(myArray);
        }
        
        private void doShot(Boxes[,] myArray) //user's move
        {
            if (!this.wasShoot) //check for repeating move
            {
                if (this.isShip)    //hit
                {
                    this.Background = Brushes.DarkRed;
                    placeImg("fire");
                    this.wasShoot = true;
                    //MessageBox.Show("Попал!");
                    MessageBox.Show("Shoot again!");

                    //WRITE CODE
                    //FOR COUNT OF DECK
                    //AND CHECK FOR SHIP'S DEATH

                }
                else    //miss
                {
                    this.Background = Brushes.White;
                    placeImg("miss");
                    this.wasShoot = true;
                    //MessageBox.Show("Мимо!");
                    doEnemyShot(myArray);

                }
            }
        }

        private void doEnemyShot(Boxes[,] myArray)  //ai's move
        {
            int xOfShot = rand.Next(10);
            int yOfShot = rand.Next(10);

            if (!myArray[xOfShot, yOfShot].wasShoot)
            {
                if (myArray[xOfShot, yOfShot].isShip)
                {
                    myArray[xOfShot, yOfShot].Background = Brushes.DarkRed;
                    placeImg("fire", myArray, xOfShot, yOfShot);
                    myArray[xOfShot, yOfShot].wasShoot = true;
                    //MessageBox.Show("Попал!");
                    //MessageBox.Show("Enemy's turn again!");
                    doEnemyShot(myArray);
                }
                else
                {
                    myArray[xOfShot, yOfShot].Background = Brushes.White;
                    placeImg("miss", myArray, xOfShot, yOfShot);
                    myArray[xOfShot, yOfShot].wasShoot = true;
                    //MessageBox.Show("Мимо!");
                }
            }
            else doEnemyShot(myArray);
        }

        private void placeImg(string str)   //set a suitable picter
        {
            Grid gr = new Grid();
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + str + ".png"));
            gr.Children.Add(img);
            this.Content = gr;
        }

        private void placeImg(string str, Boxes[,] array, int x, int y)   //set a suitable picter
        {
            Grid gr = new Grid();
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + str+".png"));
            gr.Children.Add(img);
            array[x,y].Content = gr;
        }
    }
}
