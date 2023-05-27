using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private int moveSpeed;
    private int currentIndex = 0;

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(this.transform.position, waypoints[currentIndex].transform.position) < .1f) {
            currentIndex++;
            if (currentIndex >= waypoints.Length) {
                currentIndex = 0;
            }
        }
        this.transform.position = Vector2.MoveTowards(transform.position, waypoints[currentIndex].transform.position, moveSpeed * Time.deltaTime);
        
    }
}
