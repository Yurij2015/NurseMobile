﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NurseMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AuthPage();
            //MainPage = new DiagnosticPage();
            //MainPage = new MenuPage();
            MainPage = new СonsultationPage();

            //MainPage = new NavigationPage(new NursesList());

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
