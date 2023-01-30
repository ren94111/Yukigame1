using UnityEngine;

namespace Sora_Meteor
{
    [CreateAssetMenu(fileName = "MeteorData", menuName = "ScriptableObject/MeteorData", order = 2)]
    public class MeteorData : ScriptableObject
    {
        [SerializeField, Header("一回目の時間")]
        private float firstTime = 5f;

        [SerializeField, Header("隕石生成の最短時間")]
        private float minTime = 10f;

        [SerializeField, Header("隕石の最大時間")]
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