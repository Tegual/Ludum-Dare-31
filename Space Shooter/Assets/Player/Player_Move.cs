using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour 
{

	public float playerSpeed = 5f;
	public float rotationSpeed = 180f;
	
	public float playerBoundary = 0.5f;

	void Start () 
	{
		gameObject.layer = 8;
	}
	
	void Update () 
	{
		//Ship Rotation
		Quaternion playerrotation = transform.rotation;
		float zangle = playerrotation.eulerAngles.z;
		zangle -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
		playerrotation = Quaternion.Euler( 0, 0, zangle );
		transform.rotation = playerrotation;
		
		//Moving
		Vector3 playerposition = transform.position;
		Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime, 0);
		if (Input.GetAxis("Vertical") >= 0)
		{
			playerposition += playerrotation * velocity;
		}
		else
		{
			playerposition += playerrotation * (velocity * .5f);
		}

		
		//Restrict plsyer movement
		if(playerposition.y + playerBoundary > Camera.main.orthographicSize) 
		{
			playerposition.y = Camera.main.orthographicSize - playerBoundary;
		}
		if(playerposition.y - playerBoundary < -Camera.main.orthographicSize)
		{
			playerposition.y = -Camera.main.orthographicSize + playerBoundary;
		}

		float screenW = Screen.width;
		float screenH = Screen.height;
		float screenRatio = screenW / screenH;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;
		if(playerposition.x + playerBoundary > widthOrtho) 
		{
			playerposition.x = widthOrtho - playerBoundary;
		}
		if(playerposition.x - playerBoundary < -widthOrtho) 
		{
			playerposition.x = -widthOrtho + playerBoundary;
		}
		
		transform.position = playerposition;
		
		
	}
}