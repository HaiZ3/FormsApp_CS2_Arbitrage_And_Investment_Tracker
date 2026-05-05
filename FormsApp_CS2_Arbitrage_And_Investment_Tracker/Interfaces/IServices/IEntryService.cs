using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices
{
    public interface IEntryService
    {
        public Task<ServiceResult> AddEntry(int sheetId, string entryName, int quantity
            , DateTime dateBought, DateTime? dateSold, decimal buyPrice, decimal? sellPrice, decimal? itemFloat
            , SkinCondition? skinCondition, SkinVariant skinVariant);
        public Task<ServiceResultGeneric<ICollection<Entry>>> GetEntriesBySheet(int sheetId);
        public Task<ServiceResult> CloseEntry(int entryId, DateTime dateSold, decimal sellPrice);
        public Task<ServiceResult> CancelEntry(int entryId);
        public Task<ServiceResultGeneric<int[]>> ImportFromCsvToSheet(int sheetId);
    }
}