using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Helpers
{
    public static class Cs2ItemTypeHelper
    {
        public static ItemType GetItemType(string weapon)
        {
            return weapon switch
            {
                "Glock-18" or "USP-S" or "P2000" or "P250" or "Five-SeveN" or "Tec-9" or "CZ75-Auto" or "Desert Eagle" or "R8 Revolver"
                    => ItemType.Pistol,

                "AK-47" or "M4A4" or "M4A1-S" or "FAMAS" or "Galil AR" or "AUG" or "SG 553"
                    => ItemType.Rifle,

                "AWP" or "SSG 08" or "SCAR-20" or "G3SG1"
                    => ItemType.SniperRifle,

                "MP9" or "MAC-10" or "MP7" or "MP5-SD" or "UMP-45" or "P90" or "PP-Bizon"
                    => ItemType.SMG,

                "Nova" or "XM1014" or "MAG-7" or "Sawed-Off"
                    => ItemType.Shotgun,

                string name when name.Contains("Capsule")
                    => ItemType.Capsule,

                "M249" or "Negev"
                    => ItemType.MachineGun,

                "★ Karambit" or "★ Butterfly Knife" or "★ M9 Bayonet" or "★ Bayonet"
                    or "★ Flip Knife" or "★ Gut Knife" or "★ Falchion Knife" or "★ Shadow Daggers"
                    or "★ Bowie Knife" or "★ Huntsman Knife" or "★ Navaja Knife" or "★ Stiletto Knife"
                    or "★ Talon Knife" or "★ Ursus Knife" or "★ Classic Knife" or "★ Paracord Knife"
                    or "★ Survival Knife" or "★ Nomad Knife" or "★ Skeleton Knife" or "★ Kukri Knife"
                        => ItemType.Knife,

                "★ Sport Gloves" or "★ Driver Gloves" or "★ Hand Wraps" or "★ Moto Gloves" or "★ Specialist Gloves"
                    or "★ Bloodhound Gloves" or "★ Hydra Gloves" or "★ Broken Fang Gloves"
                        => ItemType.Gloves,

                "Sticker"
                    => ItemType.Sticker,

                "Patch"
                    => ItemType.Patch,

                "Charm"
                    => ItemType.Charm,

                "Music Kit"
                    => ItemType.MusicKit,

                "Graffiti"
                    => ItemType.Graffiti,

                _ => ItemType.Unknown
            };
        }
    }
}
