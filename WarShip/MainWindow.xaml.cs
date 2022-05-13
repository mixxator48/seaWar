using System;
using System.Collections.Generic;
using System.Collections;
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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        Ships ship = new Ships(4);

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            fieldOfenemyUniform.Children.Clear();
            myField.Children.Clear();


            for (int i = 0; i < 10; i++) //cycle for generation enemye's field
            {
                for (int j = 0; j < 10; j++)
                {
                    var enemyBox = new Boxes(j, i);
                    fieldOfenemyUniform.Children.Add(enemyBox);
                    enemyBox.Click += Box_Click;
                    enemyBox.MouseRightButtonDown += PlaceFlag;
                    ship.enemyArray.arrayOfBoxes[j, i] = enemyBox;

                    var myBox = new Boxes(j, i);
                    myBox.isMine = true;
                    myField.Children.Add(myBox);
                    myBox.Click -= Box_Click;
                    ship.myArray.arrayOfBoxes[j, i] = myBox;
                }
            }
            
            ship.generateShips(4,1); //start to generate positions of enemy's ships
        }

        private void PlaceFlag(object sender, MouseButtonEventArgs e)
        {
            if (!(sender as Boxes).wasShoot)
            {
                if (!(sender as Boxes).isFlag)
                {
                    (sender as Boxes).Content = "o";
                    (sender as Boxes).FontSize = 20;
                    (sender as Boxes).Click -= Box_Click;
                    (sender as Boxes).isFlag = true;
                }
                else
                {
                    (sender as Boxes).Content = "";
                    (sender as Boxes).Click += Box_Click;
                    (sender as Boxes).isFlag = false;
                }
            } 
        }

        public void Box_Click(object sender, RoutedEventArgs e)
        {
            (sender as Boxes).Fire(ship.myArray.arrayOfBoxes);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var txt = new TextBlock();
            txt.Text = "WarShip";
            txt.FontFamily = new FontFamily("Miramonte Bold");
            txt.FontSize = 60;
            txt.FontStyle = FontStyles.Italic;
            txt.FontWeight = FontWeights.Bold;
            txt.Foreground = Brushes.Orange;
            txt.Margin = new Thickness(100,150,0,0);
            fieldOfenemyUniform.Children.Add(txt);
        }        
    }
}
