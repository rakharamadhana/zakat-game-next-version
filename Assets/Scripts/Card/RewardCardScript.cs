using System.Collections;
using UnityEngine;

public class RewardCardScript : MonoBehaviour
{

    public Sprite[] cards;
    private SpriteRenderer rend;
    public static int rewardCardNumber;
    private bool coroutineAllowed = true;


    // Use this for initialization
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        cards = Resources.LoadAll<Sprite>("Cards/Reward");
        rend.sprite = cards[0];
        gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        gameObject.SetActive(false);
        GameControl.rollDisabled = false;
        //Debug.Log("Reward Given");
    }

    public void RollCard()
    {
        GameControl.rollDisabled = true;
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheCard");
        AudioManager.instance.PlaySound("Rolling Card", Vector3.zero);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private IEnumerator RollTheCard()
    {
        coroutineAllowed = false;
        int randomCardSide = 0;
        for (int i = 0; i <= 30; i++)
        {
            randomCardSide = Random.Range(0, 19);
            //Debug.Log("=> " + randomCardSide);
            gameObject.GetComponent<SpriteRenderer>().sprite = cards[randomCardSide];
            //rend.sprite = cards[randomCardSide];
            yield return new WaitForSeconds(0.01f);
        }

        rewardCardNumber = randomCardSide;
        //Debug.Log("Card ID => " + rewardCardNumber);
        //Debug.Log("Turn" + Dice.prevTurn);
        
        
        switch (rewardCardNumber)
        {
            case 0:
                StartCoroutine(GameControl.AddPlayerScore(Dice.prevTurn, 400000));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 1:
                StartCoroutine(GameControl.AddPlayerScore(Dice.prevTurn, 11700000));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 2:
                StartCoroutine(GameControl.AddPlayerScore(Dice.prevTurn, 750000));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 3:
                StartCoroutine(GameControl.AddPlayerScore(Dice.prevTurn, 9500000));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 4:
                StartCoroutine(GameControl.AddPlayerScore(Dice.prevTurn, 4875000));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 5:
                StartCoroutine(GameControl.AddPlayerScore(Dice.prevTurn, 400000));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 6:
                StartCoroutine(GameControl.AddPlayerScore(Dice.prevTurn, 400000));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 7:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) + 1));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 8:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) + 2));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 9:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) + 3));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 10:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) + 2));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 11:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) + 3));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 12:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) + 1));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 13:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) + 2));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 14:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) + 3));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 15:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) + 2));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 16:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) + 3));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 17:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) + 1));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 18:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) + 2));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 19:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) + 3));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            default:
                Debug.Log("Reward No. " + rewardCardNumber);
                GetComponent<BoxCollider2D>().enabled = true;
                break;
        }

        coroutineAllowed = true;

    }
}
