using UnityEngine;

public class TestAudio : MonoBehaviour
{
    void Start()
    {
        AudioPersistence();
    }

    public void AudioPersistence()
    {
        //��ʑJ�ڂ��Ă�Object�����Ȃ��悤�ɂ��Ă���
        DontDestroyOnLoad(this);
    }
}
