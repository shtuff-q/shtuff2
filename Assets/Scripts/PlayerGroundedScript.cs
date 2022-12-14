using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedScript : MonoBehaviour
{
    public bool isGrounded = false;
    public GameObject player;
    public bool isStarted = false;

    void Update()
    {
        if(isStarted == false)
        {
            StartCoroutine(AutoCheckCol());
        }

        player = GameObject.Find("Player");
        transform.position = player.transform.position;
        PlayerController pc = player.GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "ground")
        {
            isGrounded = true;
            //Debug.Log(isGrounded);
            //Debug.Log(col.name);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "ground" && gameObject.GetComponent<BoxCollider2D>().enabled == true)
        {
            isGrounded = false;
            //Debug.Log(isGrounded);
            //Debug.Log(col.name);
        }
    }

    IEnumerator AutoCheckCol()
    {
        isStarted = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return 0;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        isStarted = false;
    }
}
