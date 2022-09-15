using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private Transform waypointTarget;
    private NavMeshAgent npcNavMesh;

    private void Awake()
    {
        npcNavMesh = GetComponent<NavMeshAgent>();
    }

    private void Update() 
    {
        npcNavMesh.destination = waypointTarget.position;
    }
}
