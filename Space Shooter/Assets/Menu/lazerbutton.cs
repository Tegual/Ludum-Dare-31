using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lazerbutton : MonoBehaviour 
{
	Text txt;
	public int lazerlevel = 1;
	public float cost = 100;
	public float Points;
	public GameObject db;
	public GameObject player;

	public AudioClip nope;
	public AudioClip yep;

	// Use this for initialization
	void Start () 
	{
		txt = gameObject.GetComponent<Text>();
		txt.text="Lazer Upgrade: " + lazerlevel + "\n" + "Cost: " + cost;
	}

	public void lazlevel()
	{
		if (Points >= cost)
		{
			lazerlevel++;
			AudioSource.PlayClipAtPoint(yep,transform.position);
			cost = cost * 2.5f;
			txt.text="Lazer Upgrade: " + lazerlevel + "\n" + "Cost: " + cost;
			player.SendMessage("lazerup");

			if (lazerlevel >= 3)
			{
				txt.text="Lazer Upgrade: 3" + "\n" + "Max";
			}
			return;
		}
		else
		{
			AudioSource.PlayClipAtPoint(nope,transform.position);
		}

	}

	// Update is called once per frame
	void Update () 
	{
		if (db == null)
		{
			db = GameObject.Find ("_Scripts&GUI");
		}
		if (player == null)
		{ 
			player = GameObject.FindGameObjectWithTag("Player");
		}
		Points = db.GetComponent<Upgrades>().points;
		if (Input.GetKeyDown(KeyCode.Q))
		{
			db.SendMessage("LazerUpgrade");
			lazlevel();

		}
	}
}