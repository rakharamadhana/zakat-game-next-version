using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    Animator anim;
    GameObject player1, player2, player3, player4;

    bool player1Moving, player2Moving, player3Moving, player4Moving, isMoving;
    public int player;

    private int whosTurn;

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

        if (player == 1)
        {
            isMoving = player1Moving;
        }

        if (player == 2)
        {
            isMoving = player2Moving;
        }

        if (player == 3)
        {
            isMoving = player3Moving;
        }

        if (player == 4)
        {
            isMoving = player4Moving;
        }

        whosTurn = Dice.whosTurn;
        //Debug.Log(whosTurn);
        //Debug.Log(player);
        if (whosTurn == player)
        {
            anim.enabled = true;

            if (isMoving)
            {            
                //anim.SetBool("Jumping", true);
                //Debug.Log("Player" + whosTurn + "isMoving => " + isMoving);
            }
            else
            {
                //anim.SetBool("Jumping", false);
                //Debug.Log("Player" + whosTurn + "isMoving => " + isMoving);
            }
            
            
        }
        else
        {
            //Debug.Log(whosTurn);
            Wait(3);
            //anim.SetBool("Jumping", false);
            anim.enabled = false;
        }
    }

    private IEnumerator Wait(int time)
    {
        yield return new WaitForSeconds(time);
    }
}
