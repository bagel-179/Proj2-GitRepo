using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;   
    public bool isStopped;
    private NavMeshAgent agent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (!isStopped)
        {
            if (distance > 0)
            {
                agent.destination = player.transform.position;
            }
        }

        if (isStopped)
        {
            agent.isStopped = true;
            //start a coroutine for how long you will be frozen for
            // iterate on idea to make that time more interactive for the player
        }
        
        
    }

    public IEnumerator frozen()
    {
        //changes something about the manniquin

        agent.isStopped = false;
    }
}
