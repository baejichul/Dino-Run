using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public ConfigManager _cfgMgr;
    public BackGroundManager _bgMgr;

    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _endUI;
    public GameObject _player;

    public float _speedPosX;        // ��� �̵��ӵ�
    public int _lastPosX;           // ��� ���� X��ǥ(��ũ��)

    // Start is called before the first frame update
    void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
        _bgMgr = FindObjectOfType<BackGroundManager>();

        _speedPosX = _cfgMgr.getCloudSpeedPosx() * Time.fixedDeltaTime;
        _lastPosX = _cfgMgr.getCloudRockLastPosX();

        // ���� X��ǥ ����
        Vector2 vec = gameObject.GetComponent<SpriteRenderer>().size;
        _lastPosX -= (int)Mathf.Floor(vec.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (_playUI.activeSelf == true)
        {
            // ��� X�� �̵�
            transform.Translate(-_speedPosX, 0, 0);   // x�����θ� �����̵�

            int positionX = (int)transform.position.x;
            // Debug.Log(positionX + " == " + _bgImgFirstPosX + " - " + _bgImgWidth);

            // ����̹��� ���� X��ǥ�� �����ߴٸ�
            if (positionX <= _lastPosX)
            {
                _bgMgr.moveBackGround(gameObject);
            }
        }
    }
}
