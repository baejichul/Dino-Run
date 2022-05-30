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
    

    // ��Ʈ�� ���
    public void InitGame()
    {
        // UI �ʱ⼼��
        _introUI.SetActive(true);
        _playUI.SetActive(false);
        _endUI.SetActive(false);

        _playMgr.setRigidbodySimulate(false);       // �÷��̾� �����߷� ����
        _playMgr.moveIntroPlayerRndPosX();          // �÷��̾� �����̵�
        _sndMgr.play("Intro");
    }

    // ���� ���
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

    // ���ӿ��� ���
    public void EndGame()
    {
        // �Ҹ� ����
        _sndMgr.stop("Intro");
        _sndMgr.stop("Jump");
        _sndMgr.play("Die");

        // UI ����
        _introUI.SetActive(false);
        _playUI.SetActive(false);
        _endUI.SetActive(true);

        _scMgr.viewEndUIGameScore();

        _playMgr.setRigidbodySimulate(false);   // �÷��̾� �����߷� ����
        // _playMgr.changePlayerDieImg();
        _playMgr.setTriggerDie();
    }

    // ���� �ٽ� ����
    public void RePlayGame()
    {   
        _sndMgr.play("Button");
        SceneManager.LoadScene("MainScene");
    }
    
    // ���� ���۹�ư
    public void OnClick_BtnStart()
    {
        PlayGame();
    }

    // ���� �ٽý��� ��ư
    public void OnClick_BtnRetry()
    {
        RePlayGame();
    }
}
