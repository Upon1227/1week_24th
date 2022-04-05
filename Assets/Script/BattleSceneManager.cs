using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleSceneManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip attacksound;
    [SerializeField] AudioClip DefSound;
    [SerializeField] AudioClip ReSound;
    [SerializeField] AudioClip ExitSound;
    [SerializeField] AudioClip SpAttackSound;

    [SerializeField] GameObject EffectCut;
    [SerializeField] GameObject EffectDamage;
    [SerializeField] GameObject EffectRecover;

    [SerializeField] Text EnemyHPText;
    [SerializeField] Text EnemyLevText;
    [SerializeField] Text EnemyDefText;
    [SerializeField] SpriteRenderer EnemyImage;
    [SerializeField] Sprite[] EnemyImageSelect;
    [SerializeField] string[] EnemyName;
    [SerializeField] Text StartEventText;
    [SerializeField] Text statustext;
    [SerializeField] Image[] ButtonImage;
    [SerializeField] Text PlayerAttackPointText;
    [SerializeField] Text PlayerDefencePointText;
    [SerializeField] Text PlayerHPText;
    [SerializeField] GameObject EnemyStatusPanel;
    int PlayerHP;
    int EnemyLev = 1;
    int EnemyDef;
    [SerializeField] int EnemyHP;
    [SerializeField] Image shield;
    [SerializeField] Text shieldtext;
    bool isDef;
    bool isEnemyDef;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Enemy;
    bool isMyTrun;
    // Start is called before the first frame update
    void Start()
    {
        EnemyLev = (int)PlayerManager.EnemyLev;
        Player.transform.DOMove(new Vector3(-3, 1.1f, 0), 1);
        Enemy.transform.DOMove(new Vector3(3, 1.1f, 0), 1);
        PlayerHP = PlayerManager.hp;
        PlayerHPText.text = "HP：" + PlayerHP;
        PlayerDefencePointText.text = "防御力：" + PlayerManager.defpoint;
        PlayerAttackPointText.text = "攻撃力：" + PlayerManager.attackpoint;
        EnemyHP = 100 * EnemyLev;
        Invoke("Myturn", 2f);
        EnemyImage.sprite = EnemyImageSelect[PlayerManager.publicenemynum];
        StartEventText.text = EnemyName[PlayerManager.publicenemynum] + "が現れた!!!";
        EnemyHPText.text = "HP：" + EnemyHP;
        Invoke("ActivePanel", 1.5f);
        EnemyLevText.text = "Lev：" + EnemyLev;
    }

    void ActivePanel()
    {
        EnemyStatusPanel.SetActive(true);
    }

    

    void Myturn()
    {
        for (int i = 0; i < ButtonImage.Length; i++)
        {
            ButtonImage[i].color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
        }
        statustext.text = "あなたのターンです。内容を選んでください。";
        isMyTrun = true;
    }

    public void PlayerAttack()
    {
        if (isMyTrun)
        {
            if (isEnemyDef)
            {
                Enemy.transform.DOShakePosition(0.5f, 1);
                int Attack = PlayerManager.attackpoint + EnemyDef;
                if(Attack > 0)
                {
                    EnemyHP -= Attack;
                    audioSource.PlayOneShot(attacksound);
                }
                
                EnemyTurn();
                isMyTrun = false;
                EnemyHPText.text = "HP：" + EnemyHP;
                isEnemyDef = false;
            }
            else
            {
                audioSource.PlayOneShot(attacksound);
                Enemy.transform.DOShakePosition(0.5f, 1);
                EnemyHP -= PlayerManager.attackpoint;
                EnemyTurn();
                isMyTrun = false;
                EnemyHPText.text = "HP：" + EnemyHP;            
            }

        }

    }
    public void PlayerDefense()
    {
        if (isMyTrun)
        {
            isDef = true;
            EnemyTurn();
            isMyTrun = false;
            audioSource.PlayOneShot(DefSound);
        }
    }
    public void Exit()
    {
        if (isMyTrun)
        {
            audioSource.PlayOneShot(ExitSound);
            FadeManager.Instance.LoadScene("VillageScene", 1);
            isMyTrun = false;
        }
    }
    public void PlayerRecovery()
    {
        if (isMyTrun)
        {
            audioSource.PlayOneShot(ReSound);
            PlayerHP += 50;
            EnemyTurn();
            PlayerHPText.text = "HP：" + PlayerHP;
            isMyTrun = false;
        }
    }


    void EnemyTurn()
    {
        for (int i = 0; i < ButtonImage.Length; i++)
        {
            ButtonImage[i].color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 50.0f / 255.0f);
        }
        EnemyDefText.text = "";
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
                Invoke("Defense", 1f);
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
            float EnemyAttackPoint = Random.Range(1, 8);
            int PlayerDamager = (int)EnemyAttackPoint * EnemyLev - (int)PlayerManager.defpoint;
            if(PlayerDamager > 0)
            {
                audioSource.PlayOneShot(attacksound);
                PlayerHP -= PlayerDamager;
            }


            statustext.text = "敵は攻撃した." + PlayerDamager + "くらった";
            Myturn();
    
        }
        else
        {
            audioSource.PlayOneShot(attacksound);
            float EnemyAttackPoint = Random.Range(1, 8);
            PlayerHP -= (int)EnemyAttackPoint * EnemyLev;
            statustext.text = "敵は攻撃した." + (int)EnemyAttackPoint * EnemyLev + "くらった";
            Myturn();
        }
        Player.transform.DOShakePosition(0.5f, 1);
        PlayerHPText.text = "HP：" + PlayerHP;
    }
    void Defense()
    {
        audioSource.PlayOneShot(DefSound);
        EnemyDef = Random.Range(1, 4) * EnemyLev;
        statustext.text = "敵は防御を選んだ." +"次の攻撃は-" + EnemyDef + "される";
        EnemyDefText.text = "防御中,防御力：" + EnemyDef;
        isEnemyDef = true;
        Myturn();
    }
    void SpecialAttack()
    {
        audioSource.PlayOneShot(SpAttackSound);
        float EnemyAttackPoint = Random.Range(1, 5);
        float EnemySpecialAttackPoint = Random.Range(1, 4);
        PlayerHP -= (int)EnemyAttackPoint * EnemyLev * (int)EnemySpecialAttackPoint;
        statustext.text = "敵は特殊攻撃した." + (int)EnemyAttackPoint * EnemyLev * (int)EnemySpecialAttackPoint + "くらった";
        Myturn();
        Player.transform.DOShakePosition(0.5f, 1);
    }

}
