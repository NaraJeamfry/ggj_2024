using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Night.ExtraEffects
{
    public class ExtraAttention : IExtras
    {
        public void ApplyExtras(ShowActivity activity, NightManager nightManager)
        {
            Debug.Log($"[ExtraAttention] Gained extra attention.");
        }
    }
}