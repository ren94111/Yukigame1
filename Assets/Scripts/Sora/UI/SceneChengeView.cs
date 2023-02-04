using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

namespace Sora_Field
{
    public class SceneChengeView : MonoBehaviour
    {
        [SerializeField, Header("右ボタン")]
        private Button rightButton;

        [SerializeField, Header("左ボタン")]
        private Button leftButton;

        private Subject<bool> moveFlag = new();

        private CompositeDisposable disposables = new();
        void Start()
        {
            rightButton.OnClickAsObservable()
                .Subscribe(_ => moveFlag.OnNext(true))
                .AddTo(disposables);

            leftButton.OnClickAsObservable()
                .Subscribe(_ => moveFlag.OnNext(false))
                .AddTo(disposables);
        }

        public IObservable<bool> GetMoveFlag()
        {
            return moveFlag;
        }
    }
}