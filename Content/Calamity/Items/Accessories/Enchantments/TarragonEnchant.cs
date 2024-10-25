using FargowiltasCrossmod.Core;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasCrossmod.Content.Calamity.Projectiles;
using FargowiltasSouls;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Forces;
using FargowiltasCrossmod.Core.Calamity;
using FargowiltasCrossmod.Core.Calamity.ModPlayers;
using FargowiltasSouls.Core.ModPlayers;
using Terraria.Localization;
using FargowiltasCrossmod.Content.Calamity.Toggles;
using CalamityMod;

namespace FargowiltasCrossmod.Content.Calamity.Items.Accessories.Enchantments
{
    [JITWhenModsEnabled(ModCompatibility.Calamity.Name)]
    [ExtendsFromMod(ModCompatibility.Calamity.Name)]
    [LegacyName("TarragonEnchantment")]
    public class TarragonEnchantment : BaseEnchant
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            //return FargowiltasCrossmod.EnchantLoadingEnabled;
            return true;
        }
        public override Color nameColor => new Color(124, 252, 0);
        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.rare = ItemRarityID.Turquoise;
            Item.value = 100000;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            CalDLCAddonPlayer mplayer = player.GetModPlayer<CalDLCAddonPlayer>();
            player.AddEffect<TarragonEffect>(Item);
            if (mplayer.TarragonHeartCD > 0)
            {
                mplayer.TarragonHeartCD--;
            }
        }
        public static void AddEffects(Player player, Item item)
        {
            player.AddEffect<TarragonEffect>(item);
        }
    }
    public class TarragonEffect : AccessoryEffect
    {
        public static void ActivateTarragonBloom(Player player)
        {
            CalDLCAddonPlayer mplayer = player.GetModPlayer<CalDLCAddonPlayer>();
            if (!player.HasBuff(ModContent.BuffType<TarragonCooldown>()))
            {
                NPC newBloom = NPC.NewNPCDirect(player.GetSource_Misc(""), x, y, ModContent.NPCType<TarragonBloom>(), 0);
                player.AddBuff(ModContent.BuffType<TarragonCooldown>(), 600);
                mplayer.TarragonHeartSpawn(newBloom);
            }
        }
    }
}
