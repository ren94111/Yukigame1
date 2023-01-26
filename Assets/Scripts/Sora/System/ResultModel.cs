using UniRx;
using System;

namespace Sora_System
{
    public interface IReadResult
    {
        void GameClear();
        IObservable<Unit> GetGameOver();
    }

    public class ResultModel : IReadResult
    {
        private static Subject<Unit> gameClear = new();

        public void GameClear()
        {
            gameClear.OnNext(Unit.Default);
        }

        public IObservable<Unit> GetGameOver()
        {
            return gameClear;
        }
    }
}