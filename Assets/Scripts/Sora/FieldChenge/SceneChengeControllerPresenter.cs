using UniRx;

namespace Sora_Field
{
    public class SceneChengeControllerPresenter
    {
        private IReadSceneChaege sceneChenge;
        private SceneChengeController controller;

        protected CompositeDisposable disposables = new();
        public void Inject(IReadSceneChaege _sceneChenge, SceneChengeController _controller)
        {
            sceneChenge = _sceneChenge;
            controller = _controller;

            sceneChenge.GetNextScene()
                .Select(x => x - 1)
                .Subscribe(x => controller.ChengeCamera(x))
                .AddTo(disposables);

            sceneChenge.Init(controller.GetCameraValue());

        }

        public void Dispose()
        {
            disposables.Dispose();
        }
    }
}