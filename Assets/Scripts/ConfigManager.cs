using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    private const float _playerInitPosX = -3.5f;         // �÷��̾� ���� X��ǥ
    private const float _playerInitPosY = 0.0f;          // �÷��̾� ���� Y��ǥ

    private float _playerJumpForce = 10.0f;              // �÷��̾� ������ ��
    private float _playerJumpLimit = 5.0f;               // �÷��̾� ������ ����
    private const float _playerJumpLimitPosY = 2.0f;     // �÷��̾� ������ Y��ǥ ����

    private const float _playerMovePower   = 0.01f;      // �÷��̾� �¿� �̵��� ��
    private const float _playerMinMovePosX = -4.0f;      // �÷��̾� �¿� �̵��� �ּ� X��ǥ
    private const float _playerMaxMovePosX = 4.5f;       // �÷��̾� �¿� �̵��� �ִ� X��ǥ

    // ���
    private const int _defaultBgImgWidth = 3;            // ��� �̹����� Default Width
    private const int _defaultBgImgCnt   = 5;            // ��� �̹����� ����

    // ȭ�齺ũ�� X��ǥ
    private const int _skyGroundLastPosX = -6;           // Sky, Ground��� �̹����� ���� X��ǥ
    private const int _cloudRockLastPosX = -3;           // Cloud, Rock��� �̹����� ���� X��ǥ

    private const float _skySpeedPosx    = 0.5f;       // Sky X��ǥ �̵� ���ǵ�
    private const float _cloudSpeedPosx  = 0.2f;       // Cloud X��ǥ �̵� ���ǵ�
    private const float _rockSpeedPosx   = 0.1f;       // Rock X��ǥ �̵� ���ǵ�
    private const float _groundSpeedPosx = 1.0f;        // Ground X��ǥ �̵� ���ǵ�

    // ��ֹ�(������)
    private const int _cactusLastPosX = -5;              // Cactus ���� X��ǥ
    private const float _cactusSpeedPosx = 0.5f;        // Cactus X��ǥ �̵� ���ǵ�

    private const int _basicObtainScore = 1;             // �⺻ȹ������
    private const float _invokeBasicTime = 1.0f;         // Invoke�Լ� �⺻���� �ð�

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
