using System.Collections;
using UnityEngine;

public class PunishmentCardScript : MonoBehaviour
{

    public Sprite[] cards;
    private SpriteRenderer rend;
    public static int whosTurn = 1;
    public static int punishmentCardNumber;
    private bool coroutineAllowed = true;


    // Use this for initialization
    private void Start()
    {
        whosTurn = 1;
        rend = GetComponent<SpriteRenderer>();
        cards = Resources.LoadAll<Sprite>("Cards/Punishment");
        rend.sprite = cards[0];
        gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        gameObject.SetActive(false);
        GameControl.rollDisabled = false;
        //Debug.Log("Punishment Given");
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

        punishmentCardNumber = randomCardSide;
        //Debug.Log("Card ID => " + punishmentCardNumber);
        //Debug.Log("Turn" + Dice.prevTurn);
        
        
        switch (punishmentCardNumber)
        {
            case 0:
                StartCoroutine(GameControl.SubtractPlayerScore(Dice.prevTurn, 400000));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 1:
                StartCoroutine(GameControl.SubtractPlayerScore(Dice.prevTurn, 100000));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 2:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) - 3));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 3:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) - 2));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 4:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) - 1));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 5:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) - 3));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 6:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) - 2));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 7:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) - 1));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 8:
                StartCoroutine(GameControl.SubtractPlayerScore(Dice.prevTurn, 500000));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 9:
                StartCoroutine(GameControl.SubtractPlayerScore(Dice.prevTurn, 500000));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 10:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) - 3));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 11:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) - 2));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 12:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) - 1));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 13:
                StartCoroutine(GameControl.SubtractPlayerScore(Dice.prevTurn, 100000));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 14:
                StartCoroutine(GameControl.SubtractPlayerScore(Dice.prevTurn, 200000));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 15:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) - 3));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 16:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) - 2));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 17:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) - 1));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 18:
                StartCoroutine(GameControl.SubtractPlayerScore(Dice.prevTurn, 100000));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 19:
                StartCoroutine(GameControl.SubtractPlayerScore(Dice.prevTurn, 500000));
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            default:
                Debug.Log("Punishment No. " + punishmentCardNumber);
                GetComponent<BoxCollider2D>().enabled = true;
                break;
        }

        coroutineAllowed = true;

    }
}
