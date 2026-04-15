using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes
{
    [Table("Entries")]
    [Index(nameof(Status))]
    [Index(nameof(DateSold))]
    [Index(nameof(DateBought))]
    [Index(nameof(SheetId))]
    [Index(nameof(Status), nameof(DateSold))]
    public class Entry
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        public int Quantity { get; set; } = 1;
        public EntryStatus Status { get; set; }

        public EntryDataSource DataSource { get; set; }

        public DateTime? DateBought { get; set; }
        public DateTime? DateSold { get; set; }
        public DateTime CreatedAt { get; set; }

        //After the sale is confirmed add the hold days to OverallStats

        public decimal BuyPrice { get; set; }
        public decimal? SellPrice { get; set; }


        public int SheetId { get; set; }
        public Sheet Sheet { get; set; }
        public int SkinInfoId { get; set; }
        public SkinInfo SkinInfo { get; set; }
    }
}