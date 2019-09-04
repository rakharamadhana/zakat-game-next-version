using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public GameObject exitPanel, menuPanel, questionCard, rewardCard, punishmentCard;

    public List<int> questionWaypoints, rewardWaypoints, punishmentWaypoints = new List<int>();

    public AudioClip LadderSFX, WinningSFX, SnakeSFX, RewardSFX, QuestionSFX, PunishmentSFX;

    public AudioSource audioSource;

    private static GameObject winning, whoWinsTextShadow, pointer;

    private static GameObject player1, player2, player3, player4;

    private static GameObject pointerWaypoint1, pointerWaypoint2, pointerWaypoint3, pointerWaypoint4;

    public static int nofPlayers;
    public int pointerMoveSpeed;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;
    public static int player3StartWaypoint = 0;
    public static int player4StartWaypoint = 0;

    public static bool gameOver = false;

    // Use this for initialization
    void Start () {

        Screen.orientation = ScreenOrientation.Portrait;

        questionCard.SetActive(false);
        rewardCard.SetActive(false);
        punishmentCard.SetActive(false);

        diceSideThrown = 0;
        player1StartWaypoint = 0;
        player2StartWaypoint = 0;
        player2StartWaypoint = 0;
        player3StartWaypoint = 0;
        player4StartWaypoint = 0;
        gameOver = false;

        winning = GameObject.Find("Winning");
        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        pointer = GameObject.Find("Pointer");

        pointerWaypoint1 = GameObject.Find("PointerWaypoint1");
        pointerWaypoint2 = GameObject.Find("PointerWaypoint2");
        pointerWaypoint3 = GameObject.Find("PointerWaypoint3");
        pointerWaypoint4 = GameObject.Find("PointerWaypoint4");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;
        player3.GetComponent<FollowThePath>().moveAllowed = false;
        player4.GetComponent<FollowThePath>().moveAllowed = false;

        winning.gameObject.SetActive(false);
        whoWinsTextShadow.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        switch (nofPlayers)
        {
            case 1:
                player2.gameObject.SetActive(false);
                player3.gameObject.SetActive(false);
                player4.gameObject.SetActive(false);
                break;
            case 2:
                player3.gameObject.SetActive(false);
                player4.gameObject.SetActive(false);
                break;
            case 3:
                player4.gameObject.SetActive(false);
                break;
            case 4:
                break;
        }

        if(gameOver){
            if (SceneManager.GetActiveScene().name == "Menu")
            {
                exitPanel.SetActive(true);
            }
            else 
            {
                menuPanel.SetActive(true);
            }
        }

        if(Dice.whosTurn == 1) {
            //Debug.Log("Player 1");
            pointer.transform.position = Vector2.MoveTowards(
                pointer.transform.position,
                pointerWaypoint1.transform.position,
                pointerMoveSpeed * Time.deltaTime);
        }
        else if(Dice.whosTurn == 2){
            //Debug.Log("Player 2");
            pointer.transform.position = Vector2.MoveTowards(
                pointer.transform.position,
                pointerWaypoint2.transform.position,
                pointerMoveSpeed * Time.deltaTime);
        }
        else if(Dice.whosTurn == 3){
            //Debug.Log("Player 3");
            pointer.transform.position = Vector2.MoveTowards(
                pointer.transform.position,
                pointerWaypoint3.transform.position,
                pointerMoveSpeed * Time.deltaTime);
        }
        else if(Dice.whosTurn == 4){
            pointer.transform.position = Vector2.MoveTowards(
                pointer.transform.position,
                pointerWaypoint4.transform.position,
                pointerMoveSpeed * Time.deltaTime);
        }

        // PLAYER 1
        if (player1.GetComponent<FollowThePath>().waypointIndex > 
            player1StartWaypoint + diceSideThrown)
        {
            if(questionWaypoints.Contains(player1StartWaypoint + diceSideThrown))
            {
                questionCard.SetActive(true);
                questionCard.GetComponent<QuestionCardScript>().RollCard();
                audioSource.clip = QuestionSFX;
                audioSource.Play();
                Debug.Log("Question!");
            }
            else if (rewardWaypoints.Contains(player1StartWaypoint + diceSideThrown))
            {
                rewardCard.SetActive(true);
                rewardCard.GetComponent<RewardCardScript>().RollCard();
                audioSource.clip = RewardSFX;
                audioSource.Play();
                Debug.Log("Reward!");
            }
            else if (punishmentWaypoints.Contains(player1StartWaypoint+ diceSideThrown))
            {
                punishmentCard.SetActive(true);
                punishmentCard.GetComponent<PunishmentCardScript>().RollCard();
                audioSource.clip = PunishmentSFX;
                audioSource.Play();
                Debug.Log("Punishment!");
            }
            else
            {
                // Tangga
                if (player1StartWaypoint + diceSideThrown == 6)
                {
                    audioSource.PlayOneShot(LadderSFX);
                    player1.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[45].transform.position;
                    player1.GetComponent<FollowThePath>().waypointIndex = 45;
                    player1.GetComponent<FollowThePath>().waypointIndex += 1;
                    MovePlayer(1);
                }
                if (player1StartWaypoint + diceSideThrown == 13)
                {
                    audioSource.PlayOneShot(LadderSFX);
                    player1.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[41].transform.position;
                    player1.GetComponent<FollowThePath>().waypointIndex = 41;
                    player1.GetComponent<FollowThePath>().waypointIndex += 1;
                    MovePlayer(1);
                }
                if (player1StartWaypoint + diceSideThrown == 20)
                {
                    audioSource.PlayOneShot(LadderSFX);
                    player1.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[35].transform.position;
                    player1.GetComponent<FollowThePath>().waypointIndex = 35;
                    player1.GetComponent<FollowThePath>().waypointIndex += 1;
                    MovePlayer(1);
                }
                if (player1StartWaypoint + diceSideThrown == 25)
                {
                    audioSource.PlayOneShot(LadderSFX);
                    player1.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[32].transform.position;
                    player1.GetComponent<FollowThePath>().waypointIndex = 32;
                    player1.GetComponent<FollowThePath>().waypointIndex += 1;
                    MovePlayer(1);
                }

                // Ular
                if (player1StartWaypoint + diceSideThrown == 34)
                {
                    audioSource.PlayOneShot(SnakeSFX);
                    player1.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[22].transform.position;
                    player1.GetComponent<FollowThePath>().waypointIndex = 22;
                    player1.GetComponent<FollowThePath>().waypointIndex += 1;
                    MovePlayer(1);
                }
                if (player1StartWaypoint + diceSideThrown == 40)
                {
                    audioSource.PlayOneShot(SnakeSFX);
                    player1.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[15].transform.position;
                    player1.GetComponent<FollowThePath>().waypointIndex = 15;
                    player1.GetComponent<FollowThePath>().waypointIndex += 1;
                    MovePlayer(1);
                }
                if (player1StartWaypoint + diceSideThrown == 46)
                {
                    audioSource.PlayOneShot(SnakeSFX);
                    player1.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[3].transform.position;
                    player1.GetComponent<FollowThePath>().waypointIndex = 3;
                    player1.GetComponent<FollowThePath>().waypointIndex += 1;
                    MovePlayer(1);
                }
            }
            
            player1.GetComponent<FollowThePath>().moveAllowed = false;            
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        // Player 2
        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            // Tangga
            if (player2StartWaypoint + diceSideThrown == 6)
            {
                player2.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[45].transform.position;
                player2.GetComponent<FollowThePath>().waypointIndex = 45;
                player2.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(2);
            }
            if (player2StartWaypoint + diceSideThrown == 13)
            {
                player2.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[41].transform.position;
                player2.GetComponent<FollowThePath>().waypointIndex = 41;
                player2.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(2);
            }
            if (player2StartWaypoint + diceSideThrown == 20)
            {
                player2.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[35].transform.position;
                player2.GetComponent<FollowThePath>().waypointIndex = 35;
                player2.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(2);
            }
            if (player2StartWaypoint + diceSideThrown == 25)
            {
                player2.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[32].transform.position;
                player2.GetComponent<FollowThePath>().waypointIndex = 32;
                player2.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(2);
            }

            // Ular
            if (player2StartWaypoint + diceSideThrown == 34)
            {
                player2.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[22].transform.position;
                player2.GetComponent<FollowThePath>().waypointIndex = 22;
                player2.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(2);
            }
            if (player2StartWaypoint + diceSideThrown == 40)
            {
                player2.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[15].transform.position;
                player2.GetComponent<FollowThePath>().waypointIndex = 15;
                player2.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(2);
            }
            if (player2StartWaypoint + diceSideThrown == 46)
            {
                player2.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[3].transform.position;
                player2.GetComponent<FollowThePath>().waypointIndex = 3;
                player2.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(2);
            }

            player2.GetComponent<FollowThePath>().moveAllowed = false;
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        // Player 3
        if (player3.GetComponent<FollowThePath>().waypointIndex > 
            player3StartWaypoint + diceSideThrown)
        {
            // Tangga
            if (player3StartWaypoint + diceSideThrown == 6)
            {
                player3.GetComponent<FollowThePath>().transform.position = player3.GetComponent<FollowThePath>().waypoints[45].transform.position;
                player3.GetComponent<FollowThePath>().waypointIndex = 45;
                player3.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(3);
            }
            if (player3StartWaypoint + diceSideThrown == 13)
            {
                player3.GetComponent<FollowThePath>().transform.position = player3.GetComponent<FollowThePath>().waypoints[41].transform.position;
                player3.GetComponent<FollowThePath>().waypointIndex = 41;
                player3.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(3);
            }
            if (player3StartWaypoint + diceSideThrown == 20)
            {
                player3.GetComponent<FollowThePath>().transform.position = player3.GetComponent<FollowThePath>().waypoints[35].transform.position;
                player3.GetComponent<FollowThePath>().waypointIndex = 35;
                player3.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(3);
            }
            if (player3StartWaypoint + diceSideThrown == 25)
            {
                player3.GetComponent<FollowThePath>().transform.position = player3.GetComponent<FollowThePath>().waypoints[32].transform.position;
                player3.GetComponent<FollowThePath>().waypointIndex = 32;
                player3.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(3);
            }

            // Ular
            if (player3StartWaypoint + diceSideThrown == 34)
            {
                player3.GetComponent<FollowThePath>().transform.position = player3.GetComponent<FollowThePath>().waypoints[22].transform.position;
                player3.GetComponent<FollowThePath>().waypointIndex = 22;
                player3.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(3);
            }
            if (player3StartWaypoint + diceSideThrown == 40)
            {
                player3.GetComponent<FollowThePath>().transform.position = player3.GetComponent<FollowThePath>().waypoints[15].transform.position;
                player3.GetComponent<FollowThePath>().waypointIndex = 15;
                player3.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(3);
            }
            if (player3StartWaypoint + diceSideThrown == 46)
            {
                player3.GetComponent<FollowThePath>().transform.position = player3.GetComponent<FollowThePath>().waypoints[3].transform.position;
                player3.GetComponent<FollowThePath>().waypointIndex = 3;
                player3.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(3);
            }

            player3.GetComponent<FollowThePath>().moveAllowed = false;            
            player3StartWaypoint = player3.GetComponent<FollowThePath>().waypointIndex - 1;
        }
//
        //Player4
        if (player4.GetComponent<FollowThePath>().waypointIndex > 
            player4StartWaypoint + diceSideThrown)
        {
            // Tangga
            if (player4StartWaypoint + diceSideThrown == 6)
            {
                player4.GetComponent<FollowThePath>().transform.position = player4.GetComponent<FollowThePath>().waypoints[45].transform.position;
                player4.GetComponent<FollowThePath>().waypointIndex = 45;
                player4.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(4);
            }
            if (player4StartWaypoint + diceSideThrown == 13)
            {
                player4.GetComponent<FollowThePath>().transform.position = player4.GetComponent<FollowThePath>().waypoints[41].transform.position;
                player4.GetComponent<FollowThePath>().waypointIndex = 41;
                player4.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(4);
            }
            if (player4StartWaypoint + diceSideThrown == 20)
            {
                player4.GetComponent<FollowThePath>().transform.position = player4.GetComponent<FollowThePath>().waypoints[35].transform.position;
                player4.GetComponent<FollowThePath>().waypointIndex = 35;
                player4.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(4);
            }
            if (player4StartWaypoint + diceSideThrown == 25)
            {
                player4.GetComponent<FollowThePath>().transform.position = player4.GetComponent<FollowThePath>().waypoints[32].transform.position;
                player4.GetComponent<FollowThePath>().waypointIndex = 32;
                player4.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(4);
            }

            // Ular
            if (player4StartWaypoint + diceSideThrown == 34)
            {
                player4.GetComponent<FollowThePath>().transform.position = player4.GetComponent<FollowThePath>().waypoints[22].transform.position;
                player4.GetComponent<FollowThePath>().waypointIndex = 22;
                player4.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(4);
            }
            if (player4StartWaypoint + diceSideThrown == 40)
            {
                player4.GetComponent<FollowThePath>().transform.position = player4.GetComponent<FollowThePath>().waypoints[15].transform.position;
                player4.GetComponent<FollowThePath>().waypointIndex = 15;
                player4.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(4);
            }
            if (player4StartWaypoint + diceSideThrown == 46)
            {
                player4.GetComponent<FollowThePath>().transform.position = player4.GetComponent<FollowThePath>().waypoints[3].transform.position;
                player4.GetComponent<FollowThePath>().waypointIndex = 3;
                player4.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(4);
            }

            player4.GetComponent<FollowThePath>().moveAllowed = false;            
            player4StartWaypoint = player4.GetComponent<FollowThePath>().waypointIndex - 1;
        }


        //Winnings
        if (player1.GetComponent<FollowThePath>().waypointIndex == 
            player1.GetComponent<FollowThePath>().waypoints.Count)
        {
            winning.gameObject.SetActive(true);
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
            gameOver = true;
        }
        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Count)
        {
            winning.gameObject.SetActive(true);
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";            
            gameOver = true;
        }
        if (player3.GetComponent<FollowThePath>().waypointIndex ==
            player3.GetComponent<FollowThePath>().waypoints.Count)
        {
            winning.gameObject.SetActive(true);
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 3 Wins";
            gameOver = true;
        }
        if (player4.GetComponent<FollowThePath>().waypointIndex ==
            player4.GetComponent<FollowThePath>().waypoints.Count)
        {
            winning.gameObject.SetActive(true);
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 4 Wins";
            gameOver = true;
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) { 
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            case 3:
                player3.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            case 4:
                player4.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    }
}
