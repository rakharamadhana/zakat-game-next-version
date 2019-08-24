using UnityEngine;

public class FollowThePath : MonoBehaviour {

    public Transform[] waypoints;
    public AudioClip movementSound;

    private AudioSource source;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;

	// Use this for initialization
	private void Start () {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = movementSound;
        source.playOnAwake = false;
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	private void Update () {
        if (moveAllowed)
            Move();
	}

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
            //Debug.Log(waypoints.Length);
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                source.PlayOneShot(movementSound);
                waypointIndex += 1;
            }

            if (waypointIndex == 4)
            {
                Debug.Log(waypointIndex);
                //Debug.Log("Step On 5");
            }

            if (transform.position == waypoints[9].transform.position)
            {
                Debug.Log(GameControl.diceSideThrown);
                Debug.Log("Step On 10");
            }

        }
    }
}
