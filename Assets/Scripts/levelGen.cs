using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class levelGen : MonoBehaviour
{
    public GameObject player;
    public Transform startingPart;
    public List<Transform> levelPartList;
    public int startingAmount = 5;
    public const float playerDistanceSpawn = 200f;

    private Vector3 endPointPos;

    // Awake is called when the script starts
    void Awake()
    {
        endPointPos = startingPart.Find("Spawn Location").position;

        for (int i = 0; i < startingAmount; i++)
        {
            spawnLevelPart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, endPointPos) < playerDistanceSpawn)
        {
            spawnLevelPart();
        }
    }

    private void spawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = spawnLevelPart(chosenLevelPart, endPointPos);
        endPointPos = lastLevelPartTransform.Find("Spawn Location").position;
    }

    private Transform spawnLevelPart(Transform part, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(part, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
