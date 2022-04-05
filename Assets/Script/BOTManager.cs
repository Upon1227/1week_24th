using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BOTManager : MonoBehaviour
{
    Animator anim;
    VillegeHumanManager villege;
    SpriteRenderer renderer;
    float countofsec;
    [SerializeField]int nextmove;
    [SerializeField] int movesec;
    bool isMoveFrag;
    [SerializeField] GameObject Fukidashi;
    [SerializeField] Text FukidashiText;
    [SerializeField] string[] FukidashiNaiyou;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        villege = GameObject.Find("villegemanager").GetComponent<VillegeHumanManager>();
        renderer = GetComponent<SpriteRenderer>();
        nextmove = 2;
        MoveTime();
    }

    // Update is called once per frame
    void Update()
    {

        if(renderer.isVisible == false)
        {
            Destroy(gameObject);
            villege.Bone();
        }
        switch (nextmove)
        {
            case 1:
                transform.position += new Vector3(0, 1f * Time.deltaTime, 0);
                if (isMoveFrag == false)
                {
                    StartCoroutine(Stop());
                    isMoveFrag = true;
                }
                anim.SetInteger("Trans", 1);
                break;
            case 2:
                transform.position += new Vector3(0, -1f * Time.deltaTime, 0);
                if(isMoveFrag == false)
                {
                    StartCoroutine(Stop());
                    isMoveFrag = true;
                }
                anim.SetInteger("Trans",3);
                break;
            case 3:
                transform.position += new Vector3(1f * Time.deltaTime, 0, 0);
                if (isMoveFrag == false)
                {
                    StartCoroutine(Stop());
                    isMoveFrag = true;
                }
                anim.SetInteger("Trans", 2);
                break;
            case 4:
                transform.position += new Vector3(-1f * Time.deltaTime, 0, 0);
                if (isMoveFrag == false)
                {
                    StartCoroutine(Stop());
                    isMoveFrag = true;
                }
                anim.SetInteger("Trans", 4);
                break;
            case 5:
                if (isMoveFrag == false)
                {
                    StartCoroutine(Stop());
                    isMoveFrag = true;
                }
                anim.SetInteger("Trans", 0);
                break;

        }

    }

    void MoveTime()
    {
         movesec = Random.Range(1, 3);
    }

    void IdleTime()
    {
        movesec = Random.Range(1, 3);
    }


    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.2f);
        yield return new WaitForSeconds(movesec);
        nextmove = 5;
        IdleTime();
        yield return new WaitForSeconds(movesec);
        nextmove = Random.Range(1, 6);
        isMoveFrag = false;
        MoveTime();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Fukidashi.activeSelf == false)
        {
            int FukidashiSelect = Random.Range(0, FukidashiNaiyou.Length);
            FukidashiText.text = FukidashiNaiyou[FukidashiSelect];
            Fukidashi.SetActive(true);
            StartCoroutine(Des());
        }
    }

    IEnumerator Des()
    {
        yield return new WaitForSeconds(2);
        Fukidashi.SetActive(false);
    }
}
