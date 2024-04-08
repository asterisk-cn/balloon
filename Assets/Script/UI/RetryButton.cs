using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    public void ResetGame()
    {
        GameManager.Instance.ResetGame();
        AudioManager.Instance.FadeOutBGM(AudioManager.BGM_FADE_SPEED_RATE_HIGH);
    }
}
