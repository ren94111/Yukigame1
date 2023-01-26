using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Sora_System;

namespace Sora_Building
{
    public class BuildingManger : MonoBehaviour
    {
        private List<bool> fiexdList = new();

        [SerializeField]
        private List<BuildingController> controllers;

        private IReadResult model;

        private CompositeDisposable disposables = new();
        void Start()
        {
            for(int i = 0; i < controllers.Count; i++)
            {
                fiexdList.Add(false);
            }
            for(int i = 0; i < controllers.Count; i++)
            {
                controllers[i].GetRepairHistory()
                    .Subscribe(flag => 
                    {
                        Debug.Log(i);
                        fiexdList[i] = flag; 
                    })
                    .AddTo(disposables);
            }
        }

        private void CheckRepair()
        {
            bool temp = true;
            for (int i = 0; i < controllers.Count; i++)
            {
                if (!controllers[i])
                {
                    temp = false;
                }
            }

            if(!temp)
            {
                model.GameClear();
            }
        }

        public void Inject(IReadResult _model)
        {
            model = _model;
        }
    }
}