using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowThePath : MonoBehaviour {

    //public Transform[] waypoints;
    public List<GameObject> waypoints = new List<GameObject>();
    GameObject player1, player2, player3, player4;

    public int player;

    private GameObject playerMoving;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;

	// Use this for initialization
	private void Start () {
        /* foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("WayPoint")){
			waypoints.Add(fooObj);
		}
        waypoints.Reverse(); */
        player1 = GameObject.Find("Player1Sprite");
        player2 = GameObject.Find("Player2Sprite");
        player3 = GameObject.Find("Player3Sprite");
        player4 = GameObject.Find("Player4Sprite");

        transform.position = waypoints[waypointIndex].transform.position;

	}
	
	// Update is called once per frame
	private void Update () {

        if (player == 1)
        {
            playerMoving = player1;
        }

        if (player == 2)
        {
            playerMoving = player2;
        }

        if (player == 3)
        {
            playerMoving = player3;
        }

        if (player == 4)
        {
            playerMoving = player4;
        }

        if (moveAllowed){
            
            Move();
        }
        
	}

    private void Move()
    {

        if (waypointIndex <= waypoints.Count - 1)
        {
            //LadderCheck();
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);
            //Debug.Log(transform.position + waypoints[waypointIndex].transform.position);
            

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                this.GetComponent<AudioSource>().Play();
                waypointIndex += 1;
            }
        }
        


    }

        
}

