using UniRx;

namespace Sora_Field
{
    public class SceneChengePresenter
    {
        private IReadSceneChaege sceneChenge;
        private SceneChengeView viewChenge;

        private CompositeDisposable disposables = new();

        public void Inject(IReadSceneChaege _sceneChenge, SceneChengeView _viewChenge)
        {
            sceneChenge = _sceneChenge;
            viewChenge = _viewChenge;

            viewChenge.GetMoveFlag()
                .Where(flag => flag)
                .Subscribe(_ => sceneChenge.ChengeRightScene())
                .AddTo(disposables);

            viewChenge.GetMoveFlag()
                .Where(flag => !flag)
                .Subscribe(_ => sceneChenge.ChengeLeftScene())
                .AddTo(disposables);
        }

        public void Dispose()
        {
            disposables.Dispose();
        }
    }
}