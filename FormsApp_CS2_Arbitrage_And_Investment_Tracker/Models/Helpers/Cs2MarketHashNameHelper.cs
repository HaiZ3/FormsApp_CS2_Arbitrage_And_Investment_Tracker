using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Helpers
{
    public static class Cs2MarketHashNameHelper
    {
        public static string GetMarketHashName(SkinInfo skinInfo)
        {
            string marketHashName = string.Empty;
            if(skinInfo.ItemType == ItemType.MusicKit) 
            {
                if(skinInfo.SkinVariant == SkinVariant.Normal)
                {
                    marketHashName = skinInfo.Name.Trim();
                }
                else
                {
                    marketHashName = $"StatTrak™ {skinInfo.Name.Trim()}";
                }
                return marketHashName;
            }
            string skinVariant = string.Empty;
            switch (skinInfo.SkinCondition)
            {
                case SkinCondition.Factory_New:
                    skinVariant = "Factory New";
                    break;
                case SkinCondition.Minimal_Wear:
                    skinVariant = "Minimal Wear";
                    break;
                case SkinCondition.Field_Tested:
                    skinVariant = "Field-Tested";
                    break;
                case SkinCondition.Well_Worn:
                    skinVariant = "Well-Worn";
                    break;
                case SkinCondition.Battle_Scarred:
                    skinVariant = "Battle-Scarred";
                    break;
                case SkinCondition.Vanilla:
                    marketHashName = skinInfo.Name;
                    return marketHashName;
                    break;
                case null:
                    marketHashName = skinInfo.Name;
                    return marketHashName;
                    break;
                default:
                    return skinInfo.Name;
                    break;
            }
            if (skinInfo.Name.StartsWith("★"))
            {
                if(skinInfo.SkinVariant == SkinVariant.Normal)
                {
                    marketHashName = $"{skinInfo.Name.Trim()} ({skinVariant})";
                }
                else
                {
                    string temp = skinInfo.Name.Remove(0,1).Trim();
                    marketHashName = $"★ {skinInfo.SkinVariant}™ {temp.Trim()} ({skinVariant})";
                }
            }
            else
            {
                if(skinInfo.SkinVariant == SkinVariant.Normal)
                {
                    marketHashName = $"{skinInfo.Name.Trim()} ({skinVariant})";
                }
                else if(skinInfo.SkinVariant == SkinVariant.StatTrak)
                {
                    marketHashName = $"StatTrak™ {skinInfo.Name.Trim()} ({skinVariant})";
                }
                else if(skinInfo.SkinVariant == SkinVariant.Souvenir)
                {
                    marketHashName = $"Souvenir {skinInfo.Name.Trim()} ({skinVariant})";
                }
            }
            return marketHashName;
        }
    }
}
