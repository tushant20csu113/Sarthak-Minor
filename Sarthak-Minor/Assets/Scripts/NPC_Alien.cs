using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Alien : MonoBehaviour
{
    public List<Transform> spawnPoints;
    int current = 1;
    public float radius = 2;
    Animator anim;
    private NavMeshAgent agent;
    bool isReached;
    float yPos;
    public int indexToDance;
    private void Start()
    {
        yPos = transform.position.y;
        transform.position = spawnPoints[0].position;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.SetDestination(spawnPoints[current].position);
        anim.SetBool("Run", true);
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        if (Vector3.Distance(spawnPoints[current].position, transform.position) < radius && !isReached)
        {
            if (current == indexToDance)
                StartCoroutine(Follow(5));
            else
            {
                StartCoroutine(NextPoint(2));
            }
        }

    }
    IEnumerator NextPoint(float timeToWait)
    {
        anim.SetBool("Run", false);
        isReached = true;
        yield return new WaitForSeconds(timeToWait);
        current++;
        //current = Random.Range(0, spawnPoints.Count + 1);
        if (current >= spawnPoints.Count)
        {
            current = 0;
        }
        transform.LookAt(spawnPoints[current].position);
        anim.SetBool("Run", true);
        agent.SetDestination(spawnPoints[current].position);
        isReached = false;
    }

    IEnumerator Follow(float timeToWait)
    {

        anim.SetBool("Run", false);
        anim.SetBool("Dance", true);
        isReached = true;
        yield return new WaitForSeconds(timeToWait);
        anim.SetBool("Dance", false);
        current++;
        //current = Random.Range(0, spawnPoints.Count + 1);
        if (current >= spawnPoints.Count)
        {
            current = 0;
        }
        transform.LookAt(spawnPoints[current].position);
        anim.SetBool("Run", true);
        agent.SetDestination(spawnPoints[current].position);
        isReached = false;

    }
}
