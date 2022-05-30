using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _endUI;

    public ConfigManager _cfgMgr;
    public Text _txtScoreNumber;
    public Text _txtLastScoreNumber;

    int _gameScore;

    // Start is called before the first frame update
    void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _txtScoreNumber = _playUI.transform.Find("TxtScoreNumber").GetComponent<Text>();
        _txtScoreNumber.text = _gameScore.ToString("D7");
    }

    public int getGameScore()
    {
        return _gameScore;
    }

    public void viewEndUIGameScore()
    {
        // �������� ǥ��
        _txtLastScoreNumber = _endUI.transform.Find("TxtLastScoreNumber").GetComponent<Text>();
        _txtLastScoreNumber.text = _gameScore.ToString("D7");
    }

    // ���� ȹ��
    public void ObtainScore()
    {
        _gameScore += _cfgMgr.getBasicObtainScore();
    }

    // ���� ȹ��
    public void ObtainScore(int val)
    {
        _gameScore += val;
    }
}
