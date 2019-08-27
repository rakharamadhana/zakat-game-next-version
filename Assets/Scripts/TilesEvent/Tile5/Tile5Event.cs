using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile5Event : MonoBehaviour
{
    public GameObject [] player;

    public static GameObject triggeredButton;
    public static bool prompt;

    private void Start()
    {
        triggeredButton = GameObject.Find("Tile5Event");
        triggeredButton.gameObject.SetActive(false);
        prompt = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log(collision.name + " ENTER");
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameControl.player1StartWaypoint == 4)
            {
                Debug.Log(GameControl.player1StartWaypoint);
                triggeredButton.gameObject.SetActive(true);
            }

            if (GameControl.player2StartWaypoint == 4)
            {
                Debug.Log(GameControl.player2StartWaypoint);
                triggeredButton.gameObject.SetActive(true);
            }

            if (GameControl.player3StartWaypoint == 4)
            {
                Debug.Log(GameControl.player3StartWaypoint);
                triggeredButton.gameObject.SetActive(true);
            }

            if (GameControl.player4StartWaypoint == 4)
            {
                Debug.Log(GameControl.player4StartWaypoint);
                triggeredButton.gameObject.SetActive(true);
            }
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //triggeredButton.gameObject.SetActive(false);
            //Debug.Log(collision.name + " EXIT");
        }
    }
}
