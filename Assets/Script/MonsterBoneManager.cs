using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoneManager : MonoBehaviour
{
    
    [SerializeField] GameObject EnemyEventPoint;
    [SerializeField] int enemycount;
    [SerializeField] int XRangeMax;
    [SerializeField] int XRangeMin;
    [SerializeField] int YRangeMax;
    [SerializeField] int YRangeMin;
    [SerializeField] GameObject[] Enemy;
    // Start is called before the first frame update
    void Start()
    {
        EnemyBone();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyBone()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0;i < Enemy.Length; i++)
        {
            Destroy(Enemy[i]);
        }
        for (int i = 0; i < enemycount; i++)
        {
            int X = Random.Range(XRangeMin, XRangeMax);
            int Y = Random.Range(YRangeMin, YRangeMax);
            GameObject Enemy = Instantiate(EnemyEventPoint, new Vector3(X, Y, 0), Quaternion.identity);
            Enemy.tag = "Enemy";
        }
    }
}
