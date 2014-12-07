using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lives : MonoBehaviour 
{
	int Life = 4;

	public float Points = 0;

	Text txt;

	public GameObject db;

	public GameObject spawn;

	public float cost = 250;

	public AudioClip nope;
	public AudioClip yep;

	// Use this for initialization
	void Start () 
	{
		txt = gameObject.GetComponent<Text>();
		db = GameObject.Find ("_Scripts&GUI");
		spawn = GameObject.Find ("_PlayerSpawn");
		txt.text = "Lives: " + Life + "\n" + "Cost: " + cost;
	}
	
	// Update is called once per frame
	void Update () 
	{
		txt.text = "Lives: " + Life + "\n" + "Cost: " + cost;
		Points = db.GetComponent<Upgrades>().points;
		if (Input.GetKeyDown(KeyCode.T))
		{
			db.SendMessage("downlife");
			setup();
		}
	}

	public void lifeset ()
	{
		Life --;
		db.SendMessage("downlife");
	}

	public void setup ()

	{
		if (Points >= cost)
		{
			Life++;
			AudioSource.PlayClipAtPoint(yep,transform.position);
			db.SendMessage("addlife");
			spawn.SendMessage("lifeadd");
			cost = cost * 2;
		}
		else
		{
			AudioSource.PlayClipAtPoint(nope,transform.position);
		}

	}
}
