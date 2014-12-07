using UnityEngine;
using System.Collections;

public class Enemy_Shoot : MonoBehaviour 
{

	public Vector3 bulletOffset = new Vector3(0, -0.5f, 0);
	
	public GameObject eBullet;

	public float shotDelay = 0.50f;
	public float coolDown = 0;
	public float shootRange = 4f;

	Transform playerpos;

	public AudioClip lazer;

	void Start() 
	{
		gameObject.layer = 9;
	}

	// Update is called once per frame
	void Update () 
	{

		if(playerpos == null) 
		{
			GameObject player = GameObject.FindWithTag ("Player");
			
			if(player != null) 
			{
				playerpos = player.transform;
			}
		}
		coolDown = coolDown - Time.deltaTime;
		
		if( coolDown <= 0 && playerpos != null && Vector3.Distance(transform.position, playerpos.position) < shootRange) 
		{
			coolDown = shotDelay;
			Vector3 offset = transform.rotation * bulletOffset;
			AudioSource.PlayClipAtPoint(lazer,transform.position);
			Instantiate(eBullet, transform.position + offset, transform.rotation);
		}
	}
}
