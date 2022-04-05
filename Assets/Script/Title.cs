using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // ???C?u??????????

    // ?J???p??????????

    public void GameStart()
    {
        FadeManager.Instance.LoadScene("VillageScene", 1f);
        SoundManager.instance.PlaySE(0);
    }
  
}
