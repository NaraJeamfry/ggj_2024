using System;
using ScriptableObjects;

namespace Night
{
    [Serializable]
    public class NightSlot
    {
        public ShowActivity Activity;
        public ShowTheme[] ChosenThemes;
    }
}