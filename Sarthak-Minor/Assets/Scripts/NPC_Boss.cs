using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Boss : MonoBehaviour
{
    public List<Transform> spawnPoints;
    int current = 0;
    public float speed;
    float radius = 1f;
    float yPos;
    private void Start()
    {
        yPos = transform.position.y;
        transform.position = spawnPoints[current].position;
    }
    void Update()
    {
        if (Vector3.Distance(spawnPoints[current].position, transform.position) < radius)
        {
            //current = Random.Range(0, spawnPoints.Count);
            current = current + 1;
            if (current >= spawnPoints.Count)
            {
                current = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, spawnPoints[current].position, Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        transform.LookAt(spawnPoints[current].position);
    }
}
