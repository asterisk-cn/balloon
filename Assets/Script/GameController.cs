using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject _gameClearPanel;
    [SerializeField]
    GameObject _gameOverPanel;
    [SerializeField]
    TextMeshProUGUI _scoreText;

    public static GameController Instance { get; private set; } = null;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        _gameClearPanel.SetActive(false);
        _gameOverPanel.SetActive(false);

        AudioManager.Instance.PlayBGM("Main");
    }

    public void GameClear(int score)
    {
        _gameClearPanel.SetActive(true);
        _scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
    }

}
