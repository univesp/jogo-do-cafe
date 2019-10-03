using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    public void VolumeBGM()
    {
        audioMixer.SetFloat("BGM", bgmSlider.value);
    }

    public void VolumeSFX()
    {
        audioMixer.SetFloat("SFX", sfxSlider.value);
    }
}
