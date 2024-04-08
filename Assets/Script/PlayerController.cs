using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _expandSpeed = 5.0f;
    [SerializeField]
    private float _wallWidth = 0.5f;

    [SerializeField]
    private GameObject _circle;
    [SerializeField]
    private GameObject _guide;

    private PlayerState _playerState;

    private float _screenRight;
    private float _screenLeft;
    private float _screenTop;
    private float _screenBottom;
    private float _playerWidth;
    private float _playerHeight;

    private int _horizontalDirection = 1;
    private int _verticalDirection = 1;
    private bool _isClear = true;

    private PlayerInputs _inputs;
    private Collider2D _collider;

    enum PlayerState
    {
        Horizontal,
        Vertical,
        Expanding,
        End
    }

    void Awake()
    {
        _inputs = GetComponent<PlayerInputs>();
        _collider = GetComponentInChildren<Collider2D>();
    }

    void Start()
    {
        _playerState = PlayerState.Horizontal;
        _collider.enabled = false;
        _circle.SetActive(false);
        _guide.SetActive(true);

        SetScreenBoundaries();
        SetPlayerBoundaries();
    }

    void SetScreenBoundaries()
    {
        _screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - _wallWidth;
        _screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + _wallWidth;
        _screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - _wallWidth;
        _screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y + _wallWidth;
    }

    void SetPlayerBoundaries()
    {
        _playerWidth = _collider.bounds.size.x;
        _playerHeight = _collider.bounds.size.y;
    }

    void Update()
    {
        if (_inputs.fire)
        {
            TransitionState();
        }
        if (_playerState == PlayerState.Vertical)
        {
            VerticalMove();
        }
        else if (_playerState == PlayerState.Horizontal)
        {
            HorizontalMove();
        }
        else if (_playerState == PlayerState.Expanding)
        {
            Expand();
        }
    }

    void TransitionState()
    {
        if (_playerState == PlayerState.Horizontal)
        {
            _playerState = PlayerState.Vertical;
            AudioManager.Instance.PlaySE("Fire");
        }
        else if (_playerState == PlayerState.Vertical)
        {
            ToExpand();
            AudioManager.Instance.PlaySE("Fire");
        }
        else if (_playerState == PlayerState.Expanding)
        {
            ToEnd();
        }
    }

    void ToExpand()
    {
        _collider.enabled = true;
        _circle.SetActive(true);
        _guide.SetActive(false);
        _playerState = PlayerState.Expanding;
    }

    void ToEnd()
    {
        _collider.enabled = false;
        _playerState = PlayerState.End;
        if (_isClear)
        {
            GameController.Instance.GameClear(Score);
        }
        else
        {
            GameController.Instance.GameOver();
        }

    }

    void HorizontalMove()
    {
        // Move the player horizontally
        float newX = transform.position.x + _speed * _horizontalDirection * Time.deltaTime;

        if (newX + _playerWidth / 2 > _screenRight)
        {
            _horizontalDirection = -1;
        }
        else if (newX - _playerWidth / 2 < _screenLeft)
        {
            _horizontalDirection = 1;
        }

        else
        {
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    void VerticalMove()
    {
        // Move the player vertically
        float newY = transform.position.y + _speed * _verticalDirection * Time.deltaTime;

        if (newY + _playerHeight / 2 > _screenTop)
        {
            _verticalDirection = -1;
        }
        else if (newY - _playerHeight / 2 < _screenBottom)
        {
            _verticalDirection = 1;
        }

        else
        {
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    void Expand()
    {
        // Expand the player
        float newRadius = _circle.transform.localScale.x + _expandSpeed * Time.deltaTime;

        _circle.transform.localScale = new Vector3(newRadius, newRadius, 1);
    }

    public void Hit()
    {
        _isClear = false;
        ToEnd();
    }

    int Score
    {
        get
        {
            // area of the circle
            return (int)(Mathf.PI * Mathf.Pow(_circle.transform.localScale.x / 2, 2));
        }
    }
}
