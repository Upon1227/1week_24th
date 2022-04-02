using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] float playerspeed;
    [SerializeField] float playerhp;
    [SerializeField] float playerAttackdamage;
    [SerializeField] float playerDefensepower;
    [SerializeField] collegeManager collegemanager;
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

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0,playerspeed * Time.deltaTime,0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(playerspeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-playerspeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -playerspeed * Time.deltaTime, 0);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Human")
        {
            //村人の嘘か真かを見分けるところ
            if(collision.gameObject.name == "liehuman")
            {
                collegemanager.LieHumanEvent();
            }
            else if(collision.gameObject.name == "purehuman")
            {
                collegemanager.PureHumanEvent();
            }
        }
    }
}
