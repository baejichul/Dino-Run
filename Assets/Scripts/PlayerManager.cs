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


    // 플레이어 위치 랜덤변경
    public void moveIntroPlayerRndPosX()
    {   
        if (_introUI.activeSelf == true)
        {
            // scene 리로드 후 null 발생
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

    // 플레이어 위치 초기화
    public void initPlayerPosX()
    {
        if (_playUI.activeSelf == true)
        {
            Vector3 vec3 = transform.position;
            transform.position = new Vector3(_cfgMgr.getPlayerInitPosX(), _cfgMgr.getPlayerInitPosY(), vec3.z);

            // 플레이어 좌우반전
            Vector3 vecScale = transform.localScale;
            if (vecScale.x == -1.0f)
                transform.localScale = new Vector3(-vecScale.x, vecScale.y, vecScale.z);
        }
    }

    // 물리중력 제어
    public void setRigidbodySimulate(bool val)
    {
        gameObject.GetComponent<Rigidbody2D>().simulated = val;
    }

    // 플레이어 Die 이미지로 변경
    public void changePlayerDieImg()
    {
        // Animator를 제거하고 SpriteRenderer sprite 변경
        _ani = gameObject.GetComponent<Animator>();
        Destroy(_ani, 0.0f);

        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = Resources.LoadAll<Sprite>("Sprites/Player")[0];
    }

    // 플레이어 Die 이미지로 변경
    public void setTriggerDie()
    {
        // Die 애니메이션을 추가하고 die 트리거 생성
        _ani = gameObject.GetComponent<Animator>();
        _ani.SetTrigger("die");
    }

}
