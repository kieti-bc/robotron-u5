using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletArea : MonoBehaviour {



	void OnTriggerExit2D(Collider2D other)
	{
		other.GetComponent<Bullet> ().IsActive = false;
	}
}
