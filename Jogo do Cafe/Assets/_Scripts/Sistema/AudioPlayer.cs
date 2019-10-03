using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource SFX;

    public static AudioPlayer instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlayBGM(AudioClip _music)
    {
        BGM.clip = _music;
        BGM.Play();
    }

    public void PlaySFX(AudioClip _soundEffect)
    {
        SFX.PlayOneShot(_soundEffect);
    }

    public void StopBGM()
    {
        BGM.Stop();
    }

    public void StopSFX()
    {
        SFX.Stop();
    }
}