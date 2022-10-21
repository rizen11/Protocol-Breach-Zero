using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private GameObject trigger1;
    [SerializeField] private GameObject trigger2;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
    
    /*void Start()
    {
        
    }*/

    
    void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f && Input.GetKeyDown("f")
         && Vector2.Distance(player.transform.position, transform.position) <= 1.5f) {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length) {
                currentWaypointIndex = 0;
            }
        }
        //Debug.Log(Vector2.Distance(player.transform.position, transform.position));
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        other.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D other) {
        other.transform.SetParent(null);
    }
}
