using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    private Animator diceAnim;
    private Sprite[] diceSides;
    private GameObject diceObject;
    private Text turn;
    private SpriteRenderer rend;
    private GameObject player1MoveValue, player2MoveValue, player3MoveValue, player4MoveValue;
    private GameObject player1, player2, player3, player4;

    private Text turnText;
    private int i;

    bool player1Moving, player2Moving, player3Moving, player4Moving, isMoving;
    public static int whosTurn = 1;
    public static int prevTurn = 1;
    private bool coroutineAllowed = true;

    // Use this for initialization
    private void Start()
    {
        whosTurn = 1;
        prevTurn = 1;

        turn = GameObject.Find("Turn").GetComponent<Text>();
        i = 1;
        turn.text = i.ToString();

        diceObject = GameObject.Find("DiceSprite");
        diceAnim = diceObject.GetComponent<Animator>();

        rend = diceObject.GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        player1MoveValue = GameObject.Find("Player1MoveValue");
        player2MoveValue = GameObject.Find("Player2MoveValue");
        player3MoveValue = GameObject.Find("Player3MoveValue");
        player4MoveValue = GameObject.Find("Player4MoveValue");
    }

    private void OnMouseDown()
    {
        player1Moving = player1.GetComponent<FollowThePath>().moveAllowed;
        player2Moving = player2.GetComponent<FollowThePath>().moveAllowed;
        player3Moving = player3.GetComponent<FollowThePath>().moveAllowed;
        player4Moving = player4.GetComponent<FollowThePath>().moveAllowed;

        if (player1Moving || player2Moving || player3Moving || player4Moving)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (!GameControl.gameOver && coroutineAllowed && !isMoving)
        {
            i++;
            diceAnim.SetTrigger("Rotate");
            StartCoroutine("RollTheDice");
            GetComponent<AudioSource>().Play();
            turn.text = i.ToString();
        }
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.01f);
        }

        GameControl.diceSideThrown = randomDiceSide + 1;
        //randomDiceSide = 5;

        //SWITCH
        switch (GameControl.nofPlayers)
        {
            case 1:
                whosTurn = 1;
                prevTurn = 1;
                player1MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                player2MoveValue.GetComponent<Text>().text = "0";
                player3MoveValue.GetComponent<Text>().text = "0";
                player4MoveValue.GetComponent<Text>().text = "0";
                GameControl.MovePlayer(1);
                break;
            case 2:
                if (randomDiceSide == 5)
                {
                    if (whosTurn == 1)
                    {
                        whosTurn = 1;
                        prevTurn = 1;
                        player1MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player2MoveValue.GetComponent<Text>().text = "0";
                        player3MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(1);
                    }
                    else if (whosTurn == 2)
                    {
                        whosTurn = 2;
                        prevTurn = 2;
                        player2MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player1MoveValue.GetComponent<Text>().text = "0";
                        player3MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(2);
                    }
                    coroutineAllowed = true;
                }
                else
                {
                    if (whosTurn == 1)
                    {
                        prevTurn = 1;
                        whosTurn = 2;
                        player1MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player2MoveValue.GetComponent<Text>().text = "0";
                        player3MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(1);

                    }
                    else if (whosTurn == 2)
                    {
                        prevTurn = 2;
                        whosTurn = 1;
                        player2MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player1MoveValue.GetComponent<Text>().text = "0";
                        player3MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(2);

                    }
                }
                break;
            case 3:
                if (randomDiceSide == 5)
                {
                    if (whosTurn == 1)
                    {
                        whosTurn = 1;
                        prevTurn = 1;
                        player1MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player2MoveValue.GetComponent<Text>().text = "0";
                        player3MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(1);
                    }
                    else if (whosTurn == 2)
                    {
                        whosTurn = 2;
                        prevTurn = 2;
                        player2MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player1MoveValue.GetComponent<Text>().text = "0";
                        player3MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(2);

                    }else if(whosTurn == 3){
                        whosTurn = 3;
                        prevTurn = 3;
                        player3MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player2MoveValue.GetComponent<Text>().text = "0";
                        player1MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(3);
                    }
                    coroutineAllowed = true;
                }
                else
                {
                    if (whosTurn == 1)
                    {
                        prevTurn = 1;
                        whosTurn = 2;
                        player1MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player2MoveValue.GetComponent<Text>().text = "0";
                        player3MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(1);

                    }
                    else if (whosTurn == 2)
                    {
                        prevTurn = 2;
                        whosTurn = 3;
                        player2MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player1MoveValue.GetComponent<Text>().text = "0";
                        player3MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(2);
                    }
                    else if(whosTurn == 3)
                    {
                        prevTurn = 3;
                        whosTurn = 1;
                        player3MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player2MoveValue.GetComponent<Text>().text = "0";
                        player1MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(3);
                    }
                }
                break;
            case 4:
                if (randomDiceSide == 5)
                {
                    if (whosTurn == 1)
                    {
                        whosTurn = 1;
                        prevTurn = 1;
                        player1MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player2MoveValue.GetComponent<Text>().text = "0";
                        player3MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(1);
                    }
                    else if (whosTurn == 2)
                    {
                        whosTurn = 2;
                        prevTurn = 2;
                        player2MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player1MoveValue.GetComponent<Text>().text = "0";
                        player3MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(2);
                    }
                    else if(whosTurn == 3)
                    {
                        whosTurn = 3;
                        prevTurn = 3;
                        player3MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player2MoveValue.GetComponent<Text>().text = "0";
                        player1MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(3);
                    }
                    else if(whosTurn == 4){
                        whosTurn = 4;
                        prevTurn = 4;
                        player4MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player2MoveValue.GetComponent<Text>().text = "0";
                        player3MoveValue.GetComponent<Text>().text = "0";
                        player1MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(4);
                    }
                    coroutineAllowed = true;
                }
                else
                {
                    if (whosTurn == 1)
                    {
                        prevTurn = 1;
                        whosTurn = 2;
                        player1MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player2MoveValue.GetComponent<Text>().text = "0";
                        player3MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(1);

                    }
                    else if (whosTurn == 2)
                    {
                        prevTurn = 2;
                        whosTurn = 3;
                        player2MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player1MoveValue.GetComponent<Text>().text = "0";
                        player3MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(2);
                    }
                    else if(whosTurn == 3)
                    {
                        prevTurn = 3;
                        whosTurn = 4;
                        player3MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player2MoveValue.GetComponent<Text>().text = "0";
                        player1MoveValue.GetComponent<Text>().text = "0";
                        player4MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(3);
                    }
                    else if(whosTurn == 4)
                    {
                        prevTurn = 4;
                        whosTurn = 1;
                        player4MoveValue.GetComponent<Text>().text = GameControl.diceSideThrown.ToString();
                        player2MoveValue.GetComponent<Text>().text = "0";
                        player3MoveValue.GetComponent<Text>().text = "0";
                        player1MoveValue.GetComponent<Text>().text = "0";
                        GameControl.MovePlayer(4);
                    }
                }
                break;
            

        }
        //END SWITCH

        /*  if (randomDiceSide == 5)
         {
             if (whosTurn == 1)
             {
                 whosTurn = 1;
                 GameControl.MovePlayer(1);
             }
             else if (whosTurn == 2)
             {
                 whosTurn = 2;
                 GameControl.MovePlayer(2);
             }
             coroutineAllowed = true;
         }
         else
         {
             if (whosTurn == 1)
             {
                 whosTurn = 2;
                 GameControl.MovePlayer(1);

             }
             else if (whosTurn == 2)
             {
                 whosTurn = 1;
                 GameControl.MovePlayer(2);

             }
         } */

        //
        //if 6 on the Dice
        /*         if (randomDiceSide == 5)
                {
                    for (int i = 1; i < 2; i++)
                    {
                        if (whosTurn == i)
                        {
                            GameControl.MovePlayer(i);
                            whosTurn = i;
                        }
                        else if (whosTurn == GameControl.nofPlayers)
                        {
                            GameControl.MovePlayer(GameControl.nofPlayers);
                            whosTurn = GameControl.nofPlayers;
                        }
                    }
                }
                else{
                //if 1 to 5 on Dice

                for (int i = 1; i < 2; i++)
                {
                    if (whosTurn == GameControl.nofPlayers)
                    {
                        GameControl.MovePlayer(GameControl.nofPlayers);
                        whosTurn = 1;
                        Debug.Log("this happens");
                    } 
                    else if (whosTurn == i)
                    {
                        Debug.Log("is this?");
                        GameControl.MovePlayer(i);
                        whosTurn = i + 1;
                    }
                }
                } */

        //Debug.Log(whosTurn);
        coroutineAllowed = true;

    }
}
