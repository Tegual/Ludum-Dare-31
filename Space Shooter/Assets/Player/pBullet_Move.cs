using UnityEngine;
using System.Collections;

public class pBullet_Move : MonoBehaviour 
{
	public float speed = 8f;
	float Health = 1;

	void Start ()
	{
		gameObject.layer = 8;
	}

	// Update is called once per frame
	void Update () 
	{
		Vector3 position = transform.position;
		
		Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0);
		
		position += transform.rotation * velocity;
		
		transform.position = position;

		if (Health <= 0)
		{
			Die();
		}
	}

	void Die ()
	{
		Destroy (gameObject);
	}

	void ApplyDamage ()
	{
		Health = Health -1;
	}
	void OnTriggerEnter2D ()
	{
		print (transform.collider2D.name);
		transform.collider2D.SendMessage("ApplyDamage");
		ApplyDamage();
	}
}
