using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentSpawn : MonoBehaviour
{
    public GameObject[] SegmentsPossible;
    public bool spawned, segment;
    public int id;
    int roll;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            if (!spawned)
                SpawnSegment();
        }
    }

    void SpawnSegment()
    {
        spawned = true;
        if (!segment)
            Instantiate(SegmentsPossible[Random.Range(0, SegmentsPossible.Length)], transform.position, transform.rotation);
        else
        {
            do
            {
                roll = Random.Range(0, SegmentsPossible.Length);
            } while (roll == id);

            Instantiate(SegmentsPossible[roll], transform.position, transform.rotation);
        }
    }
}
