using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject enemyPrefab;
	List<Enemy> spawnedEnemies;

	GameObject player;

	public int spawnAmount = 1;
	public float spawnInterval;
	float lastSpawnTime = 0;
	// Use this for initialization
	void Start () {
		spawnedEnemies = new List<Enemy> ();
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnAmount <= 0) {
			return;
		}
		if (Time.time - lastSpawnTime > spawnInterval) {
			lastSpawnTime = Time.time;
			// find first inactive enemy
			bool spawned = false;
			Enemy ec = null;
			for (int i = 0; i < spawnedEnemies.Count; i++) {
				if (spawnedEnemies [i].IsActive == false) {
					ec = spawnedEnemies [i];
					ec.transform.position = transform.position;
					spawned = true;
					break;
				}
			}
			if (!spawned) {
				GameObject e = Instantiate (enemyPrefab, transform.position, Quaternion.identity);
				ec = e.GetComponent<Enemy> ();
				ec.target = player.transform;
				spawnedEnemies.Add (ec);
			}

			ec.Activate ();
			spawnAmount -= 1;
		}
		
	}
}
