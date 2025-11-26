using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	Vector2 moveDir;
	Vector3 initialTarget;
	public float moveSpeed = 1.0f;
	Rigidbody2D rb;
	BoxCollider2D collider;
	SpriteRenderer sprite;

	enum MoveState
	{
		Idle,
		ToInitial,
		ToPlayer,
	}

	MoveState state = MoveState.Idle;

	public Transform target { get; set; }

	public bool IsActive {
		get {
			return collider.enabled;
		}
		set {
				collider.enabled = value;
				sprite.enabled = value;
		}
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		collider = GetComponent<BoxCollider2D> ();
		if (collider == null) {
			Debug.LogWarning ("No collider on enemy!");
		}
		sprite = GetComponent<SpriteRenderer> ();
	}

	public void Activate()
	{
		// Get random target on map from Spawn Point
		// leveys 18, korkeus 10, keskipiste (0,0)
		Vector3 pos = transform.position;
		Vector3 toCenter = -pos;
		toCenter.Normalize ();
		float angle = (Random.value - 0.5f) * 2 * 15.0f;
		Quaternion offsetAngle = Quaternion.AngleAxis (angle, Vector3.forward);
		Vector3 dir = offsetAngle * toCenter;

		float distance = Random.value * 8.0f;
		initialTarget = pos + dir * distance;

		state = MoveState.ToInitial;
		// Reach target before going towards player
	}
	
	// Update is called once per frame
	void Update () {
		if (IsActive == false) {
			return;
		}
		if (state == MoveState.ToInitial) {

			moveDir = initialTarget - transform.position;

			Debug.DrawRay (transform.position, initialTarget-transform.position);
			// How to know I am at target?
			if (moveDir.magnitude < 0.01f) {
				state = MoveState.ToPlayer;
			}
		}
		else if (state == MoveState.ToPlayer) {
			moveDir = target.position - transform.position;
		}
		moveDir.Normalize ();
		rb.MovePosition (rb.position + moveDir * moveSpeed * Time.deltaTime);
	}
}
