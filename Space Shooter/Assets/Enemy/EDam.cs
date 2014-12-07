using UnityEngine;
using System.Collections;

public class EDam : MonoBehaviour 
{

	public float Health = 1;
	public GameObject db;

	// Use this for initialization
	void Start () 
	{
		db = GameObject.Find("_Scripts&GUI");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (Health <=0)
		{
			Death();
		}
	}

	void OnTriggerEnter2D ()
	{
		db.SendMessage("AddPoints");
		ApplyDamage();
	}

	void Death ()
	{
		Destroy(gameObject);
	}
	
	void ApplyDamage ()
	{
		Health = Health -1;
	}
}
