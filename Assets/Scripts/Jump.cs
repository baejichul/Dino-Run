using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public ConfigManager _cfgMgr;
    public SoundManager _sndMgr;
    public Rigidbody2D _rigid;
    public Animator _aim;

    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _endUI;

    public bool _isMaxPosY = false;


    // Start is called before the first frame update
    void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
        _sndMgr = FindObjectOfType<SoundManager>();
        _rigid  = gameObject.GetComponent<Rigidbody2D>();
        _aim    = gameObject.GetComponent<Animator>();      // 에니메이터를 통한 JUMP 에니메이션 구현
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (_playUI.activeSelf == true)
        {
            // 플레이어의 Y좌표가 최대값에 이르면 점프를 멈춘다.
            if (pos.y >= _cfgMgr.getPlayerJumpLimitPosY())
            {
                _rigid.velocity = Vector3.zero;
                _isMaxPosY = true;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                // Debug.Log(Mathf.Floor(pos.y) + " == " + _cfgMgr.getPlayerInitPosY());-

                if (_isMaxPosY == false && Mathf.Floor(pos.y) <= _cfgMgr.getPlayerInitPosY())
                {
                    _rigid.AddForce(new Vector2(0.0f, _cfgMgr.getPlayerJumpForce()));            // 위쪽(Y축)으로만 힘을 가한다.

                    // 점프 속도 제한값 넘어가지 않게 설정
                    Vector3 vel = _rigid.velocity;
                    float limit = Mathf.Min(_cfgMgr.getPlayerJumpLimit(), vel.y);
                    _rigid.velocity = new Vector2(vel.x, limit);

                    // Jump 애니메이션 구현
                    _aim.SetTrigger("jump");        // 트리거발생 : 애니메이터의 jump파라미터
                }

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isMaxPosY = false;
                _sndMgr.play("Jump");               // Jump 사운드
            }
        }
    }
}