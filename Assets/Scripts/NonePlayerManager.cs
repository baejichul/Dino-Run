using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonePlayerManager : MonoBehaviour
{
    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _endUI;

    public GameObject _flappy;
    public GameObject _frogletSet;

    public ConfigManager _cfgMgr;
    bool isFlappyFlyToRight = true;

    // Start is called before the first frame update
    void Start()
    {   
        _cfgMgr = FindObjectOfType<ConfigManager>();
        moveFrogletPosX();
    }

    // Update is called once per frame
    void Update()
    {
        moveIntroFlappyPosX();
    }


    // 인트로 화면 플래피버드 이동
    public void moveIntroFlappyPosX()
    {
        if (_introUI.activeSelf == true)
        {
            Transform tfm = transform.Find("Flappy").transform;

            Vector3 vecPos = tfm.position;
            Vector3 vecScale = tfm.localScale;

            float minPosX = _cfgMgr.getPlayerMinMovePosX();
            float maxPosX = _cfgMgr.getPlayerMaxMovePosX();
            float nowPosX = vecPos.x;
            // Debug.Log(nowPosX + " : " + minPosX + " : " + maxPosX);

            if (nowPosX <= minPosX)
                isFlappyFlyToRight = true;

            if (nowPosX >= maxPosX)
                isFlappyFlyToRight = false;


            if (isFlappyFlyToRight)
            {
                tfm.localScale = new Vector3(1, vecScale.y, vecScale.z);
                tfm.Translate(_cfgMgr.getGroundSpeedPosx() * Time.deltaTime, 0, 0);
            }
            else
            {
                tfm.localScale = new Vector3(-1, vecScale.y, vecScale.z);
                tfm.Translate(-_cfgMgr.getGroundSpeedPosx() * Time.deltaTime, 0, 0);
            }
        }
    }

    // 인트로 화면 프로그 이동
    public void moveFrogletPosX()
    {
        if (_introUI.activeSelf == true)
        {
            Transform tfm = transform.Find("FrogletSet").transform;

            float _rndMinPosX = _cfgMgr.getPlayerMinMovePosX();
            float _rndMaxPosX = _cfgMgr.getPlayerMaxMovePosX();
            float _delayTime = _cfgMgr.getInvokeBasicTime();

            Vector3 vecBlue = tfm.Find("FrogletBlue").transform.position;
            Vector3 vecGreen = tfm.Find("FrogletGreen").transform.position;
            Vector3 vecPink = tfm.Find("FrogletPink").transform.position;
            Vector3 vecYellow = tfm.Find("FrogletYellow").transform.position;

            float bluePosX = Random.Range(_rndMinPosX, _rndMaxPosX);
            float greenPosX = Random.Range(_rndMinPosX, _rndMaxPosX);
            float pinkPosX = Random.Range(_rndMinPosX, _rndMaxPosX);
            float yellowPosX = Random.Range(_rndMinPosX, _rndMaxPosX);

            tfm.Find("FrogletBlue").transform.position = new Vector3(bluePosX, vecBlue.y, vecBlue.z);
            tfm.Find("FrogletGreen").transform.position = new Vector3(greenPosX, vecGreen.y, vecGreen.z);
            tfm.Find("FrogletPink").transform.position = new Vector3(pinkPosX, vecPink.y, vecPink.z);
            tfm.Find("FrogletYellow").transform.position = new Vector3(yellowPosX, vecYellow.y, vecYellow.z);

            Invoke("moveFrogletPosX", _delayTime);
        }
    }

    public void setActive(bool val)
    {
        gameObject.SetActive(val);
    }
}
