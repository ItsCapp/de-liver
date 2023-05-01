using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnlevel : MonoBehaviour
{
    public GameObject spawn;

    public GameObject[] prefabs;

    private void Awake()
    {
        Transform lastLevelPartTransform;
        lastLevelPartTransform = SpawnLevelPart(spawn.transform.Find("connector").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("connector").position);
    }

    private Transform SpawnLevelPart(Vector3 spawnPos)
    {
        int spawnedobject = Random.Range(0, 6);

        while (spawnedobject == 5 && spawnPos.y <= 12)
        {
            spawnedobject = Random.Range(0, 6);
        }

        Transform levelPartTransform = Instantiate(prefabs[spawnedobject], spawnPos, Quaternion.identity).transform;
        return levelPartTransform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
