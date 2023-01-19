using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sora_Item
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/ItemData", order = 1)]

    public class ItemData : ScriptableObject
    {
        [SerializeField, Header("���A�C�e���𐶐����Ă�����")]
        private int createLimit;

        [SerializeField, Header("�����̐�������")]
        private float createTime;

        [SerializeField, Header("�A�C�e���̃A�h���X")]
        private string itemAddress;

        public int GetCreateLimit()
        {
            return createLimit;
        }

        public float GetCreateTime()
        {
            return createTime;
        }

        public string GetItemAddress()
        {
            return itemAddress;
        }
    }

}