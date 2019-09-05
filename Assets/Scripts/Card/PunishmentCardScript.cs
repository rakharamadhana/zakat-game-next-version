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
            randomCardSide = Random.Range(0, 19);
            //Debug.Log("=> " + randomCardSide);
            gameObject.GetComponent<SpriteRenderer>().sprite = cards[randomCardSide];
            //rend.sprite = cards[randomCardSide];
            yield return new WaitForSeconds(0.01f);
        }

        punishmentCardNumber = randomCardSide;
        Debug.Log("Card ID => " + punishmentCardNumber);
        GetComponent<BoxCollider2D>().enabled = true;

        if (punishmentCardNumber == 0)
        {
            Debug.Log("Kartu Punishment 1 nih");
        }
        else
        {
            Debug.Log("Bukan Kartu Punishment 1 nih tapi kartu " + punishmentCardNumber);
        }

        coroutineAllowed = true;

    }
}
