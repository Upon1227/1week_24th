using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] Text CoinText;
    public static int coin;
    public static int scenecount;
    // Start is called before the first frame update
    void Start()
    {
        scenecount++;
        if(scenecount <= 1)
        {
            GetCoin(100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCoin(int coincaunt)
    {
        coin += coincaunt;
        CoinText.text = coin.ToString();
    }

    public void OutCoin(int coincaunt)
    {
        coin -= coincaunt;
        CoinText.text = coin.ToString();
    }
}
