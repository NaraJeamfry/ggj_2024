using Night;
using ScriptableObjects;

namespace Interfaces
{
    /// <summary>
    /// Extra effects for a ShowActivity.
    /// </summary>
    public interface IExtras
    {
        public void ApplyExtras(ShowActivity activity, NightManager nightManager);
    }
}