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
        [SerializeField, Header("隕石の迎撃ウインドウ")]
        private GameObject meteorWindow;

        [SerializeField, Header("隕石迎撃ボタン")]
        private Button interseptButton;

        [SerializeField, Header("隕石迎撃しないボタン")]
        private Button notInterseptButton;

        [SerializeField, Header("必要アイテム数のテキスト")]
        private TextMeshProUGUI interseptText;

        [SerializeField, Header("迎撃できたかの確認Text")]
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
            interseptText.text = "破壊力" + attackValue + "の隕石が落ちてきました";
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
                meteorRezult.text = "隕石を迎撃しました";
            }
            else
            {
                meteorRezult.text = "隕石を迎撃できませんでした";
            }
        }

        public IObservable<bool> GetInterseptFlag()
        {
            return interseptFlag;
        }
    }
}