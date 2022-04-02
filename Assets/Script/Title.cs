using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // ƒ‰ƒCƒuƒ‰ƒŠ‚ğ’Ç‰Á

    // ‘JˆÚ—pŠÖ”‚ğì¬

    public void GameStart()
    {
        SceneManager.LoadScene("BattleScene");
        SoundManager.instance.PlaySE(0);
    }
  
}
