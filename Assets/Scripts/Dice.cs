﻿using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {
    public AudioClip diceRolls;

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private GameObject dice;
    private int whosTurn = 1;
    private bool coroutineAllowed = true;

    private AudioSource source;

	// Use this for initialization
	private void Start () {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = diceRolls;
        source.playOnAwake = false;
        dice = GameObject.Find("Dice");

        rend = dice.GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
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
        int randomDiceSide = 0;        
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];            
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown = randomDiceSide + 1;
        
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
            whosTurn = 2;

        } else if (whosTurn == 2)
        {
            GameControl.MovePlayer(2);
            whosTurn = 3;

        } else if (whosTurn == 3)
        {
            GameControl.MovePlayer(3);
            whosTurn = 4;

        } else if (whosTurn == 4)
        {
            GameControl.MovePlayer(4);
            whosTurn = 1;

        }

        coroutineAllowed = true;
    }
}