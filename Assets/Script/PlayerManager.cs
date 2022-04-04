using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public static Vector3 savemypotision = new Vector3(-3.5f,-3.4f,0);
    [SerializeField] GameObject HouseINPanel;
    public static int attackpoint;
    public static int defpoint;
    public static int hp;
    public static int publicenemynum;
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
    [SerializeField] Text EnemyLevText;
    public static float EnemyLev;
     bool isMove;
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "VillageScene")
        {
            transform.position = new Vector3(savemypotision.x,savemypotision.y - 0.5f,0);
        }
     
        attackpoint = (int)playerAttackdamage;
        hp = (int)playerhp;
        defpoint = (int)playerDefensepower;
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
        attackpoint = (int)playerAttackdamage;
        hp = (int)playerhp;
        defpoint = (int)playerDefensepower;
        enemyEventPanel.SetActive(false);
        FadeManager.Instance.LoadScene("BattleScene", 1.0f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "ExitHouse")
        {
            FadeManager.Instance.LoadScene("VillageScene", 1f);
        }
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
            savemypotision = transform.position;
            int enemynum = Random.Range(0, EnemyImageSelect.Length);
            EnemyImage.sprite = EnemyImageSelect[enemynum];
            EnemyEventText.text = EnemyName[enemynum] + "が現れた！";
            publicenemynum = enemynum;
            EnemyLev = Random.Range(1,11);
            EnemyLevText.text = (int)EnemyLev + "レベル";
            isMove = false;
            animator.SetInteger("Trans", 0);
            Debug.Log("敵に遭遇した");
            enemyEventPanel.SetActive(true);
        }
        if(collision.gameObject.tag == "House")
        {
            savemypotision = transform.position;
            animator.SetInteger("Trans", 0);
            isMove = false;
            HouseINPanel.SetActive(true);
        }
    }

    public void InHouse()
    {
        FadeManager.Instance.LoadScene("HouseLeftScene", 1f);
    }

    public void ExitHouse()
    {
        isMove = true;
        HouseINPanel.SetActive(false);
    }
}
