using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
	public int requiredForVictory;
	private int currentCash = 0;
    public GameObject victoryScreen;
	public GameObject defeatScreen;

	void Start()
	{

	}

	void Update()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "$")
		{
			currentCash++;
			BoidMovement bm = other.gameObject.GetComponent(typeof(BoidMovement)) as BoidMovement;
			bm.catchBoid();
		}
		if (currentCash >= requiredForVictory) {
            victoryScreen.SetActive(true);
			//Debug.Log("You are winner!");
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "$")
		{
			currentCash--;
		}
	}

	public void loseByTimeUp() {
		defeatScreen.SetActive(true);
	}
}
