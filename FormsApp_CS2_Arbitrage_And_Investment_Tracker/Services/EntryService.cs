using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Helpers;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Responses;
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
            , DateTime dateBought, DateTime? dateSold, decimal buyPrice, decimal? sellPrice, decimal? itemFloat
            , SkinCondition? skinCondition, SkinVariant skinVariant)
        {
            SkinInfo skinInfo = new SkinInfo(entryName, itemFloat, skinVariant
                , skinCondition);

            skinInfo.SetItemType();
            skinInfo.SetMarketHashName();

            Entry entry = new Entry(quantity, dateBought, dateSold, buyPrice, sellPrice, sheetId, skinInfo);
            entry.DataSource = EntryDataSource.Regular;

            _context.Add(entry);
            await _context.SaveChangesAsync();

            return ServiceResult.Ok();
        }
        public async Task<ServiceResultGeneric<ICollection<Entry>>> GetEntriesBySheet(int sheetId)
        {
            ICollection<Entry>? entries = _context.Entries.Where(e => e.SheetId == sheetId).ToArray();
            if (entries == null || entries.Count == 0)
            {
                return ServiceResultGeneric<ICollection<Entry>>.Fail("No entries found for this sheet.");
            }
            else
            {
                return ServiceResultGeneric<ICollection<Entry>>.Ok(entries);
            }
        }
        public async Task<ServiceResult> CloseEntry(int entryId, DateTime dateSold, decimal sellPrice)
        {
            Entry? entry = _context.Entries.FirstOrDefault(e => e.Id == entryId);
            if (entry == null)
            {
                return ServiceResult.Fail("Entry not found.");
            }
            else
            {
                entry.DateSold = dateSold;
                entry.SellPrice = sellPrice;
                entry.Status = EntryStatus.Closed;
                _context.Update(entry);
                await _context.SaveChangesAsync();
                return ServiceResult.Ok();
            }
        }
        public async Task<ServiceResult> CancelEntry(int entryId)
        {
            Entry? entry = _context.Entries.FirstOrDefault(e => e.Id == entryId);
            if (entry == null)
            {
                return ServiceResult.Fail("Entry not found.");
            }
            else
            {
                entry.Status = EntryStatus.Cancelled;
                _context.Update(entry);
                await _context.SaveChangesAsync();
                return ServiceResult.Ok();
            }
        }

        }
}
