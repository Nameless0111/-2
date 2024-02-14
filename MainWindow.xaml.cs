
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private Random random;
        private string you;
        private string robot;
        private bool gameOver;
        private int queue = 0;
        public MainWindow()
        {

            InitializeComponent();
            NewGame();
        }


        private void NewGame()
        {
            queue++;
            gameOver = false;
            Button0.Content = " ";
            Button1.Content = " ";
            Button2.Content = " ";
            Button3.Content = " ";
            Button4.Content = " ";
            Button5.Content = " ";
            Button6.Content = " ";
            Button7.Content = " ";
            Button8.Content = " ";
            random = new Random();

          
            
            if (queue % 2 == 1)
            {
                you = "X";
                robot = "O";
            }
            else
            {
                you = "O";
                robot = "X";
            }
            EnableButtons();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (gameOver)
            {
                return;
            }

            Button button = (Button)sender;

            
            if (button.Content != " ")
            {
                return;
            }

            
            button.Content = you;
            button.IsEnabled = false;
            
            var winner = CheckWinner();
            if (winner != null)
            {
                Win(winner);
                
                return;
            }



            



            if (!HasEmptyCells())
            {
                
                MessageBox.Show("Ничья");
                DisableButtons();
                gameOver = true;
                NewGame();

            }
            Roboto();
            var winner1 = CheckWinner();
            if (winner1 != null)
            {
                Win(robot);
                
                return;
            }
            if (!HasEmptyCells())
            {

                MessageBox.Show("Ничья");
                DisableButtons();
                gameOver = true;
                NewGame();

            }
        }
        private void Roboto()
        {
            if (!gameOver)
            {

                Button[] buttons = { Button0, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8 };
                

                if (HasEmptyCells())
                {
                    int ran;
                    while (true) {
                        try
                        {
                             ran = random.Next(1,10);
                            if (buttons[ran - 1].IsEnabled == false)
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }catch (Exception e) { continue; }
                        }
                    buttons[ran - 1].Content = robot;
                    buttons[ran - 1].IsEnabled = false;
                }
            }
        }
        private void EnableButtons()
        {
            Button[] buttons = { Button0, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8 };
            foreach (Button button in buttons)
            {
                button.IsEnabled = true;
            }
        }
        private void DisableButtons()
        {
            Button[] buttons = { Button0, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8 };
            foreach (Button button in buttons)
            {
                button.IsEnabled = false;
            }
        }
        private string CheckWinner()
        {
            Button[] buttons = { Button0, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8 };

            
            for (int i = 0; i < 9; i += 3)
            {
                if (buttons[i].Content != " " && buttons[i].Content == buttons[i + 1].Content && buttons[i + 1].Content == buttons[i + 2].Content)
                {
                    return buttons[i].Content.ToString();
                }
            }

            
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i].Content != " " && buttons[i].Content == buttons[3 + i].Content && buttons[i + 3].Content == buttons[i + 6].Content)
                {
                    return buttons[i].Content.ToString();
                }
            }

            if (buttons[0].Content != " " && buttons[0].Content == buttons[4].Content && buttons[4].Content == buttons[8].Content)
            {
                return buttons[0].Content.ToString();
            }

            if (buttons[2].Content != " " && buttons[2].Content == buttons[4].Content && buttons[4].Content == buttons[6].Content)
            {
                return buttons[2].Content.ToString();
            }

           
            return null;
        }
        private void Win(string player)
        {
            MessageBox.Show("Победитель: " + player);
            
            DisableButtons();
            gameOver = true;
            NewGame();
        }
        private bool HasEmptyCells()
        {
            Button[] buttons = { Button0, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8 };

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Content.ToString() == " ")
                {
                    return true;
                }

            }


            return false;
        }

       
    }
}