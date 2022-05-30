using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public ConfigManager _cfgMgr;
    public GameManager _gameMgr;
    public SoundManager _sndMgr;
    public ScoreManager _scMgr;
    public Rigidbody2D _rigid;

    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _endUI;

    float _minPosY;

    // Start is called before the first frame update
    void Start()
    {
        _cfgMgr  = FindObjectOfType<ConfigManager>();
        _gameMgr = FindObjectOfType<GameManager>();
        _sndMgr  = FindObjectOfType<SoundManager>();
        _scMgr   = FindObjectOfType<ScoreManager>();
        _rigid   = gameObject.GetComponent<Rigidbody2D>();
        _minPosY = _cfgMgr.getPlayerInitPosY();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _vecPlayer = transform.position;

        if (_playUI.activeSelf == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                float posX = _vecPlayer.x - _cfgMgr.getPlayerMovePower();
                if (posX <= _cfgMgr.getPlayerMinMovePosX())
                    posX = _cfgMgr.getPlayerMinMovePosX();

                transform.position = new Vector3(posX, _vecPlayer.y, _vecPlayer.z);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                float posX = _vecPlayer.x + _cfgMgr.getPlayerMovePower();
                if (posX >= _cfgMgr.getPlayerMaxMovePosX())
                    posX = _cfgMgr.getPlayerMaxMovePosX();

                transform.position = new Vector3(posX, _vecPlayer.y, _vecPlayer.z);
            }

            // 플레이어가 Ground 밑으로 내려가지 않게 설정
            // 1. transform postion 을 가지고 처리하는 방법
            // - 최소 Y값을 지정해주고 위치를 변경한다.

            //Vector3 vec3 = transform.position;
            //float posY = Mathf.Max(_minPosY, vec3.y);
            // Debug.Log("nowPosY : limitPosY = " + vec3.y + " : " + posY);

            //transform.position = new Vector3(vec3.x, posY, vec3.z);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어가 Ground 밑으로 내려가지 않게 설정
        // 2. Ground에 BoxCollider 2D 콤포넌트를 추가하여 처리
        // Debug.Log(" OnCollisionEnter2D : " + collision.gameObject.name);

        if ( collision.gameObject.name.Contains("Ground") )
            _sndMgr.play("Land");

        if (collision.gameObject.name.Contains("Cactus"))
            _gameMgr.EndGame();
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("OnTriggerEnter2D : " + collision.gameObject.name);

        if (collision.gameObject.name.Contains("CactusScore"))
            _scMgr.ObtainScore();
    }
}
