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
        //Debug.Log("Punishment Given");
    }

    public void RollCard()
    {
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheCard");
        GetComponent<AudioSource>().Play();
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private IEnumerator RollTheCard()
    {
        coroutineAllowed = false;
        int randomCardSide = 0;
        for (int i = 0; i <= 30; i++)
        {
            randomCardSide = Random.Range(0, 4);
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
                
                break;
            case 1:
                StartCoroutine(GameControl.SubtractPlayerScore(Dice.prevTurn, 100000));
                break;
            case 2:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) - 3));
                break;
            case 3:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) - 2));
                break;
            case 4:
                GameControl.TransformPlayerPosition(Dice.prevTurn, (GameControl.returnPlayerIndex(Dice.prevTurn) - 1));
                break;
            default:
                break;
        }

        StartCoroutine(LateCall());

        coroutineAllowed = true;

    }

    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(3);

        GetComponent<BoxCollider2D>().enabled = true;
        //Do Function here...
    }
}
