using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceAnimation : MonoBehaviour
{
    Animator anim;
    GameObject player1, player2, player3, player4;

    bool player1Moving, player2Moving, player3Moving, player4Moving, isMoving;

    private int whosTurn;
    private int transparentColor;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();        
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");
    }

    // Update is called once per frame
    void Update()
    {
        player1Moving = player1.GetComponent<FollowThePath>().moveAllowed;
        player2Moving = player2.GetComponent<FollowThePath>().moveAllowed;
        player3Moving = player3.GetComponent<FollowThePath>().moveAllowed;
        player4Moving = player4.GetComponent<FollowThePath>().moveAllowed;

        whosTurn = Dice.whosTurn;
        //Debug.Log(whosTurn);
        //Debug.Log(player);
        if (player1Moving || player2Moving || player3Moving || player4Moving)
        {
            Wait(1);
            this.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            anim.enabled = false;
        }
        else
        {
            this.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            anim.enabled = true;
        }
    }

    private IEnumerator Wait(int time)
    {
        yield return new WaitForSeconds(time);
    }
}
