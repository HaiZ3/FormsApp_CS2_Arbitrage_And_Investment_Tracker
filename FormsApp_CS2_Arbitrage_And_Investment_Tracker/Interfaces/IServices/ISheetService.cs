using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices
{
    public interface ISheetService
    {
        public Task<ServiceResultGeneric<ICollection<Sheet>>> LoadSheets(int sheetId);
        public Task<ServiceResult> CreateSheet(int userId, string name, SheetType sheetType);
    }
}
