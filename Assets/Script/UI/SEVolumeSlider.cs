using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SEVolumeSlider : MonoBehaviour
{
    Slider _seSlider;

    void Awake()
    {
        _seSlider = GetComponent<Slider>();
    }

    void Start()
    {
        _seSlider.value = AudioManager.Instance.SEVolume;
    }

    public void SetSEVolume(float volume)
    {
        AudioManager.Instance.SetSEVolume(volume);
    }
}
