using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // シングルトン化
    public static SoundManager instance;

    //変数（SE格納用の配列）
    public AudioSource[] se;


    // SE再生用の関数

    private void Awake()
    {
      if(instance == null)
        {
            instance = this;
        }
      else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// SEを鳴らす(0:選択　1:回復 2:ゲームオーバー 3:被ダメ）
    /// </summary>
    /// <param name="x"></param>

    public void PlaySE(int x)
    {
        se[x].Stop();

        se[x].Play();
    }
   
}
