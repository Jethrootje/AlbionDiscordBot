using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot.Models
{
    public class EnchantmentContainer
    {
        public List<Enchantment> Enchantments { get; set; }
    }

    public class Weapon
    {
        public string ItemType { get; set; }
        public string UniqueName { get; set; }
        public string UiSprite { get; set; }
        public string UiSpriteOverlay1 { get; set; }
        public string UiSpriteOverlay2 { get; set; }
        public string UiSpriteOverlay3 { get; set; }
        public string UiAtlas { get; set; }
        public bool? ShowInMarketplace { get; set; }
        public int? Level { get; set; }
        public int? Tier { get; set; }
        public int? EnchantmentLevel { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? Revision { get; set; }
        public string SlotType { get; set; }
        public bool? UnlockedToEquip { get; set; }
        public bool? TwoHanded { get; set; }
        public bool? UnequipInCombat { get; set; }
        public int? MaxQualityLevel { get; set; }
        public double? AbilityPower { get; set; }
        public double? PhysicalSpellDamageBonus { get; set; }
        public double? MagicSpellDamageBonus { get; set; }
        public double? AttackDamage { get; set; }
        public double? AttackSpeed { get; set; }
        public double? AttackRange { get; set; }
        public double? Weight { get; set; }
        public int? ActiveSpellSlots { get; set; }
        public int? PassiveSpellSlots { get; set; }
        public double? Durability { get; set; }
        public double? DurabilityLossAttack { get; set; }
        public double? DurabilityLossSpellUse { get; set; }
        public double? DurabilityLossReceivedAttack { get; set; }
        public double? DurabilityLossReceivedSpell { get; set; }
        public double? HitpointsMax { get; set; }
        public double? ItemPower { get; set; }
        public double? HitpointsRegenerationBonus { get; set; }
        public string ItemPowerProgressionType { get; set; }
        public string AttackType { get; set; }
        public string FxBoneName { get; set; }
        public string MainhandAnimationType { get; set; }
        public string Transformation { get; set; }
        public string SpriteName { get; set; }
        public bool? Stackable { get; set; }
        public bool? Equipable { get; set; }
        public EnchantmentContainer Enchantments { get; set; }
    }
}
