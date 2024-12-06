using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSpikes : MonoBehaviour
{
    public GameObject[] wallPrefabs;
    public GameObject spikePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnSpikes());
    }

    private IEnumerator SpawnSpikes()
    {
        yield return new WaitForSeconds(3f);
        
    }

}
