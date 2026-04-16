using BCrypt.Net;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Services
{
    public class UserService : IUserService
    {
        CS2TrackerContext context;
        public UserService(CS2TrackerContext context)
        {
            this.context = context;
        }
        public async Task<ServiceResult> CreateUser(string username,string email ,string password)
        {
            //check if a user with the same username exists
            if(await context.Users.AnyAsync(u => u.Username == username))
            {
                return ServiceResult.Fail("The username already exists");
            }   
            //hash the password with BCrypt
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, 12);

            //add the user to the database
            User user = new User(username,email,passwordHash);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return ServiceResult.Ok();
        }
        public async Task<ServiceResult> LoginUser(string username,string password)
        {
            //get the user
            User? user = await context.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user is null)
            {
                return ServiceResult.Fail("Such a user does not exist!");
            }
            //get the hashed password and verify it
            string hashedPassword = user.PasswordHash;
            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            if(!isPasswordCorrect)
            {
                return ServiceResult.Fail("Incorrect password!");
            }
            return ServiceResult.Ok();
        }
    }
}
