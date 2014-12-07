using UnityEngine;
using System.Collections;

public class eBull_Move : MonoBehaviour 
{
	public float speed = 8f;
	float Health = 1f;

	void Start ()
	{
		gameObject.layer = 9;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 position = transform.position;
		
		Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0);
		
		position -= transform.rotation * velocity;
		
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
		transform.collider2D.SendMessage("ApplyDamage");
		ApplyDamage();
	}
}
