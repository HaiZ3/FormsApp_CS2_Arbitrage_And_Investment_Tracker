using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Responses;
using Microsoft.IdentityModel.Tokens;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Services
{
    public class SheetService : ISheetService
    {
        public CS2TrackerContext _context { get; set; }
        public SheetService(CS2TrackerContext context)
        {
            _context = context;
        }
        public async Task<ServiceResult> CreateSheet(User user, string name, SheetType sheetType)
        {
            Sheet sheet = new Sheet(user, name, sheetType);
            try
            {
                if (name.IsNullOrEmpty())
                {
                    throw new Exception();
                }
                await _context.Sheets.AddAsync(sheet);
                await _context.SaveChangesAsync();
                return ServiceResult.Ok();
            }
            catch (Exception)
            {
                return ServiceResult.Fail("Failed to add the sheet to the database!");
            }
        }
        public Task<ServiceResultGeneric<ICollection<Sheet>>> LoadSheets()
        {
            throw new NotImplementedException();
        }
    }
}
