using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalker : MonoBehaviour
{
    private Path currentPath;
    private int currentWaypointIndex = -1;
    public float speed = 2f;
    public float waypointTolerance = 1f;
    public List<GameObject> pathPrefabs;    
    
    void Start()
    {
        GameObject pathGO = Instantiate(pathPrefabs[Random.Range(0, pathPrefabs.Count)]);
        currentPath = pathGO.GetComponent<Path>();
    }

    void Update()
    {
        if (currentPath.waypoints.Count == 0) return;
        if (currentWaypointIndex == -1 || Vector3.Distance(transform.position, currentPath.waypoints[currentWaypointIndex].position) < waypointTolerance)
        {
            if (currentWaypointIndex == -1)
            {
                currentWaypointIndex = Random.Range(0, currentPath.waypoints.Count);
            }
            else
            {
                int nextWaypointIndex = currentPath.waypoints[currentWaypointIndex].GetRandomConnectedWaypointIndex();
                if (nextWaypointIndex != -1) 
                {
                    currentWaypointIndex = nextWaypointIndex;
                }
                else
                {
                    currentWaypointIndex = Random.Range(0, currentPath.waypoints.Count);
                }
            }
        }
        Vector3 waypointPosition = currentPath.waypoints[currentWaypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, waypointPosition, speed * Time.deltaTime);
    }
}
