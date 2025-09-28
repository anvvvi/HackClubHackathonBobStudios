using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioSource audioSource;  // muzica
    public Slider volumeSlider;      // slider-ul

    void Start()
    {
        // setăm slider-ul la volumul curent
        volumeSlider.value = audioSource.volume;

        // adăugăm un listener care schimbă volumul când miști slider-ul
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float value)
    {
        audioSource.volume = value;
    }
}