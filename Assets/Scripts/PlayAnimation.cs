using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    Animator anim;
    public int player;

    private int whosTurn;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        whosTurn = Dice.whosTurn;
        //Debug.Log(whosTurn);
        //Debug.Log(player);
        if (whosTurn == player)
        {
            anim.enabled = true;
        }
        else
        {
            anim.enabled = false;
        }
    }
}
