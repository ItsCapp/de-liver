using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawnlevel : MonoBehaviour
{
    public GameObject spawn;
    public GameObject liverRoom;

    public GameObject[] prefabs;
    public GameObject[] prefabsescape;

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
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("connector").position);

        lastLevelPartTransform = Instantiate(liverRoom, lastLevelPartTransform.Find("connector").position, Quaternion.identity).transform;
        lastLevelPartTransform = SpawnEscapeLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnEscapeLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnEscapeLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnEscapeLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnEscapeLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnEscapeLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnEscapeLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnEscapeLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnEscapeLevelPart(lastLevelPartTransform.Find("connector").position);
        lastLevelPartTransform = SpawnEscapeLevelPart(lastLevelPartTransform.Find("connector").position);
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

    private Transform SpawnEscapeLevelPart(Vector3 spawnPos)
    {
        int spawnedobject = Random.Range(0, 3);

        Transform levelPartTransform = Instantiate(prefabsescape[spawnedobject], spawnPos, Quaternion.identity).transform;
        return levelPartTransform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
