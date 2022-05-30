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

            // �÷��̾ Ground ������ �������� �ʰ� ����
            // 1. transform postion �� ������ ó���ϴ� ���
            // - �ּ� Y���� �������ְ� ��ġ�� �����Ѵ�.

            //Vector3 vec3 = transform.position;
            //float posY = Mathf.Max(_minPosY, vec3.y);
            // Debug.Log("nowPosY : limitPosY = " + vec3.y + " : " + posY);

            //transform.position = new Vector3(vec3.x, posY, vec3.z);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾ Ground ������ �������� �ʰ� ����
        // 2. Ground�� BoxCollider 2D ������Ʈ�� �߰��Ͽ� ó��
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
