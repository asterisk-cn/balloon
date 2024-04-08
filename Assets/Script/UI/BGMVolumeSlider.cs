using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMVolumeSlider : MonoBehaviour
{
    Slider _bgmSlider;

    void Awake()
    {
        _bgmSlider = GetComponent<Slider>();
    }

    void Start()
    {
        _bgmSlider.value = AudioManager.Instance.BGMVolume;
    }

    public void SetBGMVolume(float volume)
    {
        AudioManager.Instance.SetBGMVolume(volume);
    }
}
