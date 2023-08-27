﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace FargowiltasCrossmod.Core.Calamity
{
    public class CalamityConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static CalamityConfig Instance => ModContent.GetInstance<CalamityConfig>();

        [Header("Modes")] // Title
        [DefaultValue(true)] // This sets the configs default value.
        public bool RevVanillaAIDisabled; 

        [DefaultValue(false)] // This sets the configs default value.
        public bool EternityVanillaAIDisabled;

    }
}
