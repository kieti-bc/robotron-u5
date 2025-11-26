using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Rigidbody2D rb;
	Collider2D collider;
	SpriteRenderer sprite;
	public bool IsActive {
		get {
			return collider.enabled;
		}
		set {
			collider.enabled = value;
			sprite.enabled = value;
		}
	}

	void Start()
	{
		collider = GetComponent<Collider2D> ();
		sprite = GetComponent<SpriteRenderer> ();
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		Enemy e = other.gameObject.GetComponent<Enemy>();
		if (e != null) {
			e.IsActive = false;
			IsActive = false;
		}
		//Destroy (other.gameObject);
	}
}
