using UnityEngine;
using UniRx;
using System;

namespace Other_System
{
    public class TimerModel
    {
        private float limit;
        private float count = 0;

        private Subject<Unit> endTimer = new();

        private CompositeDisposable disposables = new();

        public void SetTimer(float limitTime)
        {
            limit = limitTime;
            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    count += Time.deltaTime;
                    if (count >= limit)
                    {
                        endTimer.OnNext(Unit.Default);
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