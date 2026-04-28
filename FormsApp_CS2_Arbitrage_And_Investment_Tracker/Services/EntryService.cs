using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Services
{
    public class EntryService : IEntryService
    {
        private CS2TrackerContext _context;
        public EntryService(CS2TrackerContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult> AddEntry(int sheetId, string entryName, int quantity
            , DateTime dateBought, DateTime? dateSold, decimal buyPrice,decimal? sellPrice, decimal? itemFloat
            , SkinCondition? skinCondition, SkinVariant skinVariant)
        {
            SkinInfo skinInfo = new SkinInfo(entryName,itemFloat,skinVariant
                ,skinCondition);
            skinInfo.GetItemType();

            Entry entry = new Entry(quantity,dateBought,dateSold,buyPrice,sellPrice,sheetId,skinInfo);
            entry.DataSource = EntryDataSource.Regular;

            _context.Add(entry);
            _context.SaveChanges();

            return ServiceResult.Ok();
        }
    }
}
