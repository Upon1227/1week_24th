using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmithManager : MonoBehaviour
{
    [SerializeField] GameObject SmithPanel;
    [SerializeField] GameObject BUKISelectPanel;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] GameObject BukiBuyPanel;
    [SerializeField] Text AttackText;
    [SerializeField] Text DefText;
    [SerializeField] Text CostText;
    [SerializeField] int a;
    [SerializeField] int d;
    public static bool isSYOKI;
    [SerializeField] GameObject WarningText;
    [SerializeField] GameObject WarningText2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BUKIOK()
    {
        SmithPanel.SetActive(false);
        BUKISelectPanel.SetActive(true);
    }

    public void BUKINO()
    {
        SmithPanel.SetActive(false);
        playerManager.MoveChangeTrue();
    }

    public void FirstSOUBI()
    {
        if(isSYOKI == false)
        {
            BukiBuyPanel.SetActive(true);
            AttackText.text = "攻撃力：＋１０";
            DefText.text = "防御力：＋０５";
            CostText.text = "コスト：３００";
            a = 10;
            d =  5;
            WarningText.SetActive(false);
            WarningText2.SetActive(false);
        }
        else
        {
            WarningText.SetActive(true);
            BukiBuyPanel.SetActive(false);
            WarningText2.SetActive(false);
        }


    }

    public void BUKIUP()
    {
        if (isSYOKI)
        {
            WarningText.SetActive(false);
            BukiBuyPanel.SetActive(true);
            AttackText.text = "攻撃力：＋３０";
            DefText.text = "防御力：＋００";
            CostText.text = "コスト：２００";
            a = 30;
            d = 0;
        }
        else
        {
            WarningText2.SetActive(true);
            WarningText.SetActive(false);
            BukiBuyPanel.SetActive(false);
        }

    }

    public void DefUP()
    {
        if (isSYOKI)
        {
            WarningText.SetActive(false);
            BukiBuyPanel.SetActive(true);
            AttackText.text = "攻撃力：＋００";
            DefText.text = "防御力：＋３０";
            CostText.text = "コスト：１５０";
            d = 30;
            a = 0;
        }
        else
        {
            WarningText2.SetActive(true);
            WarningText.SetActive(false);
            BukiBuyPanel.SetActive(false);
        }
    }

    public void buy()
    {
        if(isSYOKI == false)
        {
            isSYOKI = true;
        }
        BukiBuyPanel.SetActive(false);
        WarningText2.SetActive(false);
        WarningText.SetActive(false);
        int p = PlayerManager.attackpoint;
        int pd = PlayerManager.defpoint;
        PlayerManager.attackpoint = p + a;
        PlayerManager.defpoint = pd + d;
    }
    public void Re()
    {
        PlayerManager.hp = 200;
    }
}
