using UnityEngine;

public class TestAudio : MonoBehaviour
{
    void Start()
    {
        AudioPersistence();
    }

    public void AudioPersistence()
    {
        //‰æ–Ê‘JˆÚ‚µ‚Ä‚àObject‚ª‰ó‚ê‚È‚¢‚æ‚¤‚É‚µ‚Ä‚¢‚é
        DontDestroyOnLoad(this);
    }
}
