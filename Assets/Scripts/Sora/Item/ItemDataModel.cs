using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UniRx;
using System;

namespace Sora_Item
{
    public class ItemDataModel
    {
        private ItemData data;

        private float createTime;

        private GameObject item;

        private Subject<Unit> endCreate = new();

        public void Init(string address)
        {
            var scriptable = Addressables.LoadAssetAsync<ItemData>(address);
            scriptable.Completed += itemdata =>
            {
                if (itemdata.Status == AsyncOperationStatus.Succeeded)
                {
                    data = itemdata.Result;
                    createTime = data.GetCreateTime();
                    var handle = Addressables.LoadAssetAsync<GameObject>(data.GetItemAddress());
                    handle.Completed += obj =>
                    {
                        if (obj.Status == AsyncOperationStatus.Succeeded)
                        {
                            item = obj.Result;
                            endCreate.OnNext(Unit.Default);
                        }
                    };
                }
            };

        }

        public int GetCreateLimit()
        {
            return data.GetCreateLimit();
        }

        public float GetCreateTime()
        {
            return createTime;
        }

        public GameObject GetItemObj()
        {
            return item;
        }

        public void EndCreateDispose()
        {
            endCreate.Dispose();
        }

        public IObservable<Unit> GetEndCreate()
        {
            return endCreate;
        }
    }

    [CreateAssetMenu(fileName ="ItemData", menuName ="ScriptableObject/ItemData",order =1)]
    public class ItemData : ScriptableObject
    {
        [SerializeField,Header("何個アイテムを生成しておくか")]
        private int createLimit;

        [SerializeField,Header("初期の生成時間")]
        private float createTime;

        [SerializeField,Header("アイテムのアドレス")]
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