﻿using Moving_Out.Logic;
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
using System.Windows.Threading;

namespace Moving_Out
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MoveLogic logic;
        
        private void Dt_Tick(object sender, EventArgs e)
        {
            logic.TimeStep();
        }
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer dt = new DispatcherTimer();

            dt.Tick += Dt_Tick;
            dt.Interval = TimeSpan.FromMilliseconds(20);
            dt.Start();
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                logic.Left = false;
            }
            else if (e.Key == Key.Right)
            {
                logic.Right = false;
            }
            else if (e.Key == Key.Up)
            {
                logic.Up = false;
            }
            else if (e.Key == Key.Down)
            {
                logic.Down = false;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                logic.Left = true;
            }
            else if (e.Key == Key.Right)
            {
                logic.Right = true;
            }
            else if (e.Key == Key.Up)
            {
                logic.Up = true;
            }
            else if (e.Key == Key.Down)
            {
                logic.Down = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logic = new MoveLogic();
            display.SetupModel(logic);
            display.SetupSizes(new Size(canvas.ActualWidth, canvas.ActualHeight));
            logic.SetupSizes(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight));
            logic.SetupItems();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.SetupSizes(new Size(canvas.ActualWidth, canvas.ActualHeight));
            //if (logic != null)
            //{
            //    logic.ChangeSize(new Size(canvas.ActualWidth, canvas.ActualHeight));
            //}
        }
    }
}
