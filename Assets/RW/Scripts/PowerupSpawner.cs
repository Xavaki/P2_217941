using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{

    public bool canSpawn = true;
    public GameObject PowerupPrefab;
    public List<Transform> PowerupSpawnPositions = new List<Transform>();
    public int powerupsPerLevel;
    private int powerupCount;
    public Vector3 prefabOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn && powerupCount < powerupsPerLevel)
        {
            Vector3 randomPosition = PowerupSpawnPositions[Random.Range(0, PowerupSpawnPositions.Count)].position;
            GameObject powerup = Instantiate(PowerupPrefab, randomPosition + prefabOffset, PowerupPrefab.transform.rotation);
            canSpawn = false;
        }
        
    }
}
