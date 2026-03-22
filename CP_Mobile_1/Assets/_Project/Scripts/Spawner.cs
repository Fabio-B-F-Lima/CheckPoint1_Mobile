using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnsPositions;
    [SerializeField] private GameObject[] itensPrefabs;
    GameObject item;

    private int lastSpawn = -1;

    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    void Spawn()
    {
        int spawnIndex;
        do
        {
            spawnIndex = Random.Range(0, spawnsPositions.Length);
        }
        while (spawnIndex == lastSpawn);

        lastSpawn = spawnIndex;

        int r = Random.Range(0, 101);

        if (r < 45)
        {
            item = itensPrefabs[0];
        }
        else if (r < 65)
        {
            item = itensPrefabs[1];
        }
        else if (r < 75)
        {
            item = itensPrefabs[2];
        }
        else if (r < 90)
        {
           item = itensPrefabs[3];
        }
        else
        {
            item = itensPrefabs[4];
        }

        GameObject obj = Instantiate(item, spawnsPositions[spawnIndex].position, Quaternion.identity);
        Destroy(obj, 5f);
    }

    IEnumerator SpawnItem()
    {
        Spawn();
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SpawnItem());
    }

}