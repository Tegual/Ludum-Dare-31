using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPs : MonoBehaviour 
{
	Text txt;

	public GameObject player;
	public float Points;
	public float hit = 5;
	public GameObject db;
	public float cost = 50;

	public AudioClip nope;
	public AudioClip yep;

	void Start () 
	{
		txt = gameObject.GetComponent<Text>();
		txt.text="Health: " + hit;
	}
	
	public void HITP()
	{
		if (Points>= cost)
		{
			if (hit < 3)
			{
				hit++;
				AudioSource.PlayClipAtPoint(yep,transform.position);
				cost = cost * 1.25f;
				txt.text="Health: " + hit + "\n" +"Cost: " + cost.ToString("f0");
				player.GetComponent<PlayerDAm>().SendMessage("HPUP");
			}

			if (hit >= 3)
			{
				txt.text="Health: " + hit;
			}

		}
		else
		{
			AudioSource.PlayClipAtPoint(nope,transform.position);
		}
	}
	void Update () 
	{
		if (db == null)
		{
			db = GameObject.Find ("_Scripts&GUI");
		}
		Points = db.GetComponent<Upgrades>().points;
		if (player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}
		if (player != null) 
		{
			hit = player.GetComponent<PlayerDAm>().Health;
			txt.text="Health: " + hit + "\n" + "Cost: " + cost.ToString("f0");
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			db.SendMessage("Health");
			HITP();
		}
	}
}
