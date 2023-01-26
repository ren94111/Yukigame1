using UnityEngine;
using TMPro;
using Sora_Item;

namespace Sora_UI
{
    public class ScoreVew : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;


        private void Start()
        {
            
        }

        public void SetScore(int value)
        {
            scoreText.text = value + "ŒÂ";
        }
    }
}