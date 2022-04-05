using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOTManager : MonoBehaviour
{
    VillegeHumanManager villege;
    SpriteRenderer renderer;
    float countofsec;
    [SerializeField]int nextmove;
    [SerializeField] int movesec;
    bool isMoveFrag;
    // Start is called before the first frame update
    void Start()
    {
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

                break;
            case 2:
                transform.position += new Vector3(0, -1f * Time.deltaTime, 0);
                if(isMoveFrag == false)
                {
                    StartCoroutine(Stop());
                    isMoveFrag = true;
                }

                break;
            case 3:
                transform.position += new Vector3(1f * Time.deltaTime, 0, 0);
                if (isMoveFrag == false)
                {
                    StartCoroutine(Stop());
                    isMoveFrag = true;
                }

                break;
            case 4:
                transform.position += new Vector3(1f * Time.deltaTime, 0, 0);
                if (isMoveFrag == false)
                {
                    StartCoroutine(Stop());
                    isMoveFrag = true;
                }
                break;
            case 5:
                if (isMoveFrag == false)
                {
                    StartCoroutine(Stop());
                    isMoveFrag = true;
                }
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
}
