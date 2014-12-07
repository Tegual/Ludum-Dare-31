using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour 
{
	public float wintimer = 300;
	string passtime;
	public GameObject db;
	public AudioClip winner;
	Text txt;

	// Use this for initialization
	void Start () 
	{
		db = GameObject.Find("_Scripts&GUI");
		txt = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (wintimer > 0)
		{
			//StartCoroutine (cotime());
			passtime = wintimer.ToString("f0");
			wintimer = wintimer - Time.deltaTime;
			txt.text="Time till Repaired: "  + passtime;
		}
		if (wintimer <= 0)
		{
			db.SendMessage("youwin");
			AudioSource.PlayClipAtPoint(winner, transform.position);
			Time.timeScale = 0;
		}
	}

}
