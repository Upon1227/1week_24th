using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyEnemyManager : MonoBehaviour
{
    [SerializeField] int MaxX;
    [SerializeField] int minX;
    [SerializeField] int MaxY;
    [SerializeField] int minY;
    // Start is called before the first frame update
    void Start()
    {
        if(BattleSceneManager.Key == 1)
        {
            Destroy(gameObject);
        }
        int X = Random.Range(minX,MaxX + 1);
        int Y = Random.Range(minY, MaxY + 1);
        if(SceneManager.GetActiveScene().name == "GrasslandScene")
        {
            transform.position = new Vector3(X, Y, 0);
        }
        else if(SceneManager.GetActiveScene().name == "ForestScene")
        {
            transform.position = new Vector3(X, Y, 0);
        }

    }


}
