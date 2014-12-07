using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InvulButton : MonoBehaviour 
{
	Text txt;

	public GameObject db;

	public float Points = 0;

	public float inperoid = 3;
	public float intimer = 0 ;

	public AudioClip nope;
	public AudioClip yep;

	public bool invulavable = false;

	float costlevel = 1;

	public float cost = 200;

	string dtime;

	// Use this for initialization
	void Start () 
	{
		txt = gameObject.GetComponent<Text>();
		txt.text="Shields " + cost;
	}

	void timeset ()
	{
		if (Points >= cost)
		{
			if (invulavable == false)
			{
				invulavable = true;
				AudioSource.PlayClipAtPoint(yep,transform.position);
				intimer = inperoid;
				txt.text="Shields " + cost * costlevel;
				costlevel = costlevel * 1.5f;
			}

			if (invulavable == true)
			{
				dtime = intimer.ToString();
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

		Points = db.GetComponent<Upgrades>().points;
		if (invulavable == true)
		{
			txt.text="Shields"+ "\n" + "Time Left " + dtime;
		}
		if (intimer <= 0)
		{
			txt.text="Shields " +"\n" + "Cost: "+ cost * costlevel;
			invulavable = false;
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			db.SendMessage("invul");
			timeset();

		}
		if (invulavable == true)
		{
			if (intimer > 0 && Input.GetButton("Fire2"))
			{
				StartCoroutine (cotime());
				txt.text="Invulnerabilty " + "\n" + "   Time Left " + dtime;
			}
			if (intimer <= 0 && Input.GetButton("Fire2"))
			{
				txt.text="Invulnerabilty "+ "\n"+ "Cost: " + cost * costlevel;
			}
		}

	}

	IEnumerator cotime()
	{
		while (intimer > 0)
		{
			yield return new WaitForSeconds (1);
			dtime = intimer.ToString();
			intimer -= 1;
		}
	}
}
