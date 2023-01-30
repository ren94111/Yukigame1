using UnityEngine;

namespace Sora_Meteor
{
    [CreateAssetMenu(fileName = "MeteorData", menuName = "ScriptableObject/MeteorData", order = 2)]
    public class MeteorData : ScriptableObject
    {
        [SerializeField, Header("���ڂ̎���")]
        private float firstTime = 5f;

        [SerializeField, Header("覐ΐ����̍ŒZ����")]
        private float minTime = 10f;

        [SerializeField, Header("覐΂̍ő厞��")]
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