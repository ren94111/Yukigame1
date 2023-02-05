using UnityEngine;
using UniRx;
using TMPro;
using Other_System;

public class PlayTimeView : MonoBehaviour
{
    private int nowMinitTime = 0;
    private int nowSeondTime = 0;

    [SerializeField,Header("プレイ時間を表示するテキストを入れる")]
    private TextMeshProUGUI timeText;

    private TimerModel timer = new();

    private CompositeDisposable disposables = new();

    void Start()
    {
        timer.GetEndTimer()
            .Subscribe(_ => nextTime())
            .AddTo(disposables);
        timer.SetTimer(1f);
    }

    private void nextTime(){
        nowSeondTime++;
        if(nowSeondTime > 60){
            nowMinitTime ++;
        }
        timeText.text = nowMinitTime.ToString().PadLeft(2,'0') + "：" + nowSeondTime.ToString().PadLeft(2,'0');
        timer.RestartTimer();
    }

    private void OnDestroy() {
        disposables.Dispose();
        timer.EndTimer();
    }
}
