using BCrypt.Net;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Common;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Services
{
    public class UserService
    {
        CS2TrackerContext context;
        public UserService(CS2TrackerContext context)
        {
            this.context = Common.Common._context;
        }
        public async void CreateUser(string username,string email ,string password)
        {
            //check if a user with the same username exists
            if(await context.Users.AnyAsync(u => u.Username == username))
            {
                MessageBox.Show("The username already exists!");
            }   
            //hash the password with BCrypt
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, 12);

            //add the user to the database
            User user = new User(username,email,passwordHash);
            context.Users.Add(user);
            await context.SaveChangesAsync();
            MessageBox.Show("Succesffull registration");
        }
        public async void LoginUser(string username,string password)
        {
            if (!await context.Users.AnyAsync(u => u.Username == username))
            {
                MessageBox.Show("The user doesn't exist.");
            }
            //get the user
            User user = context.Users.First(x => x.Username == username);
            //get the hashed password and verify it
            string hashedPassword = user.PasswordHash;
            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            if(!isPasswordCorrect)
            {
                MessageBox.Show("Wrong password try again!");
            }
        }
    }
}
