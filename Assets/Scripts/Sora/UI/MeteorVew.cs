using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using TMPro;
using Other_System;

namespace Sora_UI
{
    public class MeteorVew : MonoBehaviour
    {
        [SerializeField, Header("覐΂̌}���E�C���h�E")]
        private GameObject meteorWindow;

        [SerializeField, Header("覐Ό}���{�^��")]
        private Button interseptButton;

        [SerializeField, Header("覐Ό}�����Ȃ��{�^��")]
        private Button notInterseptButton;

        [SerializeField, Header("�K�v�A�C�e�����̃e�L�X�g")]
        private TextMeshProUGUI interseptText;

        [SerializeField, Header("�}���ł������̊m�FText")]
        private TextMeshProUGUI meteorRezult;

        private TimerModel timer = new();

        public Subject<bool> interseptFlag = new();

        private CompositeDisposable disposables = new();

        private void Start()
        {
            interseptButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    interseptFlag.OnNext(true);
                }).AddTo(disposables);

            notInterseptButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                        interseptFlag.OnNext(false);
                }).AddTo(disposables);

            meteorWindow.SetActive(false);
            meteorRezult.gameObject.SetActive(false);
            timer.SetTimer(3f);
            timer.GetEndTimer()
                .Subscribe(_ => meteorRezult.gameObject.SetActive(false))
                .AddTo(disposables);
        }

        public void OpneWindow(int attackValue)
        {
            meteorWindow.SetActive(true);
            interseptText.text = "�j���" + attackValue + "��覐΂������Ă��܂���";
        }

        public void CloseWindow()
        {
            meteorWindow.SetActive(false);
        }

        public void RezultText(bool _rezult)
        {
            timer.RestartTimer();
            meteorRezult.gameObject.SetActive(true);
            if (_rezult)
            {
                meteorRezult.text = "覐΂��}�����܂���";
            }
            else
            {
                meteorRezult.text = "覐΂��}���ł��܂���ł���";
            }
        }

        public IObservable<bool> GetInterseptFlag()
        {
            return interseptFlag;
        }
    }
}