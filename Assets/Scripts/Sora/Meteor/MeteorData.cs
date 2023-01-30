using UnityEngine;

namespace Sora_Meteor
{
    [CreateAssetMenu(fileName = "MeteorData", menuName = "ScriptableObject/MeteorData", order = 2)]
    public class MeteorData : ScriptableObject
    {
        [SerializeField, Header("ˆê‰ñ–Ú‚ÌŠÔ")]
        private float firstTime = 5f;

        [SerializeField, Header("è¦Î¶¬‚ÌÅ’ZŠÔ")]
        private float minTime = 10f;

        [SerializeField, Header("è¦Î‚ÌÅ‘åŠÔ")]
        private float maxTime = 15f;

        public float FirstTime()
        {
            return firstTime;
        }

        public float MinTime()
        {
            return minTime;
        }

        public float MaxTime()
        {
            return maxTime;
        }
    }
}