using System.Collections;
using UnityEngine;

public class QuestionCardScript : MonoBehaviour
{
    public Sprite[] cards;
    private SpriteRenderer rend;
    public static int whosTurn = 1;
    public static int questionCardNumber;
    private bool coroutineAllowed = true;
    private bool yes, no;

    // Use this for initialization
    private void Start()
    {
        whosTurn = 1;
        rend = GetComponent<SpriteRenderer>();
        cards = Resources.LoadAll<Sprite>("Cards/Question");
        rend.sprite = cards[0];
        gameObject.SetActive(false);
    }

    private void Update()
    {
        //Debug.Log("yes =>" + yes);
        //Debug.Log("no =>" + no);
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
            randomCardSide = Random.Range(0, 49);
            //Debug.Log("=> " + randomCardSide);
            gameObject.GetComponent<SpriteRenderer>().sprite = cards[randomCardSide];
            //rend.sprite = cards[randomCardSide];
            yield return new WaitForSeconds(0.01f);
        }

        questionCardNumber = randomCardSide;
        //Debug.Log("Card ID => " + questionCardNumber);
        //Debug.Log("Turn" + Dice.prevTurn);
        coroutineAllowed = true;

    }

    public void onClickYes()
    {
        GameControl gameControl = GameObject.Find("GameControl").GetComponent<GameControl>();

        yes = true;
        no = false;

        
        switch (questionCardNumber)
        {
            case 0:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 1:
                if (yes)
                {
                    Debug.Log("Pernyataan "+ (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 2:
                if (yes)
                {
                    Debug.Log("Pernyataan "+ (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 3:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 4:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 5:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");                    
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 6:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 7:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 8:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 9:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 10:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 11:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 12:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 13:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 14:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 15:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 16:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 17:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 18:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 19:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 20:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 21:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 22:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 23:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 24:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 25:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 26:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 27:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 28:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 29:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 30:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 31:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 32:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 33:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 34:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 35:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 36:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 37:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 38:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 39:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 40:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 41:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 42:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 43:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 44:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 45:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 46:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya No");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 47:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 48:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 49:
                if (yes)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab Yes");
                    Debug.Log("Harusnya Yes");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            default:
                Debug.Log("Question No. " + questionCardNumber + 1);
                break;
        }


        yes = false;
        no = false;

        gameObject.SetActive(false);
        GameControl.yesButton.SetActive(false);
        GameControl.noButton.SetActive(false);
    }

    public void onClickNo()
    {
        GameControl gameControl = GameObject.Find("GameControl").GetComponent<GameControl>();

        yes = false;
        no = true;

        switch (questionCardNumber)
        {
            case 0:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 1:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 2:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 3:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 4:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 5:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 6:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 7:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 8:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 9:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 10:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 11:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 12:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 13:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 14:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 15:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 16:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 17:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 18:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 19:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 20:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 21:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 22:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 23:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 24:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 25:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 26:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 27:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 28:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 29:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 30:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 31:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 32:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 33:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 34:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 35:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 36:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 37:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 38:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 39:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 40:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 41:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 42:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 43:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 44:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 45:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 46:
                if (no)
                {
                    Debug.Log("Pernyataan " + questionCardNumber + " Dijawab No");
                    Debug.Log("Harusnya No");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 47:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 48:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 49:
                if (no)
                {
                    Debug.Log("Pernyataan " + (questionCardNumber + 1) + " Dijawab No");
                    Debug.Log("Harusnya Yes");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            default:
                Debug.Log("Question No. "+questionCardNumber);
                break;
        }

        yes = false;
        no = false;

        gameObject.SetActive(false);
        GameControl.yesButton.SetActive(false);
        GameControl.noButton.SetActive(false);
    }

    void RightAnswer(GameControl gameControl)
    {
        Debug.Log("Anda Benar!");
        AudioManager.instance.PlaySound("Right Answer", Vector3.zero);
        gameControl.rewardCard.SetActive(true);
        RewardCardScript reward = GameObject.Find("RewardCard").GetComponent<RewardCardScript>();
        reward.RollCard();
    }

    void WrongAnswer(GameControl gameControl)
    {
        Debug.Log("Anda Salah!");
        AudioManager.instance.PlaySound("Wrong Answer", Vector3.zero);
        gameControl.punishmentCard.SetActive(true);
        PunishmentCardScript punishment = GameObject.Find("PunishmentCard").GetComponent<PunishmentCardScript>();
        punishment.RollCard();
    }
}
