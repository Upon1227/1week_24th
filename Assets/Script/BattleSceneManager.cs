using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSceneManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer EnemyImage;
    [SerializeField] Sprite[] EnemyImageSelect;
    [SerializeField] string[] EnemyName;
    [SerializeField] Text StartEventText;
    [SerializeField] Text statustext;
    [SerializeField] Image[] ButtonImage;
    [SerializeField] Text PlayerAttackPointText;
    [SerializeField] Text PlayerDefencePointText;
    [SerializeField] Text PlayerHPText;
    int PlayerHP;
    int EnemyLev = 1;
    int EnemyDef;
    [SerializeField] int EnemyHP;
    [SerializeField] Image shield;
    [SerializeField] Text shieldtext;
    bool isDef;
    bool isEnemyDef;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHP = PlayerManager.hp;
        PlayerHPText.text = "HP：" + PlayerHP;
        PlayerDefencePointText.text = "防御力：" + PlayerManager.defpoint;
        PlayerAttackPointText.text = "攻撃力：" + PlayerManager.attackpoint;
        EnemyHP = 100 * EnemyLev;
        Invoke("Myturn", 2f);
        EnemyImage.sprite = EnemyImageSelect[PlayerManager.publicenemynum];
        StartEventText.text = EnemyName[PlayerManager.publicenemynum] + "が現れた!!!";
    }

    void Myturn()
    {
        for (int i = 0; i < ButtonImage.Length; i++)
        {
            ButtonImage[i].color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
        }
        statustext.text = "あなたのターンです。内容を選んでください。";
    }

    public void PlayerAttack()
    {
        
        EnemyHP -= PlayerManager.attackpoint;
        EnemyTurn();
    }
    public void PlayerDefense()
    {
        isDef = true;
        EnemyTurn();
    }
    public void Exit()
    {
        FadeManager.Instance.LoadScene("", 1);
    }
    public void PlayerRecovery()
    {
        PlayerHP += 50;
        EnemyTurn();
    }


    void EnemyTurn()
    {
        for (int i = 0; i < ButtonImage.Length; i++)
        {
            ButtonImage[i].color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 50.0f / 255.0f);
        }
        int EnemyTurnNum = Random.Range(1, 7);
        switch (EnemyTurnNum)
        {
            case 1:
                Invoke("Attack", 1f);
                break;
            case 2:
                Invoke("Attack", 1f);
                break;
            case 3:
                Invoke("Attack", 1f);
                break;
            case 4:
                Invoke("SpecialAttack", 1f);
                break;
            case 5:
                Invoke("Defence", 1f);
                break;
            case 6:
                Invoke("Defense", 1f);
                break;
        }
    }

    void Attack()
    {
        if (isDef)
        {
            float EnemyAttackPoint = Random.Range(1, 5);
            int PlayerDamager = (int)EnemyAttackPoint * EnemyLev - (int)PlayerManager.defpoint;
            PlayerHP -= PlayerDamager;
            statustext.text = "敵は攻撃した." + PlayerDamager + "くらった";
            Myturn();
    
        }
        else
        {
            float EnemyAttackPoint = Random.Range(1, 5);
            PlayerHP -= (int)EnemyAttackPoint * EnemyLev;
            statustext.text = "敵は攻撃した." + (int)EnemyAttackPoint * EnemyLev + "くらった";
            Myturn();
        }

    }
    void Defense()
    {
        EnemyDef = Random.Range(1, 4) * EnemyLev;
        statustext.text = "敵は防御を選んだ." +"次の攻撃は-" + EnemyDef + "される";
        Myturn();
    }
    void SpecialAttack()
    {
        float EnemyAttackPoint = Random.Range(1, 5);
        float EnemySpecialAttackPoint = Random.Range(1, 4);
        PlayerHP -= (int)EnemyAttackPoint * EnemyLev * (int)EnemySpecialAttackPoint;
        statustext.text = "敵は特殊攻撃した." + (int)EnemyAttackPoint * EnemyLev * (int)EnemySpecialAttackPoint + "くらった";
        Myturn();
    }

}
