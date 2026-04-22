using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices
{
    public interface IEntryService
    {
        public Task<ServiceResult> AddEntry(int sheetId,string entryName,int quantity
            ,DateTime dateBought,DateTime dateSold,decimal buyPrice,float? itemFloat
            ,SkinCondition skinCondition,SkinVariant skinVariant);
    }
}