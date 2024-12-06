using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSpikes : MonoBehaviour
{
    public GameObject[] wallPrefabs;
    public GameObject spikePrefab;

    public bool isSpawning = false;
    public float spawnDelay = 2f;
    public float spawnRotation = -90f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSpawning)
        {
            isSpawning = true;

            float selectedWall = Random.Range(0, 1) == 0 ? -3f : 3f;

             Vector2 randomSpawnPostion = new Vector2(selectedWall, Random.Range(10, 15));
            // Quaternion rotation = Quaternion.Euler(0f, 0f, spawnRotation);
            

            Instantiate(spikePrefab, randomSpawnPostion, Quaternion.identity);
            StartCoroutine(ResetSpawn());
        }
    }

    private IEnumerator ResetSpawn()
    {
        yield return new WaitForSeconds(spawnDelay);
        isSpawning = false;
        
    }

}
