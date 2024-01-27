using System;

namespace Night
{
    [Serializable]
    public class ResourceUpdates
    {
        public int moneyChange;
        public int renownChange;
        public int staminaChange;
        public int laughChange;

        public ResourceUpdates ApplyWear(float wear)
        {
            ResourceUpdates result = new ResourceUpdates();
            result.moneyChange = (int)Math.Ceiling(moneyChange * wear);
            result.renownChange = (int)Math.Ceiling(renownChange * wear);
            result.staminaChange = (int)Math.Ceiling(staminaChange * wear);
            result.laughChange = (int)Math.Ceiling(laughChange * wear);
            return result;
        }
    }
}