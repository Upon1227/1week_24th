using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // ライブラリを追加

    // 遷移用関数を作成

    public void GameStart()
    {
        SceneManager.LoadScene("VillageScene");
        SoundManager.instance.PlaySE(0);
    }
  
}
