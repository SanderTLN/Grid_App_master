﻿using System;
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
        Label[,] KresNoli = new Label[3, 3];
        string l;
        public KrestikiNoliki()
        {
            Reset();
            stps = 0;
        }
        Label stat, info;
        Button newGame, randomPlayer;

        void Reset()
        {
            Grid grid = new Grid();
            for (int g = 0; g < 3; g++)
            {
                BackgroundColor = Color.LightGray;
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
            for (int f = 0; f < 3; f++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            randomPlayer = new Button
            {
                BackgroundColor = Color.BurlyWood,
                BorderWidth = 2,
                BorderColor = Color.Gray,
                FontSize = 25,
                Text = "Change Course",
                TextColor = Color.White
            };
            randomPlayer.Clicked += randomPlayer_Clicked;
            newGame = new Button
            {
                BackgroundColor = Color.BurlyWood,
                BorderWidth = 2,
                BorderColor = Color.Gray,
                FontSize = 25,
                Text = "New Game",
                TextColor = Color.White
            };
            newGame.Clicked += newGame_Clicked;
            info = new Label
            {
                FontSize = 30,
                TextColor = Color.Gray,
                Text = "",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    stat = new Label
                    {
                        BackgroundColor = Color.Gray,
                        FontSize = 120,
                        Text = "",
                        HorizontalTextAlignment = TextAlignment.Center,
                        TextColor = Color.LightGray,
                        VerticalTextAlignment = TextAlignment.Center,
                    };
                    KresNoli[i, j] = stat;
                    l = "X";
                    var tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    grid.Children.Add(stat, i, j);
                    stat.GestureRecognizers.Add(tap);
                }
            }
            grid.Children.Add(randomPlayer, 0, 3);
            grid.Children.Add(newGame, 2, 3);
            grid.Children.Add(info, 1, 3);
            Content = grid;
        }
        private void newGame_Clicked(object sender, EventArgs e)
        {
            Reset();
            chck = 0;
            stps = 0;
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {
            Label stat = sender as Label;
            if (stat.Text == "")

                if (chck % 2 == 0)
                {
                    info.Text = "Zero Move";
                    stat.Text = l;
                    chck++;
                    stps++;
                }
                else if (chck % 2 != 0)
                {
                    info.Text = "Cross Stroke";
                    chck++;
                    stps++;
                    stat.Text = "0";
                }

            if (checkDraw() == true)
            {
                DisplayAlert("End Of The Game", "Draw", "New Game");
                Reset();
                stps = 0;
            }

            else if (checkWinnerY() == true)
            {
                DisplayAlert("End Of The Game", "Someone Won", "New Game");
                Reset();
            }
            else if (checkWinnerX() == true)
            {
                DisplayAlert("End Of The Game", "Someone Won", "New Game");
                Reset();
            }
        }
        bool checkDraw()
        {
            if (stps == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool checkWinnerX()
        {
            if (KresNoli[0, 0].Text == "X" && KresNoli[1, 0].Text == "X" && KresNoli[2, 0].Text == "X")
            {
                return true; ;
            }
            else if (KresNoli[0, 1].Text == "X" && KresNoli[1, 1].Text == "X" && KresNoli[2, 1].Text == "X")
            {
                return true;
            }
            else if (KresNoli[0, 2].Text == "X" && KresNoli[1, 2].Text == "X" && KresNoli[2, 2].Text == "X")
            {
                return true;
            }
            if (KresNoli[0, 0].Text == "0" && KresNoli[1, 0].Text == "0" && KresNoli[2, 0].Text == "0")
            {
                return true; ;
            }
            else if (KresNoli[0, 1].Text == "0" && KresNoli[1, 1].Text == "0" && KresNoli[2, 1].Text == "0")
            {
                return true;
            }
            else if (KresNoli[0, 2].Text == "0" && KresNoli[1, 2].Text == "0" && KresNoli[2, 2].Text == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool checkWinnerY()
        {
            if (KresNoli[0, 0].Text == "X" && KresNoli[0, 1].Text == "X" && KresNoli[0, 2].Text == "X")
            {
                return true; ;
            }
            else if (KresNoli[1, 1].Text == "X" && KresNoli[1, 1].Text == "X" && KresNoli[1, 2].Text == "X")
            {
                return true;
            }
            else if (KresNoli[2, 0].Text == "X" && KresNoli[2, 1].Text == "X" && KresNoli[2, 2].Text == "X")
            {
                return true;
            }
            if (KresNoli[0, 0].Text == "0" && KresNoli[0, 1].Text == "0" && KresNoli[0, 2].Text == "0")
            {
                return true; ;
            }
            else if (KresNoli[1, 1].Text == "0" && KresNoli[1, 1].Text == "0" && KresNoli[1, 2].Text == "0")
            {
                return true;
            }
            else if (KresNoli[2, 0].Text == "0" && KresNoli[2, 1].Text == "X" && KresNoli[2, 2].Text == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        int stps = 0;

        Random strt = new Random();
        int chck = 0;
        private void randomPlayer_Clicked(object sender, EventArgs e)
        {
            chck = strt.Next(0, 2);
            if (chck % 2 == 0)
            {
                info.Text = "Cross Stroke";
            }
            else if (chck % 2 != 0)
            {
                info.Text = "Zero Move";
            }
        }
    }
}