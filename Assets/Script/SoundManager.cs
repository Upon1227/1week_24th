using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // �V���O���g����
    public static SoundManager instance;

    //�ϐ��iSE�i�[�p�̔z��j
    public AudioSource[] se;


    // SE�Đ��p�̊֐�

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
    /// SE��炷(0:�I���@1:�� 2:�Q�[���I�[�o�[ 3:��_���j
    /// </summary>
    /// <param name="x"></param>

    public void PlaySE(int x)
    {
        se[x].Stop();

        se[x].Play();
    }
   
}
