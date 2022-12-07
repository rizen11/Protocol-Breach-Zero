using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [Header("Enemies")]
    [SerializeField]
    public List<GameObject> enemies;

    [SerializeField]
    private float speed = 2f;
    public int currentWaypointIndex = 1;

    [SerializeField]
    private GameObject[] waypointsLeft;

    [SerializeField]
    private GameObject[] waypointsRight;

    private Transform doorLeft;
    private Transform doorRight;

    private bool isAction;

    void Start()
    {
        doorLeft = this.gameObject.transform.GetChild(0);
        doorRight = this.gameObject.transform.GetChild(1);
    }

    void Update()
    {
        //if (isAction)
        //{
        Debug.Log(doorLeft.transform.GetChild(0).transform.position);
        doorLeft.transform.GetChild(0).transform.position = Vector2.MoveTowards(
            doorLeft.transform.GetChild(0).transform.position,
            waypointsLeft[currentWaypointIndex].transform.position,
            Time.deltaTime * speed
        );
        doorRight.transform.GetChild(0).transform.position = Vector2.MoveTowards(
            doorRight.transform.GetChild(0).transform.position,
            waypointsRight[currentWaypointIndex].transform.position,
            Time.deltaTime * speed
        );
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entered collision " + other.tag);
        if (other.tag == "Player" && enemies.Count > 0) 
        {
            //isAction = true;
            currentWaypointIndex = 0;
            StartCoroutine(checkEnemies());
        }
    }

    IEnumerator checkEnemies()
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => enemies.Count == 0);
        //isAction = false;
        currentWaypointIndex = 1;
    }

    /*private void OnTriggerStay2D(Collider2D other) {
        Debug.Log(other);
    }

    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("Exited: " + other);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Entered: " + other);
    }*/
}
