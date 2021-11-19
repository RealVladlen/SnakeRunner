using UnityEngine;
using System.Collections.Generic;

public class SpawnerLocation : MonoBehaviour
{
    public Transform player;

    public Location[] locationPrefabs;

    public Location firstChunk;

    public List<Location> spawnedChunks = new List<Location>();

    [SerializeField] private int _countChunks;


    private void Start()
    {
        spawnedChunks.Add(firstChunk);
    }

    void Update()
    {
        if (player.position.z > spawnedChunks[spawnedChunks.Count - 1]._begin.position.z - 130)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        Location newChunk = Instantiate(locationPrefabs[Random.Range(0, locationPrefabs.Length)]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1]._end.position - newChunk._begin.localPosition;
        spawnedChunks.Add(newChunk);

        if (spawnedChunks.Count >= _countChunks)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }
}
