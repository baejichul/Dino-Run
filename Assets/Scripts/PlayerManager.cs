using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _endUI;

    public ConfigManager _cfgMgr;
    public Animator _ani;

    // Start is called before the first frame update
    void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // �÷��̾� ��ġ ��������
    public void moveIntroPlayerRndPosX()
    {   
        if (_introUI.activeSelf == true)
        {
            // scene ���ε� �� null �߻�
            if (_cfgMgr is null)
                _cfgMgr = FindObjectOfType<ConfigManager>();

            float _rndMinPosX = _cfgMgr.getPlayerMinMovePosX();
            float _rndMaxPosX = _cfgMgr.getPlayerMaxMovePosX();
            float _delayTime = _cfgMgr.getInvokeBasicTime();

            Vector3 vecPos = transform.position;
            Vector3 vecScale = transform.localScale;

            float posX = Random.Range(_rndMinPosX, _rndMaxPosX);
            transform.position = new Vector3(posX, vecPos.y, vecPos.z);
            transform.localScale = new Vector3(-vecScale.x, vecScale.y, vecScale.z);

            Invoke("moveIntroPlayerRndPosX", _delayTime);
        }        
    }

    // �÷��̾� ��ġ �ʱ�ȭ
    public void initPlayerPosX()
    {
        if (_playUI.activeSelf == true)
        {
            Vector3 vec3 = transform.position;
            transform.position = new Vector3(_cfgMgr.getPlayerInitPosX(), _cfgMgr.getPlayerInitPosY(), vec3.z);

            // �÷��̾� �¿����
            Vector3 vecScale = transform.localScale;
            if (vecScale.x == -1.0f)
                transform.localScale = new Vector3(-vecScale.x, vecScale.y, vecScale.z);
        }
    }

    // �����߷� ����
    public void setRigidbodySimulate(bool val)
    {
        gameObject.GetComponent<Rigidbody2D>().simulated = val;
    }

    // �÷��̾� Die �̹����� ����
    public void changePlayerDieImg()
    {
        // Animator�� �����ϰ� SpriteRenderer sprite ����
        _ani = gameObject.GetComponent<Animator>();
        Destroy(_ani, 0.0f);

        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = Resources.LoadAll<Sprite>("Sprites/Player")[0];
    }

    // �÷��̾� Die �̹����� ����
    public void setTriggerDie()
    {
        // Die �ִϸ��̼��� �߰��ϰ� die Ʈ���� ����
        _ani = gameObject.GetComponent<Animator>();
        _ani.SetTrigger("die");
    }

}
