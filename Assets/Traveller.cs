using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveller : MonoBehaviour
{
	public int turtles;
	// Use this for initialization
	void Awake()
	{
		
		//DontDestroyOnLoad(gameObject.GetComponent<Traveller>());

		// turtles = 50;

	}
	
	public int HowMany(){

		return turtles=50;

	}
}
