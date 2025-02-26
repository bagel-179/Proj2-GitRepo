using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;   
    public bool isStopped;
    private NavMeshAgent agent;
    private MeshRenderer mesh;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
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
            StartCoroutine(frozen());
            //start a coroutine for how long you will be frozen for
            // iterate on idea to make that time more interactive for the player
            //there also needs to be a lock out/cooldown on this coroutine
        }
        
        
    }

    public IEnumerator frozen()
    {
        float stunTimer = Random.Range(1, 3);
        //changes something about the manniquin
        // change color
        
        yield return new WaitForSeconds(stunTimer);
        agent.isStopped = false;
    }
}
