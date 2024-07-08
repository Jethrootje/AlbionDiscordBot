using AlbionDiscordBot.ApiResponses;
using AlbionDiscordBot.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot.Utilities
{
    public static class DrawingUtility
    {
        public static Image<Rgba32> GetInventory()
        {
            Image<Rgba32> image = Image.Load<Rgba32>(Path.Combine(AppContext.BaseDirectory, "Images", "inventoryAlbion.png"));
            return image;
        }

        private static Point GetPoint(EquipmentType type, Image<Rgba32> image)
        {
            int x = 0, y = 0;

            switch (type)
            {
                case EquipmentType.Head:
                    x = 975; y = 429;
                    break;
                case EquipmentType.Armor:
                    x = 975; y = 625;
                    break;
                case EquipmentType.Shoes:
                    x = 975; y = 815;
                    break;
                case EquipmentType.Mount:
                    x = 975; y = 1020;
                    break;
                case EquipmentType.MainHand:
                    x = 775; y = 671;
                    break;
                case EquipmentType.OffHand:
                    x = 1175; y = 673;
                    break;
                case EquipmentType.Bag:
                    x = 775; y = 473;
                    break;
                case EquipmentType.Cape:
                    x = 1180; y = 471;
                    break;
                case EquipmentType.Food:
                    x = 1180; y = 870;
                    break;
                case EquipmentType.Potion:
                    x = 775; y = 870;
                    break;
                default: break;
            }

            x -= image.Width / 2;
            y -= image.Height / 2;
            return new Point(x, y);
        }

        private static Image<Rgba32> MakeImageTransparent(Image<Rgba32> image, float transparency)
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var pixel = image[x, y];
                    pixel.A = (byte)(pixel.A * transparency);
                    image[x, y] = pixel;
                }
            }

            return image;
        }

        public static Image<Rgba32> AddImage(EquipmentType type, Image<Rgba32> inventory, string name, bool transparent = false)
        {
            Image<Rgba32> image = ApiUtility.GetRender(name).Result;

            if (transparent)
            {
                image = MakeImageTransparent(image, 0.3f);
            }

            Point point = GetPoint(type, image);

            inventory.Mutate(ctx => ctx
                .DrawImage(image, point, 1f)
                .BackgroundColor(Color.Transparent));

            return inventory;
        }

        public static Image<Rgba32> AddImages(Image<Rgba32> inventory, Player player)
        {
            if (player.Equipment.Head != null) inventory = AddImage(EquipmentType.Head, inventory, player.Equipment.Head.Type);
            if (player.Equipment.Armor != null) inventory = AddImage(EquipmentType.Armor, inventory, player.Equipment.Armor.Type);
            if (player.Equipment.Shoes != null) inventory = AddImage(EquipmentType.Shoes, inventory, player.Equipment.Shoes.Type);
            if (player.Equipment.Mount != null) inventory = AddImage(EquipmentType.Mount, inventory, player.Equipment.Mount.Type);
            if (player.Equipment.MainHand != null) inventory = AddImage(EquipmentType.MainHand, inventory, player.Equipment.MainHand.Type);
            if (player.Equipment.Bag != null) inventory = AddImage(EquipmentType.Bag, inventory, player.Equipment.Bag.Type);
            if (player.Equipment.Cape != null) inventory = AddImage(EquipmentType.Cape, inventory, player.Equipment.Cape.Type);
            if (player.Equipment.Food != null) inventory = AddImage(EquipmentType.Food, inventory, player.Equipment.Food.Type);
            if (player.Equipment.Potion != null) inventory = AddImage(EquipmentType.Potion, inventory, player.Equipment.Potion.Type);

            if (player.Equipment.OffHand != null)
            {
                inventory = AddImage(EquipmentType.OffHand, inventory, player.Equipment.OffHand.Type);
            }
            else
            {
                if (player.Equipment.MainHand != null)
                {
                    Weapon weapon = ApiUtility.GetWeapon(player.Equipment.MainHand.Type).Result;
                    if (weapon.TwoHanded.HasValue && weapon.TwoHanded.Value)
                    {
                        inventory = AddImage(EquipmentType.OffHand, inventory, player.Equipment.MainHand.Type, true);
                    }
                }
            }

            return inventory;
        }
    }
}
