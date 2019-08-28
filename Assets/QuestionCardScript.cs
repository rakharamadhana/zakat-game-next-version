using System.Collections;
using UnityEngine;

public class QuestionCardScript : MonoBehaviour
{

    public Sprite[] cards;
    private SpriteRenderer rend;
    public static int whosTurn = 1;
    private bool coroutineAllowed = true;


    // Use this for initialization
    private void Start()
    {
        whosTurn = 1;
        rend = GetComponent<SpriteRenderer>();
        cards = Resources.LoadAll<Sprite>("Cards/Easy/Question");
        rend.sprite = cards[0];
    }

    public void RollCard()
    {
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheCard");
        GetComponent<AudioSource>().Play();
    }

    private IEnumerator RollTheCard()
    {
        coroutineAllowed = false;
        int randomCardSide = 0;
        for (int i = 0; i <= 40; i++)
        {
            randomCardSide = Random.Range(0, 19);
            rend.sprite = cards[randomCardSide];
            yield return new WaitForSeconds(0.01f);
        }

        Debug.Log("Card No." + (randomCardSide + 1));

        coroutineAllowed = true;

    }
}
