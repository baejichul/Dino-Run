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

    public float _speedPosX;        // 배경 이동속도
    public int _lastPosX;           // 배경 최종 X좌표(스크롤)

    // Start is called before the first frame update
    void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
        _bgMgr = FindObjectOfType<BackGroundManager>();

        _speedPosX = _cfgMgr.getCloudSpeedPosx() * Time.fixedDeltaTime;
        _lastPosX = _cfgMgr.getCloudRockLastPosX();

        // 최종 X좌표 수정
        Vector2 vec = gameObject.GetComponent<SpriteRenderer>().size;
        _lastPosX -= (int)Mathf.Floor(vec.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (_playUI.activeSelf == true)
        {
            // 배경 X축 이동
            transform.Translate(-_speedPosX, 0, 0);   // x축으로만 좌측이동

            int positionX = (int)transform.position.x;
            // Debug.Log(positionX + " == " + _bgImgFirstPosX + " - " + _bgImgWidth);

            // 배경이미지 최종 X좌표에 도달했다면
            if (positionX <= _lastPosX)
            {
                _bgMgr.moveBackGround(gameObject);
            }
        }
    }
}
