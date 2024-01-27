using System;
using UnityEngine;
using UnityEngine.UI;

namespace Night
{
    public class NightChoicesButton : MonoBehaviour
    {
        public Action Action;
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
        }
    }
}