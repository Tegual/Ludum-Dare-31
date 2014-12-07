using UnityEngine;
using System.Collections;

public class selfdestruct : MonoBehaviour 
{
	float timer = 1.5f;
	
	// Update is called once per frame
	void Update () 
	{
		timer = timer - Time.deltaTime;
		if (timer <= 0)
		{
			Destroy(gameObject);
		}
	}
}
