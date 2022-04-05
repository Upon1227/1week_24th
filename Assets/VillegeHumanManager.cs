using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillegeHumanManager : MonoBehaviour
{
    [SerializeField] GameObject[] BonePoint;
    [SerializeField] GameObject[] Human;
    // Start is called before the first frame update
    void Start()
    {
        int BoneCount = Random.Range(1, BonePoint.Length);
        for(int i = 0;i <= BoneCount; i++)
        {
            int humanselect = Random.Range(0, Human.Length);
            Instantiate(Human[humanselect], BonePoint[i].transform.position,Quaternion.identity);
        }
    }

   public void Bone()
    {
        int BoneCount = Random.Range(1, BonePoint.Length);
        int humanselect = Random.Range(0, Human.Length);
        Instantiate(Human[humanselect], BonePoint[BoneCount].transform.position, Quaternion.identity);
     
    }
}
