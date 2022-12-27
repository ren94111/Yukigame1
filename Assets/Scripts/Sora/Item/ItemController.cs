using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Other_System;

namespace Sora_Item
{
    public class ItemController : MonoBehaviour
    {
        [SerializeField, Header("生成場所")]
        private Transform createPos;

        [SerializeField,Header("ItemDataのスクリプタブルオブジェクトのアドレス")]
        private string scriptableAddress;

        private List<GameObject> items = new(10);

        [SerializeField, Header("参照スクリプト")]
        private ItemObjectPool pool;

        private ItemDataModel model = new();
        private TimerModel timer = new();

        private CompositeDisposable disposables = new();

        void Start()
        {
            timer.GetEndTimer()
                .Subscribe(_ => InstanveItem())
                .AddTo(disposables);

            model.GetEndCreate()
                .Subscribe(_ => SetInit(model.GetCreateLimit()));


            model.Init(scriptableAddress);
        }

        private void InstanveItem()
        {
            items.Add(pool.GetCreateObj(createPos));
            timer.RestartTimer();
        }

        public void SetInit(int limit)
        {
            for(int i = 0; i < limit; i++)
            {
                pool.Create(model.GetItemObj());
            }
            model.EndCreateDispose();
            timer.SetTimer(model.GetCreateTime());
        }
    }
}