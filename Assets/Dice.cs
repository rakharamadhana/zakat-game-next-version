using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {
    public AudioClip diceRolls;

    private Sprite[] diceSides;
    private SpriteRenderer rend1;
    private SpriteRenderer rend2;
    private GameObject dice1;
    private GameObject dice2;
    private int whosTurn = 1;
    private bool coroutineAllowed = true;

    private AudioSource source;

	// Use this for initialization
	private void Start () {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = diceRolls;
        source.playOnAwake = false;
        dice1 = GameObject.Find("Dice 1");
        dice2 = GameObject.Find("Dice 2");

        rend1 = dice1.GetComponent<SpriteRenderer>();
        rend2 = dice2.GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend1.sprite = diceSides[5];
        rend2.sprite = diceSides[5];
    }

    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed)
        {
            source.PlayOneShot(diceRolls);
            StartCoroutine("RollTheDice");
        }
            
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide1 = 0;
        int randomDiceSide2 = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide1 = Random.Range(0, 6);
            randomDiceSide2 = Random.Range(0, 6);
            rend1.sprite = diceSides[randomDiceSide1];
            rend2.sprite = diceSides[randomDiceSide2];
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown = randomDiceSide1 + randomDiceSide2 + 2;
        //Debug.Log((randomDiceSide1+1) +" + "+(randomDiceSide2+1)+ " = "+GameControl.diceSideThrown);
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
            whosTurn = 2;

        } else if (whosTurn == 2)
        {
            GameControl.MovePlayer(2);
            whosTurn = 1;

        }
        
        coroutineAllowed = true;
    }
}
