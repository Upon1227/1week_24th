using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // ���C�u������ǉ�

    // �J�ڗp�֐����쐬

    public void GameStart()
    {
        SceneManager.LoadScene("BattleScene");
        SoundManager.instance.PlaySE(0);
    }
  
}
