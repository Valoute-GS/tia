using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public Camera cam;

    public List<NavMeshAgent> agents;

    private void Start()
    {
        foreach (NavMeshAgent agent in agents)
            agent.SetDestination(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        foreach (NavMeshAgent agent in agents)
            agent.SetDestination(new Vector3(0, 0, 0));
    }
}