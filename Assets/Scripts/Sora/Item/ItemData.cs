using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sora_Item
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/ItemData", order = 1)]

    public class ItemData : ScriptableObject
    {
        [SerializeField, Header("何個アイテムを生成しておくか")]
        private int createLimit;

        [SerializeField, Header("初期の生成時間")]
        private float createTime;

        [SerializeField, Header("アイテムのアドレス")]
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