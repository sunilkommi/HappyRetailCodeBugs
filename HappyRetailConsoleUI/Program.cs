﻿using System;
using System.Runtime.InteropServices;
using HappyRetailEntity;
using HappyRetailBusinessAccessLayer;
using HappyRetailConsoleUI.LoginModule;
namespace HappyRetailConsoleUI
{
    class Program
    {

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        //entry point to start Console UI 
        static void Main(string[] args)
        {

            DisableConsoleResize();
            LoginMenu lm = new LoginMenu();
            lm.Login();


        }
        //disble resizing of console window
        static void DisableConsoleResize()
        {
         const int MF_BYCOMMAND = 0x00000000;
        const int SC_CLOSE = 0xF060;
        const int SC_MINIMIZE = 0xF020;
        const int SC_MAXIMIZE = 0xF030;
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
       
        }

    }
}
    
