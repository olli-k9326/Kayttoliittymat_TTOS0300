﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; // säikeet
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

namespace WPFThreadDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            InitializeMyStuff();
        }
        #region METHODS
        void InitializeMyStuff()
        {
            btnFire.IsEnabled = false;
        }
        void DoWork()
        {
            // käynnistetään pitkäkestoinen tapahtuma
            Thread.Sleep(5000);
            UpdateMessageAsync("The work is done and answer comes now!");
        }
        void UpdateMessage( string msg)
        {
            txtMessage.Text = msg;
        }

        void UpdateMessageAsync(string msg)
        {
            Action action = () =>
            {
                txtMessage.Text = msg;
                //btnFire.IsEnabled = false;
            };
            // suorittaa annetun delegaatin asynkronisesti siinä säikeessä mihin Dispatcher liittyy
            Dispatcher.BeginInvoke(action);
        }
        #endregion

        #region EVENTHANDLERS
        
        private void btnFire_Click(object sender, RoutedEventArgs e)
        {
            count++;
            UpdateMessage("Fire #" + count.ToString());
        }

        private void btnWork_Click(object sender, RoutedEventArgs e)
        {
            btnFire.IsEnabled = true;
            //V1: normaalisti tämä toimisi mutta nyt metordin pitkän keston takia ei kerkiä päiväittyiä
            // UpdateMessage("A looooong work started");
            // V2: säikeeseen
            UpdateMessageAsync("A Looooong work started!");
            new Thread(DoWork).Start();
        }
        #endregion
    }
}
