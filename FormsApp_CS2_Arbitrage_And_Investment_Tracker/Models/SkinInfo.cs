using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes
{
    [Table("SkinInfos")]
    public class SkinInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MarketHashName { get; set; } = string.Empty;
        public float? ItemFloat { get; set; }
        public ItemType ItemType { get; set; }
        public SkinCondition SkinCondition { get; set; }
        public SkinVariant SkinVariant { get; set; }
        public int EntryId { get; set; }
        public Entry Entry { get; set; }
    }
}
