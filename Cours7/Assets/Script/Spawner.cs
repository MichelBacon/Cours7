using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float spawnRate = 1;
    private float timeLeftBeforeSpawn = 0;
    private SpawnPoint[] spawnPoints;
    public GameObject ennemiPrefab;
    public GameObject ennemiSlimePrefab;

	// Use this for initialization
	void Start () {
        spawnPoints = FindObjectsOfType<SpawnPoint>();
        timeLeftBeforeSpawn = 1 / spawnRate;
    }
	
	// Update is called once per frame
	void Update () {
        UpdateSpawn();

    }

    private void UpdateSpawn()
    {
        timeLeftBeforeSpawn -= Time.deltaTime;
        if (timeLeftBeforeSpawn < 0)
        {
            SpawnCube();
            SpawnSlime();
            timeLeftBeforeSpawn = 1 / spawnRate;
        }
    }

    private void SpawnCube()
    {
        int countSpawnPoint = spawnPoints.Length;
        int randomSpawnPointIndex = Random.Range(0, countSpawnPoint);
        SpawnPoint spawnPointRandomlySelected = spawnPoints[randomSpawnPointIndex];
        GameObject newCube = Instantiate(ennemiPrefab,spawnPointRandomlySelected.GetPosition(), spawnPointRandomlySelected.transform.rotation);
        GameObject newSlime = Instantiate(ennemiSlimePrefab, spawnPointRandomlySelected.GetPosition(), spawnPointRandomlySelected.transform.rotation);
    }
    private void SpawnSlime()
    {
        Vector3 slimeSpawn = new Vector3(20,0,0);
        int countSpawnPoint = spawnPoints.Length;
        int randomSpawnPointIndex = Random.Range(0, countSpawnPoint);
        SpawnPoint spawnPointRandomlySelected = spawnPoints[randomSpawnPointIndex];
        GameObject newSlime = Instantiate(ennemiSlimePrefab, spawnPointRandomlySelected.GetPosition()+slimeSpawn, spawnPointRandomlySelected.transform.rotation);
        GameObject newSlime2 = Instantiate(ennemiSlimePrefab, spawnPointRandomlySelected.GetPosition(), spawnPointRandomlySelected.transform.rotation);
    }
}
