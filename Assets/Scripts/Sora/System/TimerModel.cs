using UnityEngine;
using UniRx;
using System;

namespace Other_System
{
    public class TimerModel
    {
        private float limit;
        private float count = 0;

        private bool timeCheck = true;

        private Subject<Unit> endTimer = new();

        private CompositeDisposable disposables = new();

        public void SetTimer(float limitTime)
        {
            limit = limitTime;
            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    if(count == 0)
                    {
                        timeCheck = true;
                    }
                    count += Time.deltaTime;
                    if ((count >= limit) && timeCheck)
                    {
                        endTimer.OnNext(Unit.Default);
                        timeCheck = false;
                    }
                }).AddTo(disposables);
        }

        public void SetLimitTime(float time)
        {
            limit = time;
        }

        public void RestartTimer()
        {
            count = 0;
            timeCheck = true;
        }

        public void StopTimer()
        {
            timeCheck = false;
        }

        public void EndTimer()
        {
            disposables.Dispose();
        }

        public IObservable<Unit> GetEndTimer()
        {
            return endTimer.AddTo(disposables);
        }
    }
}