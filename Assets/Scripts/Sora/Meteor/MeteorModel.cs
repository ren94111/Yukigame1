using Other_System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Sora_Meteor
{
    public interface IReadMeteor
    {
        void FirstMeteorTimer();
        void NextMeteorTimer();
        void StopTimer();
        void ReStartTimer();
        void EndTimer();
        int GetMeteorAttack();
        IObservable<Unit> GetTimeEnd();
    }
    public class MeteorModel : IReadMeteor
    {
        private int meteorAttack = 10;

        private MeteorData scriptableObj;

        private TimerModel timer = new();

        public MeteorModel(MeteorData _scriptableObj)
        {
            scriptableObj = _scriptableObj;
        }

        public void FirstMeteorTimer()
        {
            timer.SetTimer(scriptableObj.FirstTime());
        }

        public void NextMeteorTimer()
        {
            float time = UnityEngine.Random.Range(scriptableObj.MinTime(), scriptableObj.MaxTime());
            timer.RestartTimer();
            timer.SetLimitTime(time);
        }

        public void StopTimer()
        {
            timer.StopTimer();
        }

        public void ReStartTimer()
        {
            timer.RestartTimer();
        }

        public void EndTimer()
        {
            timer.EndTimer();
        }

        public int GetMeteorAttack()
        {
            return meteorAttack;
        }

        public IObservable<Unit> GetTimeEnd()
        {
            return timer.GetEndTimer();
        }
    }
}