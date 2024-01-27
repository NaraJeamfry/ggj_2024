using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Results
{
    public class ResultManager : MonoBehaviour
    {
        public TMP_Text resultText;

        private GameManager _gameManager;
    
        // Start is called before the first frame update
        void Start()
        {
            _gameManager = GameManager.Instance;

            resultText.text = $"Laugh Points: {_gameManager.laughPoints}";
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
