using UniRx;
using Sora_System;

namespace SceneaManger
{
    public class SceneMangerPresenter
    {
        private SceneManagerController controller;
        private IReadResult result;

        private CompositeDisposable disposables = new();

        public void Inject(SceneManagerController _controller, IReadResult _result)
        {
            controller = _controller;
            result = _result;

            result.GetGameClear()
                .Subscribe(_ => controller.LoadScene("end"))
                .AddTo(disposables);
        }

        public void Dispose()
        {
            disposables.Dispose();
        }
    }
}