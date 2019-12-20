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
            randomCardSide = Random.Range(0, 9);
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
                    Debug.Log("Pernyataan 1 Dijawab Ya");
                    Debug.Log("Harusnya Tidak");
                    Debug.Log("Anda Salah!");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 1:
                if (yes)
                {
                    Debug.Log("Pernyataan 2 Dijawab Ya");
                    Debug.Log("Harusnya Benar");
                    Debug.Log("Anda Benar!");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 2:
                if (yes)
                {
                    Debug.Log("Pernyataan 3 Dijawab Ya");
                    Debug.Log("Harusnya Tidak");
                    Debug.Log("Anda Salah!");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 3:
                if (yes)
                {
                    Debug.Log("Pernyataan 4 Dijawab Ya");
                    Debug.Log("Harusnya Benar");
                    Debug.Log("Anda Benar!");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 4:
                if (yes)
                {
                    Debug.Log("Pernyataan 5 Dijawab Ya");
                    Debug.Log("Harusnya Tidak");
                    Debug.Log("Anda Salah!");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 5:
                if (yes)
                {
                    Debug.Log("Pernyataan 6 Dijawab Ya");
                    Debug.Log("Harusnya Tidak");
                    Debug.Log("Anda Salah!");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 6:
                if (yes)
                {
                    Debug.Log("Pernyataan 7 Dijawab Ya");
                    Debug.Log("Harusnya Tidak");
                    Debug.Log("Anda Salah!");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 7:
                if (yes)
                {
                    Debug.Log("Pernyataan 8 Dijawab Ya");
                    Debug.Log("Harusnya Benar");
                    Debug.Log("Anda Benar!");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 8:
                if (yes)
                {
                    Debug.Log("Pernyataan 9 Dijawab Ya");
                    Debug.Log("Harusnya Tidak");
                    Debug.Log("Anda Salah!");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 9:
                if (yes)
                {
                    Debug.Log("Pernyataan 10 Dijawab Ya");
                    Debug.Log("Harusnya Benar");
                    Debug.Log("Anda Benar!");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            default:
                Debug.Log("Question No. " + questionCardNumber);
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
                    Debug.Log("Pernyataan 1 Dijawab Tidak");
                    Debug.Log("Harusnya Tidak");
                    Debug.Log("Anda Benar!");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 1:
                if (no)
                {
                    Debug.Log("Pernyataan 2 Dijawab Tidak");
                    Debug.Log("Harusnya Benar");
                    Debug.Log("Anda Salah!");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 2:
                if (no)
                {
                    Debug.Log("Pernyataan 3 Dijawab Tidak");
                    Debug.Log("Harusnya Tidak");
                    Debug.Log("Anda Benar!");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 3:
                if (no)
                {
                    Debug.Log("Pernyataan 4 Dijawab Tidak");
                    Debug.Log("Harusnya Benar");
                    Debug.Log("Anda Salah!");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 4:
                if (no)
                {
                    Debug.Log("Pernyataan 5 Dijawab Tidak");
                    Debug.Log("Harusnya Tidak");
                    Debug.Log("Anda Benar!");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 5:
                if (no)
                {
                    Debug.Log("Pernyataan 6 Dijawab Tidak");
                    Debug.Log("Harusnya Tidak");
                    Debug.Log("Anda Benar!");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 6:
                if (no)
                {
                    Debug.Log("Pernyataan 7 Dijawab Tidak");
                    Debug.Log("Harusnya Tidak");
                    Debug.Log("Anda Benar!");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 7:
                if (no)
                {
                    Debug.Log("Pernyataan 8 Dijawab Tidak");
                    Debug.Log("Harusnya Benar");
                    Debug.Log("Anda Salah!");
                    WrongAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 8:
                if (no)
                {
                    Debug.Log("Pernyataan 9 Dijawab Tidak");
                    Debug.Log("Harusnya Tidak");
                    Debug.Log("Anda Benar!");
                    RightAnswer(gameControl);
                }
                GetComponent<BoxCollider2D>().enabled = true;
                break;
            case 9:
                if (no)
                {
                    Debug.Log("Pernyataan 10 Dijawab Tidak");
                    Debug.Log("Harusnya Benar");
                    Debug.Log("Anda Salah!");
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
        AudioManager.instance.PlaySound("Right Answer", Vector3.zero);
        gameControl.rewardCard.SetActive(true);
        RewardCardScript reward = GameObject.Find("RewardCard").GetComponent<RewardCardScript>();
        reward.RollCard();
    }

    void WrongAnswer(GameControl gameControl)
    {
        AudioManager.instance.PlaySound("Wrong Answer", Vector3.zero);
        gameControl.punishmentCard.SetActive(true);
        PunishmentCardScript punishment = GameObject.Find("PunishmentCard").GetComponent<PunishmentCardScript>();
        punishment.RollCard();
    }
}
