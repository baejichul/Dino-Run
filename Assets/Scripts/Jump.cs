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
        _aim    = gameObject.GetComponent<Animator>();      // ���ϸ����͸� ���� JUMP ���ϸ��̼� ����
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (_playUI.activeSelf == true)
        {
            // �÷��̾��� Y��ǥ�� �ִ밪�� �̸��� ������ �����.
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
                    _rigid.AddForce(new Vector2(0.0f, _cfgMgr.getPlayerJumpForce()));            // ����(Y��)���θ� ���� ���Ѵ�.

                    // ���� �ӵ� ���Ѱ� �Ѿ�� �ʰ� ����
                    Vector3 vel = _rigid.velocity;
                    float limit = Mathf.Min(_cfgMgr.getPlayerJumpLimit(), vel.y);
                    _rigid.velocity = new Vector2(vel.x, limit);

                    // Jump �ִϸ��̼� ����
                    _aim.SetTrigger("jump");        // Ʈ���Ź߻� : �ִϸ������� jump�Ķ����
                }

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isMaxPosY = false;
                _sndMgr.play("Jump");               // Jump ����
            }
        }
    }
}