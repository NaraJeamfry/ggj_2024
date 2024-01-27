using System;
using System.Collections.Generic;
using Enums;
using Interfaces;

namespace Night.ExtraEffects
{
    public class ExtraEffectFactory
    {
        private static readonly Dictionary<EExtraEffects, Func<IExtras>> Classes = new()
        {
            { EExtraEffects.Attention, () => new ExtraAttention() },
            { EExtraEffects.None, () => null }
        };

        public static IExtras CreateExtra(EExtraEffects effect)
        {
            return Classes[effect]();
        }
    }
}