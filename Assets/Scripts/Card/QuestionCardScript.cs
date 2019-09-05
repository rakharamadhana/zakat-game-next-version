using System.Collections;
using UnityEngine;

public class QuestionCardScript : MonoBehaviour
{

    public Sprite[] cards;
    private SpriteRenderer rend;
    public static int whosTurn = 1;
    public static int questionCardNumber;
    private bool coroutineAllowed = true;


    // Use this for initialization
    private void Start()
    {
        whosTurn = 1;
        rend = GetComponent<SpriteRenderer>();
        cards = Resources.LoadAll<Sprite>("Cards/Question");
        rend.sprite = cards[0];
        gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        gameObject.SetActive(false);
        //Debug.Log("Question Answered");
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
            randomCardSide = Random.Range(0, 19);
            //Debug.Log("=> " + randomCardSide);
            gameObject.GetComponent<SpriteRenderer>().sprite = cards[randomCardSide];
            //rend.sprite = cards[randomCardSide];
            yield return new WaitForSeconds(0.01f);
        }

        questionCardNumber = randomCardSide;
        Debug.Log("Card ID => " + questionCardNumber);
        GetComponent<BoxCollider2D>().enabled = true;

        if (questionCardNumber == 0)
        {
            Debug.Log("Kartu Question 1 nih");
        }
        else
        {
            Debug.Log("Bukan Kartu Question 1 nih tapi kartu " + questionCardNumber);
        }

        coroutineAllowed = true;

    }
}
