using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _endUI;

    public ConfigManager _cfgMgr;
    public PlayerManager _playMgr;
    public NonePlayerManager _nonePlayMgr;
    public SoundManager _sndMgr;
    public ScoreManager _scMgr;

    // Start is called before the first frame update
    void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
        _playMgr = FindObjectOfType<PlayerManager>();
        _nonePlayMgr = FindObjectOfType<NonePlayerManager>();
        _sndMgr  = FindObjectOfType<SoundManager>();
        _scMgr   = FindObjectOfType<ScoreManager>();

        InitGame();
    }

    // Update is called once per frame
    void Update()
    {   
        // Debug.Log("GameManager Update");
    }
    

    // 인트로 모드
    public void InitGame()
    {
        // UI 초기세팅
        _introUI.SetActive(true);
        _playUI.SetActive(false);
        _endUI.SetActive(false);

        _playMgr.setRigidbodySimulate(false);       // 플레이어 물리중력 제어
        _playMgr.moveIntroPlayerRndPosX();          // 플레이어 랜덤이동
        _sndMgr.play("Intro");
    }

    // 게임 모드
    public void PlayGame()
    {
        _introUI.SetActive(false);
        _playUI.SetActive(true);
        _endUI.SetActive(false);

        _playMgr.initPlayerPosX();
        _playMgr.setRigidbodySimulate(true);
        _nonePlayMgr.setActive(false);
        _sndMgr.play("Button");
    }

    // 게임오버 모드
    public void EndGame()
    {
        // 소리 변경
        _sndMgr.stop("Intro");
        _sndMgr.stop("Jump");
        _sndMgr.play("Die");

        // UI 변경
        _introUI.SetActive(false);
        _playUI.SetActive(false);
        _endUI.SetActive(true);

        _scMgr.viewEndUIGameScore();

        _playMgr.setRigidbodySimulate(false);   // 플레이어 물리중력 제어
        // _playMgr.changePlayerDieImg();
        _playMgr.setTriggerDie();
    }

    // 게임 다시 시작
    public void RePlayGame()
    {   
        _sndMgr.play("Button");
        SceneManager.LoadScene("MainScene");
    }
    
    // 게임 시작버튼
    public void OnClick_BtnStart()
    {
        PlayGame();
    }

    // 게임 다시시작 버튼
    public void OnClick_BtnRetry()
    {
        RePlayGame();
    }
}
