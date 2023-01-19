using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Other_System;

namespace Sora_Item
{
    public class ItemController : MonoBehaviour
    {
        [SerializeField, Header("シーン番号")]
        private int sceneNam = 0;

        [SerializeField, Header("生成場所")]
        private Transform createPos;

        [SerializeField,Header("ItemDataのスクリプタブルオブジェクトのアドレス")]
        private string scriptableAddress;

        private List<GameObject> items = new(10);

        [SerializeField, Header("参照スクリプト")]
        private ItemObjectPool pool;

        private TimerModel timer = new();

        private Subject<Unit> getItemCheck = new();

        private CompositeDisposable disposables = new();

        void Start()
        {
            timer.GetEndTimer()
                .Subscribe(_ => InstanceItem())
                .AddTo(disposables);
        }

        private void InstanceItem()
        {
            if (pool.CheckPoolList())
            {
                items.Add(pool.GetCreateObj(createPos));
            }
            timer.RestartTimer();
        }

        public void SetInit(int limit, ItemDataModel model)
        {
            for(int i = 0; i < limit; i++)
            {
                pool.Create(model.GetItemObj(),this);
            }
            ItemDataModel.EndCreateDispose();
            if (model.CheckSaveItem())
            {
                for (int i = 0; i < model.GetItemPosition(sceneNam).Count; i++)
                {
                    items.Add(pool.GetCreateObj(model.GetItemPosition(sceneNam)[i]));
                }
            }
            timer.SetTimer(model.GetCreateTime());
        }

        public void GetItem(GameObject obj)
        {
            items.Remove(obj);
            pool.DeleteObj(obj);
            getItemCheck.OnNext(Unit.Default);
        }

        public void SaveObjPos()
        {
            List<Transform> temppos = new List<Transform>(10);
            for(int i = 0; i < items.Count; i++)
            {
                temppos.Add(items[i].transform);
            }

            ItemDataModel.SaveItemPos(sceneNam, temppos);
        }

        public string GetScriptableAddress()
        {
            return scriptableAddress;
        } 

        public IObservable<Unit> GetItemCheck()
        {
            return getItemCheck.AddTo(disposables);
        }
    }
}