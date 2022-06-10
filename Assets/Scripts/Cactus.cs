using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public ConfigManager _cfgMgr;
    public BackGroundManager _bgMgr;
    public ScoreManager _scMgr;

    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _endUI;
    public GameObject _player;

    public float _speedPosX;        // ��� �̵��ӵ�
    public int _lastPosX;           // ��� ���� X��ǥ

    // Start is called before the first frame update
    void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
        _bgMgr = FindObjectOfType<BackGroundManager>();
        _scMgr = FindObjectOfType<ScoreManager>();

        _speedPosX = _cfgMgr.getCactusSpeedPosx() * Time.deltaTime;
        _lastPosX = _cfgMgr.getCactusLastPosx();

        // ���� X��ǥ ����
        Vector2 vec = gameObject.GetComponent<SpriteRenderer>().size;
        _lastPosX -= (int)Mathf.Floor(vec.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (_playUI.activeSelf == true)
        {
            int quotient = (int) _scMgr.getGameScore() / 10;

            // ��� X�� �̵�
            if (quotient == 0)
            {
                transform.Translate(-_speedPosX, 0, 0);
            }
            else if (quotient == 1)
            {
                if (transform.position.y >= 0.0f)
                {
                    transform.Translate(-_speedPosX * 1.25f, 0, 0);
                }
                else
                {
                    transform.Translate(-_speedPosX * 1.25f, 0.0005f, 0);
                }
            }
            else if (quotient >= 2)
            {
                if (transform.position.y >= 0.0f)
                {
                    transform.Translate(-_speedPosX * 1.5f, 0, 0);
                }
                else
                {
                    transform.Translate(-_speedPosX * 1.5f, 0.001f, 0);
                }
            }

            // gameObject.SetActive(false);

            int positionX = (int)transform.position.x;
            // Debug.Log(positionX + " == " + _bgImgFirstPosX + " - " + _bgImgWidth);

            // ����̹��� ���� X��ǥ�� �����ߴٸ�
            if (positionX <= _lastPosX)
            {
                _bgMgr.moveCactus(gameObject);
            }
        }
        
    }
}
