using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    #region Public Fields

    [Header("Spawn")]
    public Vector2 SpawnForceRange;

    [Header("Audio")]
    public Audio[] PlayerJumpsSfx;
    public Audio PlayerCollecetCandySfx;
    public Audio PlayerCollectFruitSfx;
    public Audio EvilLaugh;

    public int GameLengthInSeconds;
    //public Image GameOverScreen;
    public float DestroyItemAfterTime;

    #endregion

    #region Private Fields

    private static GameManager _instance;
    private float _currentTime;
    private bool _laughPlayed;

    #endregion

    #region Properties

    public static GameManager Instance
    {
        get { return _instance; }
    }

    public int CurrentTime
    {
        get { return Convert.ToInt32(_currentTime);  }
    }
    

    #endregion

    #region Events

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = GetComponent<GameManager>();
        }

        

        _currentTime = GameLengthInSeconds;
    }

    void Start()
    {
        AudioManager.Instance.Play(EvilLaugh, transform.position);
    }

    void Update()
    {
        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
        {
            if (!_laughPlayed)
            {
                AudioManager.Instance.Play(EvilLaugh, transform.position);
                AudioManager.Instance.StopMusic();
                _laughPlayed = true;
            }

            UIManager.Instance.GameOverScreen();
        }
    }

    #endregion
}