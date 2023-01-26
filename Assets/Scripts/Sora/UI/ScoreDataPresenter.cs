using UniRx;
using Sora_Item;

namespace Sora_UI {
    public class ScoreDataPresenter
    {
        private IReadItemData score;

        private CompositeDisposable disposables = new();

        public void Inject(IReadItemData _score, ScoreVew _vew)
        {
            score = _score;
            score.GetItemValue()
                .Subscribe(x => _vew.SetScore(x))
                .AddTo(disposables);
        }

        public void DestroyThis()
        {
            disposables.Dispose();
        }
    }
}