using System;
using System.Collections.Generic;
using System.Text;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Helpers;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker_Test.Helpers
{
    public class Cs2MarketHashNameHelper_Tests
    {
        [Fact]
        public void StickerMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("Great Wave",null,SkinVariant.Normal,null);

            //Item type for stickers is set manually in the gui
            skinInfo.ItemType = ItemType.Sticker;

            string marketHashName = Cs2MarketHashNameHelper.BuildMarketHashName(skinInfo);

            Assert.Equal("Sticker | Great Wave",marketHashName);
        }
        [Fact]
        public void PatchMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("BIG (Gold) | Stockholm 2021", null, SkinVariant.Normal, null);

            //Item type for patches is set manually in the gui
            skinInfo.ItemType = ItemType.Patch;

            string marketHashName = Cs2MarketHashNameHelper.BuildMarketHashName(skinInfo);

            Assert.Equal("Patch | BIG (Gold) | Stockholm 2021", marketHashName);
        }
        [Fact]
        public void CharmMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("Die-cast AK", null, SkinVariant.Normal, null);

            //Item type for charms is set manually in the gui
            skinInfo.ItemType = ItemType.Charm;

            string marketHashName = Cs2MarketHashNameHelper.BuildMarketHashName(skinInfo);

            Assert.Equal("Charm | Die-cast AK", marketHashName);
        }
        [Fact]
        public void MusicKitMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("Killer Mike, MICHAEL",null,SkinVariant.Normal,null);

            //Item type for music kits is set manually in the gui
            skinInfo.ItemType = ItemType.MusicKit;

            string marketHashName = Cs2MarketHashNameHelper.BuildMarketHashName(skinInfo);

            Assert.Equal("Music Kit | Killer Mike, MICHAEL", marketHashName);
        }
        [Fact]
        public void StatTrakMusicKitMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("Killer Mike, MICHAEL", null, SkinVariant.StatTrak, null);

            //Item type for music kits is set manually in the gui
            skinInfo.ItemType = ItemType.MusicKit;

            string marketHashName = Cs2MarketHashNameHelper.BuildMarketHashName(skinInfo);

            Assert.Equal("StatTrak™ Music Kit | Killer Mike, MICHAEL", marketHashName);
        }
        [Fact]
        public void FactoryNewItemMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("AK-47 | Slate", null, SkinVariant.Normal, SkinCondition.Factory_New);

            skinInfo.SetMarketHashName();

            Assert.Equal("AK-47 | Slate (Factory New)", skinInfo.MarketHashName);
        }
        [Fact]
        public void MinimalWearItemMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("AK-47 | Slate", null, SkinVariant.Normal, SkinCondition.Minimal_Wear);

            skinInfo.SetMarketHashName();

            Assert.Equal("AK-47 | Slate (Minimal Wear)", skinInfo.MarketHashName);
        }
        [Fact]
        public void FieldTestedItemMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("AK-47 | Slate", null, SkinVariant.Normal, SkinCondition.Field_Tested);

            skinInfo.SetMarketHashName();

            Assert.Equal("AK-47 | Slate (Field-Tested)", skinInfo.MarketHashName);
        }
        [Fact]
        public void WellWornItemMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("AK-47 | Slate", null, SkinVariant.Normal, SkinCondition.Well_Worn);

            skinInfo.SetMarketHashName();

            Assert.Equal("AK-47 | Slate (Well-Worn)", skinInfo.MarketHashName);
        }
        [Fact]
        public void BattleScarredItemMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("AK-47 | Slate", null, SkinVariant.Normal, SkinCondition.Battle_Scarred);

            skinInfo.SetMarketHashName();

            Assert.Equal("AK-47 | Slate (Battle-Scarred)", skinInfo.MarketHashName);
        }
        [Fact]
        public void VanillaMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("★ Bayonet", null, SkinVariant.Normal, SkinCondition.Vanilla);

            skinInfo.SetMarketHashName();

            Assert.Equal("★ Bayonet", skinInfo.MarketHashName);
        }
        [Fact]
        public void GlovesMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("★ Sport Gloves | Ultra Violent", null, SkinVariant.Normal, SkinCondition.Factory_New);

            skinInfo.SetMarketHashName();

            Assert.Equal("★ Sport Gloves | Ultra Violent (Factory New)", skinInfo.MarketHashName);
        }
        [Fact]
        public void KnifeMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("★ M9 Bayonet | Doppler", null, SkinVariant.Normal, SkinCondition.Factory_New);

            skinInfo.SetMarketHashName();

            Assert.Equal("★ M9 Bayonet | Doppler (Factory New)", skinInfo.MarketHashName);
        }
        [Fact]
        public void StatTrakKnifeMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("★ M9 Bayonet | Doppler", null, SkinVariant.StatTrak, SkinCondition.Factory_New);

            skinInfo.SetMarketHashName();

            Assert.Equal("★ StatTrak™ M9 Bayonet | Doppler (Factory New)", skinInfo.MarketHashName);
        }

        [Fact]
        public void StatTrakItemMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("Five-SeveN | Hyper Beast", null, SkinVariant.StatTrak, SkinCondition.Field_Tested);

            skinInfo.SetMarketHashName();

            Assert.Equal("StatTrak™ Five-SeveN | Hyper Beast (Field-Tested)", skinInfo.MarketHashName);
        }
        [Fact]
        public void SouvenirItemMarketHashNameBuildTest()
        {
            SkinInfo skinInfo = new SkinInfo("AWP | Desert Hydra", null, SkinVariant.Souvenir, SkinCondition.Field_Tested);

            skinInfo.SetMarketHashName();

            Assert.Equal("Souvenir AWP | Desert Hydra (Field-Tested)", skinInfo.MarketHashName);
        }


    }
}
