using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Upgrades : MonoBehaviour 
{
	//Text txt;

	public float points = 0;

	public bool win = false;

	public int lazerlevel = 1;

	public int numLives = 3;

	public GameObject player;
	GameObject[] em;

	GameObject instruct;

	public string level = "";

	public float enAmount;

	public float HP;

	public bool invulablity = false;

	public bool paused = false;

	public GameObject wtxt;
	GameObject got;

	Text txt;

	void Awake()
	{

		Time.timeScale = 0;
		paused = true;
	}

	// Use this for initialization
	void Start () 
	{
		txt = GameObject.Find("PointText").GetComponent<Text>();
		got = GameObject.Find("YouWin");
		instruct = GameObject.Find("Panel");
		got.SetActive(false);
	}

	public void youwin()
	{
		win = true;
	}

	public void begingame()
	{
		Time.timeScale = 1;
		instruct.SetActive(false);
	}

	public void retry()
	{
		Application.LoadLevel(level);
	}
	public void AddPoints ()
	{
		points = points + 50;
	}

	public void Health()
	{
		HP = GameObject.Find("HealthText").GetComponent<HPs>().hit;
		if (HP <= 3&&points>=GameObject.Find("HealthText").GetComponent<HPs>().cost)
		{
			points = points - GameObject.Find("HealthText").GetComponent<HPs>().cost;
			HP++;
		}
	}

	public void downlife()
	{
		numLives --;
	}

	public void addlife ()
	{
		if (points>=GameObject.Find("LifeText").GetComponent<Lives>().cost)
		{
			points = points - GameObject.Find("LifeText").GetComponent<Lives>().cost;
			numLives ++;
		}
	}

	public void allen()
	{
		enAmount ++;
	}

	public void LazerUpgrade()
	{
		float lu = GameObject.Find("LazerText").GetComponent<lazerbutton>().cost;
		if (points>= lu)
		{
			lazerlevel = lazerlevel + 1;
			points -= lu;
			print (lazerlevel);
			if (lazerlevel <= GameObject.Find("LazerText").GetComponent<lazerbutton>().lazerlevel)
			{

				print(GameObject.Find("LazerText").GetComponent<lazerbutton>().cost);
				player.SendMessage("lazerup");
				print("message sent");
			}
		}
	}

	public void invul()
	{
		if (invulablity == false&&points>=GameObject.Find("InvulText").GetComponent<InvulButton>().cost)
		{
			points = points - GameObject.Find("InvulText").GetComponent<InvulButton>().cost;
			player.SendMessage("binvul");
		}
	}

	public void infalse()
	{
		invulablity = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (player == null)
		{ 
			player = GameObject.FindGameObjectWithTag("Player");
		}
		txt.text="Points: "+ points.ToString("f0");

		if (win == true)
		{ 
			got.SetActive(true);
		}

	}
}
