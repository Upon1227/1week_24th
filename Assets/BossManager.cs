using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
　public void OnBattle()
    {
        PlayerManager.publicenemynum = 5;
        PlayerManager.EnemyLev = 20;
        PlayerManager.scenenum = 3;
        FadeManager.Instance.LoadScene("BattleScene", 1.0f);
    }

    public void ExitBattle()
    {
        FadeManager.Instance.LoadScene("VillageScene", 1);
    }
}
