﻿using ColorMaker.Pages;

namespace ColorMaker;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new ColorMakerPage();
    }
}