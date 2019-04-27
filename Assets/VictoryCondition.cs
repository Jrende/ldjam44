﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
	public int requiredForVictory;
	private int currentCash = 0;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "$")
		{
			currentCash++;
		}
		if (currentCash >= requiredForVictory) {
			Debug.Log("You are winner!");
		}
		Debug.Log("Enter");
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "$")
		{
			currentCash--;
		}
		Debug.Log("exit");
	}
}
