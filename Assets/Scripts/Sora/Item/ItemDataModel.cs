using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UniRx;
using System;
using System.Collections.Generic;

namespace Sora_Item
{
    public class ItemDataModel
    {
        private static ReactiveProperty<int> itemValue = new(0);

        private ItemData data;

        private float createTime;

        private GameObject item;

        private static List<List<Transform>> itemObjectList = new(3);

        private static Subject<Unit> endCreate = new();

        public IObservable<int> GetItemValue => itemValue;

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

        public bool CheckSaveItem()
        {
            if(itemObjectList.Count == 0)
            {
                return false;
            }

            return true;
        }

        public List<Transform> GetItemPosition(int callnum)
        {
            return itemObjectList[callnum];
        }

        public GameObject GetItemObj()
        {
            return item;
        }

        public void GetItem()
        {
            itemValue.Value += 1;
        }

        public static void SaveItemPos(int sceneNum, List<Transform> item)
        {
            itemObjectList[sceneNum].AddRange(item);
        }

        public static void EndCreateDispose()
        {
            endCreate.Dispose();
        }

        public IObservable<Unit> GetEndCreate()
        {
            return endCreate;
        }
    }
}