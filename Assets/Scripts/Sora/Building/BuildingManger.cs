using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Sora_System;
using System;
using Random = UnityEngine.Random;

namespace Sora_Building
{
    public class BuildingManger : MonoBehaviour
    {
        private int meteorAttackValue;

        private List<bool> fiexdList = new();

        [SerializeField]
        private List<BuildingController> controllers;

        private IReadResult model;
        private IReadBuidingRepair repair;
        private BuildingController brokenController;

        private ReactiveProperty<bool> meteorCheck = new(false);
        private Subject<Unit> meteorFlag = new();
        private Subject<bool> meteorRezult = new();

        private CompositeDisposable disposables = new();

        void Start()
        {
            for (int i = 0; i < controllers.Count; i++)
            {
                fiexdList.Add(false);
            }
            for (int i = 0; i < controllers.Count; i++)
            {
                int temp = i;
                controllers[i].GetRepairHistory()
                    .Subscribe(flag =>
                    {
                        fiexdList[temp] = flag;
                        if (flag)
                        {
                            repair.Repair();
                            CheckRepair();
                        }
                    }).AddTo(disposables);
            }
        }

        private void CheckRepair()
        {
            bool temp = true;
            bool existingCheck = false;
            for (int i = 0; i < controllers.Count; i++)
            {
                if (!fiexdList[i])
                {
                    temp = false;
                }
                else
                {
                    existingCheck = true;
                }
            }

            meteorCheck.Value = existingCheck;

            if (temp)
            {
                model.GameClear();
            }
        }

        //?¿½^?¿½[?¿½Q?¿½b?¿½g?¿½Ì‘I?¿½?¿½
        public void Brokenbuild(int _meteorValue)
        {
            int random = Random.Range(0, controllers.Count);
            if (fiexdList[random])
            {
                meteorAttackValue = _meteorValue;
                brokenController = controllers[random];
                meteorFlag.OnNext(Unit.Default);
            }
            else
            {
                Brokenbuild(_meteorValue);
            }
        }

        public void Broken(bool _check)
        {
            if (_check && repair.InterseptCheck(meteorAttackValue))
            {
                meteorRezult.OnNext(true);
            }
            else
            {
                meteorRezult.OnNext(false);
                brokenController.BuildingDestroy();
            }
        }

        public void Dispose()
        {
            disposables.Dispose();
        }

        public void Inject(IReadResult _model, IReadBuidingRepair _repair)
        {
            model = _model;
            repair = _repair;
        }

        public int GetMeteorAttackValue()
        {
            return meteorAttackValue;
        }

        public IObservable<Unit> GetMeteorFlag()
        {
            return meteorFlag;
        }

        public IObservable<bool> GetMeteorCheck()
        {
            return meteorCheck.AddTo(disposables);
        }

        public IObservable<bool> GetMeteorRezult()
        {
            return meteorRezult;
        }
    }
}