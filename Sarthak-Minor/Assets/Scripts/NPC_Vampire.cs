using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Vampire : MonoBehaviour
{
    public List<Transform> spawnPoints;
    int current = 1;
    public float radius = 2;
    Animator anim;
    private NavMeshAgent agent;
    bool isReached;
    private void Start()
    {
        transform.position = spawnPoints[0].position;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.SetDestination(spawnPoints[current].position);
        anim.SetBool("isRunning", true);
    }
    void Update()
    {

        if (Vector3.Distance(spawnPoints[current].position, transform.position) < radius && !isReached)
        {
            StartCoroutine(Follow(3));
        }
    }

    IEnumerator Follow(float timeToWait)
    {

        anim.SetBool("isRunning", false);
        isReached = true;
        yield return new WaitForSeconds(timeToWait);
        current = Random.Range(0, spawnPoints.Count + 1);
        if (current >= spawnPoints.Count)
        {
            current = 0;
        }
        transform.LookAt(spawnPoints[current].position);
        anim.SetBool("isRunning", true);
        agent.SetDestination(spawnPoints[current].position);
        isReached = false;

    }
}
