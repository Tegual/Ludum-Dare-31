using UnityEngine;
using System.Collections;

public class PlayerDAm : MonoBehaviour 
{

	public float Health = 5;
	public float invulnerabilityperoid = 3;
	public float invulnerabilitytimer = 0;

	LayerMask startlayer;

	SpriteRenderer playerSprite;

	public GameObject db;
	// Use this for initialization
	void Start () 
	{
		if (db == null)
		{
			db = GameObject.Find ("_Scripts&GUI");
			db.SendMessage("Health");
		}
		gameObject.layer = 8;

		startlayer = gameObject.layer;

		playerSprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	void OnTriggerEnter2D()
	{
		ApplyDamage();
		invulnerabilitytimer = invulnerabilityperoid;
//		print (Health);
		if (invulnerabilitytimer > 0)
		{
			invulnerabilitytimer = invulnerabilityperoid;
			this.gameObject.layer = 11;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if (db == null)
		{
			db = GameObject.Find ("_Scripts&GUI");
		}

		if (invulnerabilitytimer > 0)
		{
			this.gameObject.layer = 11;
			invulnerabilitytimer = invulnerabilitytimer - Time.deltaTime;
			if(invulnerabilitytimer <= 0) 
			{
				gameObject.layer = startlayer;

				if(playerSprite != null) 
				{
					playerSprite.enabled = true;
				}
			}
			else 
			{
				if(playerSprite != null) 
				{
					playerSprite.enabled = !playerSprite.enabled;
				}
			}
		}

		if (Health <=0)
		{
			Death();
		}
	}

	void Death ()
	{
		Destroy(gameObject);
	}

	public void HPUP()
	{
		Health++;
	}

	void ApplyDamage ()
	{
		if (invulnerabilitytimer <= 0)
		{
			Health = Health -1;
			db.SendMessage("Health");
		}
	}
}
