using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    public ConfigManager _cfgMgr;
    public GameObject _playUI;

    public Text _txtStage;
    public ScoreManager _scMng;

    // Start is called before the first frame update
    void Start()
    {
        _cfgMgr    = FindObjectOfType<ConfigManager>();
        _scMng     = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        showStage();
    }

    // STAGE n 표기
    public void showStage()
    {

        // Debug.Log("showStage()");
        
        int gameScore = _scMng.getGameScore();
        int stage = 0;

        int remainder = gameScore % 10;
        int quotient  = (int)gameScore / 10;

        stage = quotient + 1;

        _txtStage = _playUI.transform.Find("TxtStage").GetComponent<Text>();
        _txtStage.text = "STAGE " + stage.ToString();

        if (remainder <= 1)
        {
            _playUI.transform.Find("TxtStage").gameObject.SetActive(true);
        }
        else
        {
            _playUI.transform.Find("TxtStage").gameObject.SetActive(false);
        }
    }

    // 특정 백그라운드 이동
    public void moveBackGround(GameObject gameObj)
    {
        Vector3 vec = gameObj.transform.position;
        string parentSetName = gameObj.transform.parent.name;

        if ( parentSetName.Equals("GroundSet") || parentSetName.Equals("SkySet") || parentSetName.Equals("CloudSet") || parentSetName.Equals("RockSet") )
        {
            float posX = vec.x + _cfgMgr.getDefaultBgImgWidth() * _cfgMgr.getDefaultBgImgCnt();
            gameObj.transform.position = new Vector3(posX, vec.y, vec.z);
        }

        /*
        // 배경Set별로 이동할 X좌표를 따로 처리할 경우
        if ( "GroundSet".Equals(parentSetName) )
        {    
            float posX = vec.x + _cfgMgr.getDefaultBgImgWidth() * _cfgMgr.getDefaultBgImgCnt();
            gameObj.transform.position = new Vector3(posX, vec.y, vec.z);
        }
        else if ("SkySet".Equals(parentSetName))
        {
            float posX = vec.x + _cfgMgr.getDefaultBgImgWidth() * _cfgMgr.getDefaultBgImgCnt();
            gameObj.transform.position = new Vector3(posX, vec.y, vec.z);
        }
        else if ("CloudSet".Equals(parentSetName))
        {
            float posX = vec.x + _cfgMgr.getDefaultBgImgWidth() * _cfgMgr.getDefaultBgImgCnt();
            gameObj.transform.position = new Vector3(posX, vec.y, vec.z);
        }
        else if ("RockSet".Equals(parentSetName))
        {
            float posX = vec.x + _cfgMgr.getDefaultBgImgWidth() * _cfgMgr.getDefaultBgImgCnt();
            gameObj.transform.position = new Vector3(posX, vec.y, vec.z);
        }
        */

    }

    // 선인장 랜덤위치 이동
    public void moveCactus(GameObject gameObj)
    {
        Vector3 vec = gameObj.transform.position;
        float minPosX = 9.0f;
        float maxPosX = 18.0f;
        float posX = vec.x + _cfgMgr.getDefaultBgImgWidth() * _cfgMgr.getDefaultBgImgCnt() + Random.Range(minPosX, maxPosX);

        Vector2 vec2 = gameObj.GetComponent<SpriteRenderer>().size;
        float minPosY = -(vec2.y / 2.0f);
        float maxPosY = 0.0f;
        float posY = Random.Range(minPosY, maxPosY);

        gameObj.transform.position = new Vector3(posX, posY, vec.z);
    }

    // 선인장 복사
    public void cloneCactus(GameObject gameObj)
    {
        // GameObject cloneObj = Instantiate(gameObj);
        // Destroy(gameObj);
    }




}
