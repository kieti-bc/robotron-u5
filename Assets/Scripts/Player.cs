using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	SpriteRenderer sprite;
	Rigidbody2D rigidBody;

	public GameObject bulletPrefab;
	List<Bullet> spawnedBullets;

	public float moveSpeed = 0.0f;
	public float shootSpeed = 0.0f;

	Vector2 lastShootDir = Vector2.zero;
	public float shootInterval = 0.1f;
	float lastShootTime = 0;
	void Start () {
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		rigidBody = GetComponent<Rigidbody2D> ();
		spawnedBullets = new List<Bullet> ();
	}

	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		Vector2 pos = rigidBody.position;
		pos.x += inputX * moveSpeed * Time.deltaTime;
		pos.y += inputY * moveSpeed * Time.deltaTime;
		rigidBody.MovePosition(pos);

		float shootX = Input.GetAxis ("RightStickHorizontal");
		float shootY = Input.GetAxis ("RightStickVertical");

		if (Mathf.Abs (shootX) > 0.1f || Mathf.Abs (shootY) > 0.1f) {
			if (Time.time - lastShootTime > shootInterval)
			{
				lastShootTime = Time.time;
				Vector2 shootdir = new Vector2 (shootX, shootY);
				shootdir.Normalize ();

				Bullet bullet = null;
				for (int i = 0; i < spawnedBullets.Count; i++) {
					if (spawnedBullets [i].IsActive == false) {
						spawnedBullets [i].transform.position = transform.position;
						spawnedBullets [i].IsActive = true;
						bullet = spawnedBullets [i];
						break;
					}
				}
				if (!bullet) {
					GameObject bbullet = Instantiate (bulletPrefab, transform.position, Quaternion.identity);
					bullet = bbullet.GetComponent<Bullet> ();
					spawnedBullets.Add (bullet);
				}
				Rigidbody2D bulletRb = bullet.gameObject.GetComponent<Rigidbody2D> ();
				bulletRb.velocity = Vector2.zero;
				bulletRb.AddForce (shootdir * shootSpeed);
			}
		}

		lastShootDir = new Vector2 (shootX, shootY);
	}

	void OnGUI()
	{
		GUI.Label( new Rect(10, 10, 100, 20), string.Format("Shoot dir: {0}, {1}", lastShootDir.x, lastShootDir.y));
	}
}
