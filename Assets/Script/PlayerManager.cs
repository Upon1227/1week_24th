using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    [SerializeField] Text EnemyEventText;
    [SerializeField] string[] EnemyName;
    [SerializeField] Image EnemyImage;
    [SerializeField] Sprite[] EnemyImageSelect;
    [SerializeField] Animator animator;
    [SerializeField] GameObject enemyEventPanel;
    [SerializeField] GameObject Playerstatuspanel;
    [SerializeField] Text hpt;
    [SerializeField] Text attackpowert;
    [SerializeField] Text defensepowert;
    [SerializeField] float playerspeed;
    [SerializeField] float playerhp;
    [SerializeField] float playerAttackdamage;
    [SerializeField] float playerDefensepower;
    [SerializeField] collegeManager collegemanager;
    [SerializeField] MonsterBoneManager monsterBoneManager;
     bool isMove;
    void Start()
    {
        isMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //移動
        if(isMove == true)
        {
            Move();
        }
     
    }

    public void OnIconButton()
    {
        Playerstatuspanel.SetActive(true);
        hpt.text = "HP：" + playerhp;
        attackpowert.text = "攻撃力：" + playerAttackdamage;
        defensepowert.text = "防御力：" + playerDefensepower;
    }

    public void OnCloseStatus()
    {
        Playerstatuspanel.SetActive(false);
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetInteger("Trans", 1);
            transform.position += new Vector3(0,playerspeed * Time.deltaTime,0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("Trans", 2);
            transform.position += new Vector3(playerspeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("Trans", 4);
            transform.position += new Vector3(-playerspeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetInteger("Trans", 3);
            transform.position += new Vector3(0, -playerspeed * Time.deltaTime, 0);
        }
        else
        {
            animator.SetInteger("Trans", 0);
        }
        
    }

    public void MoveChangeTrue()
    {
        isMove = true;
    }
    public void MoveChangeFalse()
    {
        isMove = false;
    }
    public void EnemyEventExit()
    {
        isMove = true;
        monsterBoneManager.EnemyBone();
        enemyEventPanel.SetActive(false);
    }
    public void EnemyEventIn()
    {
        enemyEventPanel.SetActive(false);
        FadeManager.Instance.LoadScene("BattleScene", 1.0f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Human")
        {
            //村人の嘘か真かを見分けるところ
            if(collision.gameObject.name == "liehuman")
            {
                animator.SetInteger("Trans", 0);
                collegemanager.LieHumanEvent();
            }
            else if(collision.gameObject.name == "purehuman")
            {
                animator.SetInteger("Trans", 0);
                collegemanager.PureHumanEvent();
            }
        }
        if(collision.gameObject.tag == "Enemy")
        {
            int enemynum = Random.Range(0, 2);
            EnemyImage.sprite = EnemyImageSelect[enemynum];
            EnemyEventText.text = EnemyName[enemynum] + "が現れた！";
            isMove = false;
            animator.SetInteger("Trans", 0);
            Debug.Log("敵に遭遇した");
            enemyEventPanel.SetActive(true);
        }
    }
}
