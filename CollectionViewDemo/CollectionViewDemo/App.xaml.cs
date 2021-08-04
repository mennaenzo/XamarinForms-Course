﻿using CollectionViewDemo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionViewDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PeoplePage();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}