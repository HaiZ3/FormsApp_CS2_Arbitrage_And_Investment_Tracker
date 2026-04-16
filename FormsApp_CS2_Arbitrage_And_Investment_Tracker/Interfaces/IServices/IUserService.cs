using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices
{
    public interface IUserService
    {
        Task<ServiceResult> LoginUser(string username, string password);
        Task<ServiceResult> CreateUser(string username, string email, string password);
        
    }
}
