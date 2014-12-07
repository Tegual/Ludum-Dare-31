using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour 
{

	public float enemyroation = 90f;
	public float eSpeed = 5f;

	Transform playerpos;

	// Use this for initialization
	void Start () 
	{
		gameObject.layer = 9;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		Vector3 position = transform.position;
		
		Vector3 velocity = new Vector3(0, -eSpeed * Time.deltaTime, 0);
		
		position += transform.rotation * velocity;
		
		transform.position = position;

		if (playerpos == null)
		{
			GameObject pos = GameObject.FindWithTag ("Player");
			
			if (pos != null)
			{
				playerpos = pos.transform;
			}
			if (playerpos == null)
			{
				return;
			}
		}

		Vector3 fDirection = playerpos.position - transform.position;
		fDirection.Normalize();

		float fZ = Mathf.Atan2(fDirection.y, fDirection.x) * Mathf.Rad2Deg -270f;

		Quaternion fRotation = Quaternion.Euler(0,0, fZ);

		transform.rotation = Quaternion.RotateTowards(transform.rotation, fRotation , enemyroation * Time.deltaTime);	




	}
}
