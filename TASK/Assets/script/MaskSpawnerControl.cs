using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskSpawnerControl : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject virus;
    int randomSpawnPoint;
	public static bool spawnAllowed;
    private GameObject[] gos;


	// Use this for initialization
	void Start () {
		

	}
     void Update()
    {
       
        gos = GameObject.FindGameObjectsWithTag("virus");
        if (gos.Length < 20)
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
			
			Instantiate (virus, spawnPoints [randomSpawnPoint].position,
				Quaternion.identity);
		}
	}

}
