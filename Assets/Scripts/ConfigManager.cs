using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    private const float _playerInitPosX = -3.5f;         // 플레이어 최초 X좌표
    private const float _playerInitPosY = 0.0f;          // 플레이어 최초 Y좌표

    private float _playerJumpForce = 10.0f;              // 플레이어 점프시 힘
    private float _playerJumpLimit = 5.0f;               // 플레이어 점프시 제한
    private const float _playerJumpLimitPosY = 2.0f;     // 플레이어 점프시 Y좌표 제한

    private const float _playerMovePower   = 0.01f;      // 플레이어 좌우 이동시 힘
    private const float _playerMinMovePosX = -4.0f;      // 플레이어 좌우 이동시 최소 X좌표
    private const float _playerMaxMovePosX = 4.5f;       // 플레이어 좌우 이동시 최대 X좌표

    // 배경
    private const int _defaultBgImgWidth = 3;            // 배경 이미지의 Default Width
    private const int _defaultBgImgCnt   = 5;            // 배경 이미지의 개수

    // 화면스크롤 X좌표
    private const int _skyGroundLastPosX = -6;           // Sky, Ground배경 이미지의 최종 X좌표
    private const int _cloudRockLastPosX = -3;           // Cloud, Rock배경 이미지의 최종 X좌표

    private const float _skySpeedPosx    = 0.5f;       // Sky X좌표 이동 스피드
    private const float _cloudSpeedPosx  = 0.2f;       // Cloud X좌표 이동 스피드
    private const float _rockSpeedPosx   = 0.1f;       // Rock X좌표 이동 스피드
    private const float _groundSpeedPosx = 1.0f;        // Ground X좌표 이동 스피드

    // 장애물(선인장)
    private const int _cactusLastPosX = -5;              // Cactus 최종 X좌표
    private const float _cactusSpeedPosx = 0.5f;        // Cactus X좌표 이동 스피드

    private const int _basicObtainScore = 1;             // 기본획득점수
    private const float _invokeBasicTime = 1.0f;         // Invoke함수 기본실행 시간

    public float getPlayerInitPosX()
    {
        return _playerInitPosX;
    }

    public float getPlayerInitPosY()
    {
        return _playerInitPosY;
    }

    public float getPlayerJumpForce()
    {
        return _playerJumpForce;
    }

    public void setPlayerJumpForce(float val)
    {
        _playerJumpForce = val;
    }

    public float getPlayerJumpLimit()
    {
        return _playerJumpLimit;
    }

    public void setPlayerJumpLimit(float val)
    {
        _playerJumpLimit = val;
    }

    public float getPlayerJumpLimitPosY()
    {
        return _playerJumpLimitPosY;
    }

    public int getDefaultBgImgWidth()
    {
        return _defaultBgImgWidth;
    }

    public int getDefaultBgImgCnt()
    {
        return _defaultBgImgCnt;
    }

    public int getSkyGroundLastPosX()
    {
        return _skyGroundLastPosX;
    }

    public int getCloudRockLastPosX()
    {
        return _cloudRockLastPosX;
    }

    public float getSkySpeedPosx()
    {
        return _skySpeedPosx;
    }

    public float getCloudSpeedPosx()
    {
        return _cloudSpeedPosx;
    }

    public float getRockSpeedPosx()
    {
        return _rockSpeedPosx;
    }

    public float getGroundSpeedPosx()
    {
        return _groundSpeedPosx;
    }

    public int getCactusLastPosx()
    {
        return _cactusLastPosX;
    }

    public float getCactusSpeedPosx()
    {
        return _cactusSpeedPosx;
    }

    public int getBasicObtainScore()
    {
        return _basicObtainScore;
    }

    public float getPlayerMovePower()
    {
        return _playerMovePower;
    }

    public float getPlayerMinMovePosX()
    {
        return _playerMinMovePosX;
    }

    public float getPlayerMaxMovePosX()
    {
        return _playerMaxMovePosX;
    }

    public float getInvokeBasicTime()
    {
        return _invokeBasicTime;
    }


}
