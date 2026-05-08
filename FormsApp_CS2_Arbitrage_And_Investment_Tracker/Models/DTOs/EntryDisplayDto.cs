using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.DTOs
{
    public class EntryDisplayDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? Profit { get; set; }
        public decimal? Return { get; set; }
        public DateTime? DateBought { get; set; }
        public DateTime? DateSold { get; set; }
        public EntryStatus Status { get; set; }
    }
}
