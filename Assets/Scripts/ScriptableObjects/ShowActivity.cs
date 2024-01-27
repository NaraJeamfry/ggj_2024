using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Show/Show Activity")]
    public class ShowActivity : ScriptableObject
    {
        public int length = 1;
        public string activityName;
    }
}