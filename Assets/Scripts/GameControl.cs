using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public GameObject exitPanel, menuPanel, questionCard, rewardCard, punishmentCard;

    public static Text player1Score, player2Score, player3Score, player4Score;
    public static int score1, score2, score3, score4;

    public List<int> questionWaypoints, rewardWaypoints, punishmentWaypoints = new List<int>();

    public AudioClip LadderSFX, WinningSFX, SnakeSFX, RewardSFX, QuestionSFX, PunishmentSFX, RightSFX, WrongSFX;

    public AudioSource audioSource;

    public AudioClip CoinsSFX;

    public static GameObject yesButton, noButton;

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

        diceSideThrown = 0;
        player1StartWaypoint = 0;
        player2StartWaypoint = 0;
        player3StartWaypoint = 0;
        player4StartWaypoint = 0;
        gameOver = false;

        player1Score = GameObject.Find("Player1Score").GetComponent<Text>();
        player2Score = GameObject.Find("Player2Score").GetComponent<Text>();
        player3Score = GameObject.Find("Player3Score").GetComponent<Text>();
        player4Score = GameObject.Find("Player4Score").GetComponent<Text>();
        score1 = 0;
        score2 = 0;
        score3 = 0;
        score4 = 0;
        player1Score.text = score1.ToString();
        player2Score.text = score2.ToString();
        player3Score.text = score3.ToString();
        player4Score.text = score4.ToString();

        winning = GameObject.Find("Winning");
        yesButton = GameObject.Find("Yes");
        noButton = GameObject.Find("No");
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
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        whoWinsTextShadow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Checking Player first
        CheckPlayer(); // Checking how many players are there.

        // Checking if game is over.
        if (gameOver){
            if (SceneManager.GetActiveScene().name == "Menu")
            {
                exitPanel.SetActive(true);
            }
            else 
            {
                menuPanel.SetActive(true);
            }
        }

        //Checking Turns
        CheckTurn(); // Checking whos turn it is.

        //Checking Tiles
        CheckTiles(); // Checking what tiles that touched.

        //Checking Win
        CheckWinning(); // Check if anyone wins.
    }
    
    void CheckPlayer()
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
    }

    void CheckTurn()
    {
        if (Dice.whosTurn == 1)
        {
            //Debug.Log("Player 1");
            pointer.transform.position = Vector2.MoveTowards(
                pointer.transform.position,
                pointerWaypoint1.transform.position,
                pointerMoveSpeed * Time.deltaTime);
        }
        else if (Dice.whosTurn == 2)
        {
            //Debug.Log("Player 2");
            pointer.transform.position = Vector2.MoveTowards(
                pointer.transform.position,
                pointerWaypoint2.transform.position,
                pointerMoveSpeed * Time.deltaTime);
        }
        else if (Dice.whosTurn == 3)
        {
            //Debug.Log("Player 3");
            pointer.transform.position = Vector2.MoveTowards(
                pointer.transform.position,
                pointerWaypoint3.transform.position,
                pointerMoveSpeed * Time.deltaTime);
        }
        else if (Dice.whosTurn == 4)
        {
            pointer.transform.position = Vector2.MoveTowards(
                pointer.transform.position,
                pointerWaypoint4.transform.position,
                pointerMoveSpeed * Time.deltaTime);
        }
    }

    void CheckTiles()
    {
        // PLAYER 1
        if (player1.GetComponent<FollowThePath>().waypointIndex >
            player1StartWaypoint + diceSideThrown)
        {
            // Question
            if (questionWaypoints.Contains(player1StartWaypoint + diceSideThrown))
            {
                questionCard.SetActive(true);
                questionCard.GetComponent<QuestionCardScript>().RollCard();
                AudioManager.instance.PlaySound("Question", Vector3.zero);
                //Debug.Log("Question!");
                yesButton.gameObject.SetActive(true);
                noButton.gameObject.SetActive(true);
            }

            // Reward
            else if (rewardWaypoints.Contains(player1StartWaypoint + diceSideThrown))
            {
                rewardCard.SetActive(true);
                rewardCard.GetComponent<RewardCardScript>().RollCard();
                AudioManager.instance.PlaySound("Reward", Vector3.zero);
                //Debug.Log("Reward!");
            }

            // Punishment
            else if (punishmentWaypoints.Contains(player1StartWaypoint + diceSideThrown))
            {
                punishmentCard.SetActive(true);
                punishmentCard.GetComponent<PunishmentCardScript>().RollCard();
                AudioManager.instance.PlaySound("Punishment", Vector3.zero);
                //Debug.Log("Punishment!");
            }

            // Snake & Ladder
            else
            {
                // Tangga
                if (player1StartWaypoint + diceSideThrown == 6)
                {
                    GoUp(1, 45);
                }
                if (player1StartWaypoint + diceSideThrown == 13)
                {
                    GoUp(1, 41);
                }
                if (player1StartWaypoint + diceSideThrown == 20)
                {
                    GoUp(1, 35);
                }
                if (player1StartWaypoint + diceSideThrown == 25)
                {
                    GoUp(1, 32);
                }

                // Ular
                if (player1StartWaypoint + diceSideThrown == 34)
                {
                    GoDown(1, 22);
                }
                if (player1StartWaypoint + diceSideThrown == 40)
                {
                    GoDown(1, 15);
                }
                if (player1StartWaypoint + diceSideThrown == 46)
                {
                    GoDown(1, 3);
                }
            }

            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        // Player 2
        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            // Question
            if (questionWaypoints.Contains(player2StartWaypoint + diceSideThrown))
            {
                questionCard.SetActive(true);
                questionCard.GetComponent<QuestionCardScript>().RollCard();
                audioSource.clip = QuestionSFX;
                audioSource.Play();
                Debug.Log("Question!");
                yesButton.gameObject.SetActive(true);
                noButton.gameObject.SetActive(true);
            }

            // Reward
            else if (rewardWaypoints.Contains(player2StartWaypoint + diceSideThrown))
            {
                rewardCard.SetActive(true);
                rewardCard.GetComponent<RewardCardScript>().RollCard();
                audioSource.clip = RewardSFX;
                audioSource.Play();
                Debug.Log("Reward!");
            }

            // Punishment
            else if (punishmentWaypoints.Contains(player2StartWaypoint + diceSideThrown))
            {
                punishmentCard.SetActive(true);
                punishmentCard.GetComponent<PunishmentCardScript>().RollCard();
                audioSource.clip = PunishmentSFX;
                audioSource.Play();
                Debug.Log("Punishment!");
            }

            // Snake & Ladder
            else
            {
                // Tangga
                if (player2StartWaypoint + diceSideThrown == 6)
                {
                    GoUp(2, 45);
                }
                if (player2StartWaypoint + diceSideThrown == 13)
                {
                    GoUp(2, 41);
                }
                if (player2StartWaypoint + diceSideThrown == 20)
                {
                    GoUp(2, 35);
                }
                if (player2StartWaypoint + diceSideThrown == 25)
                {
                    GoUp(2, 32);
                }

                // Ular
                if (player2StartWaypoint + diceSideThrown == 34)
                {
                    GoDown(2, 22);
                }
                if (player2StartWaypoint + diceSideThrown == 40)
                {
                    GoDown(2, 15);
                }
                if (player2StartWaypoint + diceSideThrown == 46)
                {
                    GoDown(2, 3);
                }
            }

            player2.GetComponent<FollowThePath>().moveAllowed = false;
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        // Player 3
        if (player3.GetComponent<FollowThePath>().waypointIndex >
            player3StartWaypoint + diceSideThrown)
        {
            // Question
            if (questionWaypoints.Contains(player3StartWaypoint + diceSideThrown))
            {
                questionCard.SetActive(true);
                questionCard.GetComponent<QuestionCardScript>().RollCard();
                audioSource.clip = QuestionSFX;
                audioSource.Play();
                Debug.Log("Question!");
                yesButton.gameObject.SetActive(true);
                noButton.gameObject.SetActive(true);
            }

            // Reward
            else if (rewardWaypoints.Contains(player3StartWaypoint + diceSideThrown))
            {
                rewardCard.SetActive(true);
                rewardCard.GetComponent<RewardCardScript>().RollCard();
                audioSource.clip = RewardSFX;
                audioSource.Play();
                Debug.Log("Reward!");
            }

            // Punishment
            else if (punishmentWaypoints.Contains(player3StartWaypoint + diceSideThrown))
            {
                punishmentCard.SetActive(true);
                punishmentCard.GetComponent<PunishmentCardScript>().RollCard();
                audioSource.clip = PunishmentSFX;
                audioSource.Play();
                Debug.Log("Punishment!");
            }

            // Snake & Ladder
            else
            {
                // Tangga
                if (player3StartWaypoint + diceSideThrown == 6)
                {
                    GoUp(3, 45);
                }
                if (player3StartWaypoint + diceSideThrown == 13)
                {
                    GoUp(3, 41);
                }
                if (player3StartWaypoint + diceSideThrown == 20)
                {
                    GoUp(3, 35);
                }
                if (player3StartWaypoint + diceSideThrown == 25)
                {
                    GoUp(3, 32);
                }

                // Ular
                if (player3StartWaypoint + diceSideThrown == 34)
                {
                    GoDown(3, 22);
                }
                if (player3StartWaypoint + diceSideThrown == 40)
                {
                    GoDown(3, 15);
                }
                if (player3StartWaypoint + diceSideThrown == 46)
                {
                    GoDown(3, 3);
                }
            }

            player3.GetComponent<FollowThePath>().moveAllowed = false;
            player3StartWaypoint = player3.GetComponent<FollowThePath>().waypointIndex - 1;
        }
        //
        //Player4
        if (player4.GetComponent<FollowThePath>().waypointIndex >
            player4StartWaypoint + diceSideThrown)
        {
            // Question
            if (questionWaypoints.Contains(player4StartWaypoint + diceSideThrown))
            {
                questionCard.SetActive(true);
                questionCard.GetComponent<QuestionCardScript>().RollCard();
                audioSource.clip = QuestionSFX;
                audioSource.Play();
                Debug.Log("Question!");
                yesButton.gameObject.SetActive(true);
                noButton.gameObject.SetActive(true);
            }

            // Reward
            else if (rewardWaypoints.Contains(player4StartWaypoint + diceSideThrown))
            {
                rewardCard.SetActive(true);
                rewardCard.GetComponent<RewardCardScript>().RollCard();
                audioSource.clip = RewardSFX;
                audioSource.Play();
                Debug.Log("Reward!");
            }

            // Punishment
            else if (punishmentWaypoints.Contains(player4StartWaypoint + diceSideThrown))
            {
                punishmentCard.SetActive(true);
                punishmentCard.GetComponent<PunishmentCardScript>().RollCard();
                audioSource.clip = PunishmentSFX;
                audioSource.Play();
                Debug.Log("Punishment!");
            }

            // Snake & Ladder
            else
            {
                // Tangga
                if (player4StartWaypoint + diceSideThrown == 6)
                {
                    GoUp(4, 45);
                }
                if (player4StartWaypoint + diceSideThrown == 13)
                {
                    GoUp(4, 41);
                }
                if (player4StartWaypoint + diceSideThrown == 20)
                {
                    GoUp(4, 35);
                }
                if (player4StartWaypoint + diceSideThrown == 25)
                {
                    GoUp(4, 32);
                }

                // Ular
                if (player4StartWaypoint + diceSideThrown == 34)
                {
                    GoDown(4, 22);
                }
                if (player4StartWaypoint + diceSideThrown == 40)
                {
                    GoDown(4, 15);
                }
                if (player4StartWaypoint + diceSideThrown == 46)
                {
                    GoDown(4, 3);
                }
            }

            player4.GetComponent<FollowThePath>().moveAllowed = false;
            player4StartWaypoint = player4.GetComponent<FollowThePath>().waypointIndex - 1;
        }
    }

    void CheckWinning()
    {
        if (player1.GetComponent<FollowThePath>().waypointIndex ==
            player1.GetComponent<FollowThePath>().waypoints.Count)
        {
            AudioManager.instance.PlaySound("Winning", Vector3.zero);
            StartCoroutine(AddPlayerScore(1, 1000));
            TransformPlayerPosition(1, 0);
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Count)
        {
            AudioManager.instance.PlaySound("Winning", Vector3.zero);
            StartCoroutine(AddPlayerScore(2, 1000));
            TransformPlayerPosition(2, 0);
        }
        if (player3.GetComponent<FollowThePath>().waypointIndex ==
            player3.GetComponent<FollowThePath>().waypoints.Count)
        {
            AudioManager.instance.PlaySound("Winning", Vector3.zero);
            StartCoroutine(AddPlayerScore(3, 1000));
            TransformPlayerPosition(3, 0);
        }
        if (player4.GetComponent<FollowThePath>().waypointIndex ==
            player4.GetComponent<FollowThePath>().waypoints.Count)
        {
            AudioManager.instance.PlaySound("Winning", Vector3.zero);
            StartCoroutine(AddPlayerScore(4, 1000));
            TransformPlayerPosition(4, 0);
        }
    }

    void GoUp(int playerIndex, int waypointIndex)
    {
        AudioManager.instance.PlaySound("Ladder", Vector3.zero);
        MovePlayerPosition(playerIndex, waypointIndex);
    }

    void GoDown(int playerIndex, int waypointIndex)
    {
        AudioManager.instance.PlaySound("Snake", Vector3.zero);
        MovePlayerPosition(playerIndex, waypointIndex);
    }

    public static void MovePlayerPosition(int playerIndex, int waypointIndex)
    {
        GameObject playerObject = null;

        if(playerIndex == 1){
            playerObject = player1;
        }
        else if(playerIndex == 2)
        {
            playerObject = player2;
        }
        else if(playerIndex == 3)
        {
            playerObject = player3;
        }
        else if(playerIndex == 4)
        {
            playerObject = player4;
        }

        playerObject.GetComponent<FollowThePath>().transform.position = playerObject.GetComponent<FollowThePath>().waypoints[waypointIndex].transform.position;
        playerObject.GetComponent<FollowThePath>().waypointIndex = waypointIndex;
        playerObject.GetComponent<FollowThePath>().waypointIndex += 1;
        MovePlayer(playerIndex);
        playerObject.GetComponent<FollowThePath>().moveAllowed = false;
        UpdatePlayerStartWaypoint(playerIndex);
    }

    public static void TransformPlayerPosition(int player, int index)
    {
        switch (player)
        {
            case 1:
                player1.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[index].transform.position;
                player1.GetComponent<FollowThePath>().waypointIndex = index;
                player1.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(player);
                player1.GetComponent<FollowThePath>().moveAllowed = false;
                player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
                break;
            case 2:
                player2.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[index].transform.position;
                player2.GetComponent<FollowThePath>().waypointIndex = 0;
                player2.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(player);
                player2.GetComponent<FollowThePath>().moveAllowed = false;
                player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
                break;
            case 3:
                player3.GetComponent<FollowThePath>().transform.position = player3.GetComponent<FollowThePath>().waypoints[index].transform.position;
                player3.GetComponent<FollowThePath>().waypointIndex = 0;
                player3.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(player);
                player3.GetComponent<FollowThePath>().moveAllowed = false;
                player3StartWaypoint = player3.GetComponent<FollowThePath>().waypointIndex - 1;
                break;
            case 4:
                player4.GetComponent<FollowThePath>().transform.position = player4.GetComponent<FollowThePath>().waypoints[index].transform.position;
                player4.GetComponent<FollowThePath>().waypointIndex = 0;
                player4.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(player);
                player4.GetComponent<FollowThePath>().moveAllowed = false;
                player4StartWaypoint = player4.GetComponent<FollowThePath>().waypointIndex - 1;
                break;
        }
    }

    public static void UpdatePlayerStartWaypoint(int playerIndex)
    {
        if (playerIndex == 1)
        {
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1; ;
        }
        else if (playerIndex == 2)
        {
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1; ;
        }
        else if (playerIndex == 3)
        {
            player3StartWaypoint = player3.GetComponent<FollowThePath>().waypointIndex - 1; ;
        }
        else if (playerIndex == 4)
        {
            player4StartWaypoint = player4.GetComponent<FollowThePath>().waypointIndex - 1; ;
        }
    }

    public static IEnumerator AddPlayerScore(int player, int value)
    {
        GameControl gameControl = GameObject.Find("GameControl").GetComponent<GameControl>();

        //Debug.Log("Add " + value + " to Player " + player);

        int temp = 0;

        switch (player)
        {
            case 1:
                while (temp < value)
                {
                    AudioManager.instance.PlaySound("Coins", Vector3.zero);
                    if (value <= 1000)
                    {
                        temp += 100;
                        score1 += 100;
                    }
                    else if (value <= 10000)
                    {
                        temp += 100;
                        score1 += 100;
                    }
                    else if (value <= 100000)
                    {
                        temp += 1000;
                        score1 += 1000;
                    }
                    else if (value <= 1000000)
                    {
                        temp += 10000;
                        score1 += 10000;
                    }
                    else if (value <= 10000000)
                    {
                        temp += 100000;
                        score1 += 100000;
                    }
                    else
                    {
                        temp += 100000;
                        score1 += 100000;
                    }
                    player1Score.text = score1.ToString();
                    yield return new WaitForSeconds(0.01f);
                }
                break;
            case 2:
                while (temp < value)
                {
                    gameControl.audioSource.PlayOneShot(gameControl.CoinsSFX);
                    if (value <= 1000)
                    {
                        temp += 100;
                        score2 += 100;
                    }
                    else if (value <= 10000)
                    {
                        temp += 100;
                        score2 += 100;
                    }
                    else if (value <= 100000)
                    {
                        temp += 1000;
                        score2 += 1000;
                    }
                    else if (value <= 1000000)
                    {
                        temp += 10000;
                        score2 += 10000;
                    }
                    else if (value <= 10000000)
                    {
                        temp += 100000;
                        score2 += 100000;
                    }
                    else
                    {
                        temp += 100000;
                        score2 += 100000;
                    }
                    player2Score.text = score2.ToString();
                    yield return new WaitForSeconds(0.01f);
                }
                break;
            case 3:
                while (temp < value)
                {
                    gameControl.audioSource.PlayOneShot(gameControl.CoinsSFX);
                    if (value <= 1000)
                    {
                        temp += 100;
                        score3 += 100;
                    }
                    else if (value <= 10000)
                    {
                        temp += 100;
                        score3 += 100;
                    }
                    else if (value <= 100000)
                    {
                        temp += 1000;
                        score3 += 1000;
                    }
                    else if (value <= 1000000)
                    {
                        temp += 10000;
                        score3 += 10000;
                    }
                    else if (value <= 10000000)
                    {
                        temp += 100000;
                        score3 += 100000;
                    }
                    else
                    {
                        temp += 100000;
                        score3 += 100000;
                    }
                    player3Score.text = score3.ToString();
                    yield return new WaitForSeconds(0.01f);
                }
                break;
            case 4:
                while (temp < value)
                {
                    gameControl.audioSource.PlayOneShot(gameControl.CoinsSFX);
                    if (value <= 1000)
                    {
                        temp += 100;
                        score4 += 100;
                    }
                    else if (value <= 10000)
                    {
                        temp += 100;
                        score4 += 100;
                    }
                    else if (value <= 100000)
                    {
                        temp += 1000;
                        score4 += 1000;
                    }
                    else if (value <= 1000000)
                    {
                        temp += 10000;
                        score4 += 10000;
                    }
                    else if (value <= 10000000)
                    {
                        temp += 100000;
                        score4 += 100000;
                    }
                    else
                    {
                        temp += 100000;
                        score4 += 100000;
                    }
                    player4Score.text = score4.ToString();
                    yield return new WaitForSeconds(0.01f);
                }
                break;
        }
        temp = 0;
    }

    public static IEnumerator SubtractPlayerScore(int player, int value)
    {
        GameControl gameControl = GameObject.Find("GameControl").GetComponent<GameControl>();

        //Debug.Log("Subtract " + value + " for Player " + player);

        int temp = 0;

        switch (player)
        {
            case 1:
                while (temp < value)
                {
                    AudioManager.instance.PlaySound("Coins", Vector3.zero);
                    if (value <= 1000)
                    {
                        temp += 100;
                        score1 -= 100;
                    }
                    else if (value <= 10000)
                    {
                        temp += 100;
                        score1 -= 100;
                    }
                    else if (value <= 100000)
                    {
                        temp += 1000;
                        score1 -= 1000;
                    }
                    else if (value <= 1000000)
                    {
                        temp += 10000;
                        score1 -= 10000;
                    }
                    else if (value <= 10000000)
                    {
                        temp += 100000;
                        score1 -= 100000;
                    }
                    else
                    {
                        temp += 100000;
                        score1 -= 100000;
                    }
                    player1Score.text = score1.ToString();
                    yield return new WaitForSeconds(0.01f);
                }
                break;
            case 2:
                while (temp < value)
                {
                    gameControl.audioSource.PlayOneShot(gameControl.CoinsSFX);
                    if (value <= 1000)
                    {
                        temp += 100;
                        score2 -= 100;
                    }
                    else if (value <= 10000)
                    {
                        temp += 100;
                        score2 -= 100;
                    }
                    else if (value <= 100000)
                    {
                        temp += 1000;
                        score2 -= 1000;
                    }
                    else if (value <= 1000000)
                    {
                        temp += 10000;
                        score2 -= 10000;
                    }
                    else if (value <= 10000000)
                    {
                        temp += 100000;
                        score2 -= 100000;
                    }
                    else
                    {
                        temp += 100000;
                        score2 -= 100000;
                    }
                    player2Score.text = score2.ToString();
                    yield return new WaitForSeconds(0.01f);
                }
                break;
            case 3:
                while (temp < value)
                {
                    gameControl.audioSource.PlayOneShot(gameControl.CoinsSFX);
                    if (value <= 1000)
                    {
                        temp += 100;
                        score3 -= 100;
                    }
                    else if (value <= 10000)
                    {
                        temp += 100;
                        score3 -= 100;
                    }
                    else if (value <= 100000)
                    {
                        temp += 1000;
                        score3 -= 1000;
                    }
                    else if (value <= 1000000)
                    {
                        temp += 10000;
                        score3 -= 10000;
                    }
                    else if (value <= 10000000)
                    {
                        temp += 100000;
                        score3 -= 100000;
                    }
                    else
                    {
                        temp += 100000;
                        score3 -= 100000;
                    }
                    player3Score.text = score3.ToString();
                    yield return new WaitForSeconds(0.01f);
                }
                break;
            case 4:
                while (temp < value)
                {
                    gameControl.audioSource.PlayOneShot(gameControl.CoinsSFX);
                    if (value <= 1000)
                    {
                        temp += 100;
                        score4 -= 100;
                    }
                    else if (value <= 10000)
                    {
                        temp += 100;
                        score4 -= 100;
                    }
                    else if (value <= 100000)
                    {
                        temp += 1000;
                        score4 -= 1000;
                    }
                    else if (value <= 1000000)
                    {
                        temp += 10000;
                        score4 -= 10000;
                    }
                    else if (value <= 10000000)
                    {
                        temp += 100000;
                        score4 -= 100000;
                    }
                    else
                    {
                        temp += 100000;
                        score4 -= 100000;
                    }
                    player4Score.text = score4.ToString();
                    yield return new WaitForSeconds(0.01f);
                }
                break;
        }
        temp = 0;
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

    public static int returnPlayerIndex(int player)
    {
        int value = 1;
        switch (player)
        {
            case 1:
                value = player1StartWaypoint;
                break;
            case 2:
                value = player2StartWaypoint;
                break;
            case 3:
                value = player3StartWaypoint;
                break;
            case 4:
                value = player4StartWaypoint;
                break;
        }
        return value;
    }
}
