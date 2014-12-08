using UnityEngine;
using System.Collections;

public class Player_Spawner : MonoBehaviour 
{
	public GameObject player;
	GameObject playerExist;

	public AudioClip loser;

	public GameObject db;
	public GameObject spawn;

	public GameObject got2;

	public int numLives = 4;
	
	public float respawn = 3.5f;
	
	// Use this for initialization
	void Start () 
	{
		respawn = 1.5f;
		db = GameObject.Find ("_Scripts&GUI");
		spawn = GameObject.Find ("LifeText");
		got2 = GameObject.Find("Overgame");
		got2.SetActive(false);
	}

	public void begingame()
	{
		numLives = 4;
	}

	public void lifeadd ()
	{
		numLives ++;
	}

	void SpawnPlayer() 
	{
		numLives = numLives - 1;
		respawn = 2.5f;
		spawn.GetComponent<Lives>().SendMessage("lifeset");
		playerExist = (GameObject)Instantiate(player, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(playerExist == null && numLives > 0) 
		{
			respawn = respawn - Time.deltaTime;
			if(respawn < 0)
			{
				SpawnPlayer();
			}
		}
		else
		{
			if (numLives > 0)
			{
				got2.SetActive(false);
			}
			if(numLives <= 0)// && playerExist == null) 
			{
				got2.SetActive(true);
				AudioSource.PlayClipAtPoint(loser, transform.position);
				Time.timeScale = 0;
			}
		}
	}
}
