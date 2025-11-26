using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEffect : MonoBehaviour {

	float effectElapsed;
	public float effectDuration;
	public bool IsActive { get; private set; }
	// Use this for initialization
	void Start () {
		
	}

	void Activate()
	{
		effectElapsed = 0;
		IsActive = true;
	}

	// Update is called once per frame
	void Update () {
		if (effectElapsed < effectDuration) {
			effectElapsed += Time.deltaTime;
		}
		else
		{
			// effect ends
			IsActive = false;
		}
		
	}
}
