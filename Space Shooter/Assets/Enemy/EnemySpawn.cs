using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour 
{

	public GameObject[] enemy;
	
	float spawnDistance = 18f;
	
	float enemyRate = 9;
	float nextEnemy = 1;
	
	void Start()
	{

	}

	// Update is called once per frame
	void Update () 
	{
		nextEnemy -= Time.deltaTime;
		
		if(nextEnemy <= 0)
		{
			nextEnemy = enemyRate;
			enemyRate *= 0.95f;
			if(enemyRate < 3.5f)
			{
				enemyRate = 3.5f;
			}
			
			Vector3 offset = Random.onUnitSphere;
			
			offset.z = 0;
			
			offset = offset.normalized * spawnDistance;
			foreach (GameObject enm in enemy)
			{
				Instantiate(enm, transform.position + offset, Quaternion.identity);
		
			}
		}
	}
}
