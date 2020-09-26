using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Grid_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KrestikiNoliki : ContentPage
    {
        public KrestikiNoliki()
        {
            Reset();
        }
        BoxView box;
        Label stat;
        Button newGame, randomPlayer;
        void Reset()
        {
            Grid grid = new Grid();
            for (int g = 0; g < 4; g++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
            for (int f = 0; f < 3; f++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            randomPlayer = new Button
            {
                Text = "Change X/0"
            };
            randomPlayer.Clicked += RandomPlayer_Clicked;
            newGame = new Button
            {
                Text = "New Game"
            };
            newGame.Clicked += NewGame_Clicked;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    stat = new Label
                    {
                        BackgroundColor = Color.Gray,
                        FontSize = 30,
                        Text = "",
                        TextColor = Color.Black,
                        VerticalTextAlignment = TextAlignment.Center,
                    };
                    var tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    grid.Children.Add(stat, i, j);
                    stat.GestureRecognizers.Add(tap);
                }
            }
            grid.Children.Add(randomPlayer, 0, 3);
            grid.Children.Add(newGame, 3, 3);
            Content = grid;
        }

        private void NewGame_Clicked(object sender, EventArgs e)
        {
            Reset();
        }

        List<Label> lst = new List<Label>() { };
        private void Tap_Tapped(object sender, EventArgs e)

        {
            check();
            Label stat = sender as Label;
            if (chck % 2 == 0)
            {
                stat.Text = "X";
                chck++;
                lst.Add(stat);
            }
            else if (chck % 2 != 0)
            {
                chck++;
                stat.Text = "0";
                lst.Add(stat);
            }
            else if (stp == true)
            {
                DisplayAlert("Alert", "Yes", "Ok");
            }
        }

        string l = "X";
        string h = "0";
        bool stp;
        void check()
        {
            foreach (Label stat in lst)
            {
                if (lst.Contains(stat))
                {
                    stp = true;
                }
                else
                {
                    stp = false;
                }
            }
        }

        Random strt = new Random();
        int chck = 0;
        private void RandomPlayer_Clicked(object sender, EventArgs e)
        {
            chck = strt.Next(0, 2);
        }
    }
}