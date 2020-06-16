using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskSpawnerControl : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject mask;
    int randomSpawnPoint;
	public static bool spawnAllowed;
    private GameObject[] gos;


	// Use this for initialization
	void Start () {
		

	}
     void Update()
    {
       
        gos = GameObject.FindGameObjectsWithTag("mask");
        if (gos.Length < 1)
        {
            spawnAllowed = true;
             SpawnAMonster();
        }
        else
        {
            spawnAllowed = false;

        }

    }
    void SpawnAMonster()
	{
		if (spawnAllowed) {
			randomSpawnPoint = Random.Range (0, spawnPoints.Length);
			
			Instantiate (mask, spawnPoints [randomSpawnPoint].position,
				Quaternion.identity);
		}
	}

}
