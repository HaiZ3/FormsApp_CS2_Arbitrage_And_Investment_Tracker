using FormsApp_CS2_Arbitrage_And_Investment_Tracker;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Helpers;
namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker_Test.Helpers
{
    public class Cs2ItemTypeHelper_Tests
    {
        [Fact]
        public void GlovesItemTypeAssignedTest()
        {
            string gloves = "★ Sport Gloves | Pandora's Box";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(gloves);

            Assert.Equal(ItemType.Gloves, itemType);
        }
        [Fact]
        public void KnifeItemTypeAssignedTest()
        {
            string knife = "★ Butterfly Knife | Gamma Doppler";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(knife);

            Assert.Equal(ItemType.Knife, itemType);
        }
        [Fact]
        public void CaseItemTypeAssignedTest()
        {
            string @case = "Falchion Case";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(@case);

            Assert.Equal(ItemType.Case, itemType);
        }
        [Fact]
        public void WeaponCaseItemTypeAssignedTest()
        {
            string weaponCase = "CS:GO Weapon Case 3";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(weaponCase);

            Assert.Equal(ItemType.Case, itemType);
        }
        [Fact]
        public void OperationCaseItemTypeAssignedTest()
        {
            string operationCase = "Operation Broken Fang Case";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(operationCase);

            Assert.Equal(ItemType.Case, itemType);
        }
        [Fact]
        public void SouvenirPackageItemTypeAssignedTest()
        {
            string souvenirPackage = "Austin 2025 Anubis Souvenir Package";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(souvenirPackage);

            Assert.Equal(ItemType.SouvenirPackage, itemType);
        }
        [Fact]
        public void CollectionPackageItemTypeAssignedTest()
        {
            string souvenirPackage = "Anubis Collection Package";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(souvenirPackage);

            Assert.Equal(ItemType.CollectionPackage, itemType);
        }
        [Fact]
        public void CapsuleItemTypeAssignedTest()
        {
            string capsule = "Shanghai 2024 Legends Sticker Capsule";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(capsule);

            Assert.Equal(ItemType.Capsule, itemType);
        }
        [Fact]
        public void AuthographCapsuleItemTypeAssignedTest()
        {
            string capsule = "Budapest 2025 Champions Autograph Capsule";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(capsule);

            Assert.Equal(ItemType.Capsule, itemType);
        }
        [Fact]
        public void StickerItemTypeAssignedTest()
        {
            string capsule = "Sticker | Broken Fang (Holo)";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(capsule);

            Assert.Equal(ItemType.Sticker, itemType);
        }
        [Fact]
        public void PatchItemTypeAssignedTest()
        {
            string capsule = "Patch | Aquatic Offensive";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(capsule);

            Assert.Equal(ItemType.Patch, itemType);
        }
        [Fact]
        public void CharmItemTypeAssignedTest()
        {
            string capsule = "Charm | Hot Howl";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(capsule);

            Assert.Equal(ItemType.Charm, itemType);
        }
        [Fact]
        public void SealedGraffitiItemTypeAssignedTest()
        {
            string item = "Sealed Graffiti | Air Drop";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(item);

            Assert.Equal(ItemType.Graffiti, itemType);
        }

        [Fact]
        public void GraffitiItemTypeAssignedTest()
        {
            string item = "Graffiti | Skull";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(item);

            Assert.Equal(ItemType.Graffiti, itemType);
        }

        [Fact]
        public void MusicKitItemTypeAssignedTest()
        {
            string item = "Music Kit | Danger Zone";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(item);

            Assert.Equal(ItemType.MusicKit, itemType);
        }

        [Fact]
        public void AgentItemTypeAssignedTest()
        {
            string item = "Sir Bloody Miyagi | SEAL Frogman";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(item);

            Assert.Equal(ItemType.Agent, itemType);
        }

        [Fact]
        public void PistolItemTypeAssignedTest()
        {
            string item = "Zeus x27 | Charged Up";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(item);

            Assert.Equal(ItemType.Pistol, itemType);
        }

        [Fact]
        public void RifleItemTypeAssignedTest()
        {
            string item = "AK-47 | Redline";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(item);

            Assert.Equal(ItemType.Rifle, itemType);
        }

        [Fact]
        public void SniperRifleItemTypeAssignedTest()
        {
            string item = "AWP | Asiimov";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(item);

            Assert.Equal(ItemType.SniperRifle, itemType);
        }

        [Fact]
        public void SmgItemTypeAssignedTest()
        {
            string item = "MP7 | Bloodsport";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(item);

            Assert.Equal(ItemType.SMG, itemType);
        }

        [Fact]
        public void ShotgunItemTypeAssignedTest()
        {
            string item = "Nova | Tempest";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(item);

            Assert.Equal(ItemType.Shotgun, itemType);
        }

        [Fact]
        public void MachineGunItemTypeAssignedTest()
        {
            string item = "M249 | Nebula Crusader";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(item);

            Assert.Equal(ItemType.MachineGun, itemType);
        }

        [Fact]
        public void PinItemTypeAssignedTest()
        {
            string item = "Antwerp 2022 Pin";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(item);

            Assert.Equal(ItemType.Pin, itemType);
        }

        [Fact]
        public void CompletelyUnknownItemTypeAssignedTest()
        {
            string item = "Musaka";

            ItemType itemType = Cs2ItemTypeHelper.GetItemType(item);

            Assert.Equal(ItemType.Unknown, itemType);
        }

    }
}
