using UnityEngine;
using System.Collections;

public class PLayer_Shoot : MonoBehaviour 
{
	public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

	public Vector3 bulletOffsetl = new Vector3(-0.5f, 0.5f, 0);
	public Vector3 bulletOffsetr = new Vector3(0.5f, 0.5f, 0);

	public AudioClip shoot;
	public AudioClip shield;

	public GameObject db;

	public GameObject pBullet;
	public float fireDelay = 0.25f;
	public float cooldownTimer = 0.2f;

	public int lazerLevel = 1;

	public float intimer = 0;
//	public float binvultimer = 0;

	public int bomb = 0;

	public bool invul = false;

	void Start() 
	{
		if (db == null)
		{
			db = GameObject.Find("_Scripts&GUI");
		}
		gameObject.layer = 8;
		lazerLevel = db.GetComponent<Upgrades>().lazerlevel;
	}

	public void binvul()
	{
		invul = true;
		intimer = 3;
	}

	void lazerup()
	{
		lazerLevel++;
	}

	void Update () 
	{
		if (db == null)
		{
			db = GameObject.Find("_Scripts&GUI");
		}

		if (cooldownTimer >= 0)
		{
			cooldownTimer -= Time.smoothDeltaTime;
			
			if(Input.GetButton("Fire1") && lazerLevel == 1 && cooldownTimer <= 0) 
			{
				cooldownTimer = fireDelay;
				Vector3 offset = transform.rotation * bulletOffset;
				AudioSource.PlayClipAtPoint(shoot, transform.position);
				Instantiate(pBullet, transform.position + offset, transform.rotation);
			}

			if(Input.GetButton("Fire1") && lazerLevel == 2 && cooldownTimer <= 0) 
			{
				cooldownTimer = fireDelay;
				Vector3 offsetl = transform.rotation * bulletOffsetl;
				Vector3 offsetr = transform.rotation * bulletOffsetr;
				AudioSource.PlayClipAtPoint(shoot, transform.position);
				Instantiate(pBullet, transform.position + offsetl, transform.rotation);
				Instantiate(pBullet, transform.position + offsetr, transform.rotation);
			}

			if(Input.GetButton("Fire1") && lazerLevel == 3 && cooldownTimer <= 0) 
			{
				cooldownTimer = fireDelay;
				Vector3 offsetl = transform.rotation * bulletOffsetl;
				Vector3 offsetr = transform.rotation * bulletOffsetr;
				Vector3 offset = transform.rotation * bulletOffset;
				AudioSource.PlayClipAtPoint(shoot, transform.position);
				Instantiate(pBullet, transform.position + offset, transform.rotation);
				Instantiate(pBullet, transform.position + offsetl, transform.rotation);
				Instantiate(pBullet, transform.position + offsetr, transform.rotation);
			}
		}
		if (cooldownTimer < 0)
		{
			cooldownTimer = 0;
		}
		if (intimer < 0)
		{
			intimer=0;
		}

		if (intimer < 0)
		{
			print ("false");
			gameObject.layer = 8;
			invul = false;
			db.SendMessage ("infalse");
		}
		if(Input.GetButton("Fire2") && invul==true && intimer > 0) 
		{
			while (intimer > 0)
			{
				intimer = intimer - Time.deltaTime;
//				print (invulnerabilitytimer);
				gameObject.layer = 11;
				AudioSource.PlayClipAtPoint(shield,transform.position);
				if(intimer <= 0) 
				{
					print ("false");
					invul = false;
					gameObject.layer = 8;
				}
				return;
			}
		}
		else
		{
			gameObject.layer = 8;
		}
	}
}
