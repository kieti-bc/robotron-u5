using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHost : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] spawners = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject s in spawners) {
			Spawn es = s.GetComponent<Spawn> ();
			if (es) {
				es.spawnAmount = 10;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
