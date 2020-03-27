using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();

    private NavMeshAgent mNavMeshAgent => GetComponent<NavMeshAgent>();
    public int curWaypointIndex;

    void Start()
    {
        mNavMeshAgent.SetDestination(waypoints[0].position);
    }
    
    void Update()
    {
        if (mNavMeshAgent.remainingDistance< mNavMeshAgent.stoppingDistance) {
            curWaypointIndex = (curWaypointIndex + 1) % waypoints.Count;
            mNavMeshAgent.SetDestination(waypoints[curWaypointIndex].position);
        }
    }
}
