using UnityEngine;

public class TestAudio : MonoBehaviour
{
    void Start()
    {
        AudioPersistence();
    }

    public void AudioPersistence()
    {
        //画面遷移してもObjectが壊れないようにしている
        DontDestroyOnLoad(this);
    }
}
