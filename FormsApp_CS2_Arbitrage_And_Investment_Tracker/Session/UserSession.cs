using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Session
{
    public static class UserSession
    {
        public static int UserId { get; private set; }
        public static string Username { get; private set; } = string.Empty;
        public static User? User { get; private set; }
        public static bool IsLoggedIn => UserId != 0;

        public static void Login(int userId, string username)
        {
            UserId = userId;
            Username = username;
        }

        public static void Logout()
        {
            UserId = 0;
            Username = string.Empty;
        }
    }
}
