using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VictoryCondition : MonoBehaviour
{
	public int requiredForVictory;
    public GameObject victoryScreen;
	public GameObject defeatScreen;
    public bool hasWon = false;
    public UnityEvent m_VictoryEvent;
    public static int globalCashCaught = 0;

    void Start()
	{

	}

	void Update()
	{
        int currentCash = 0;
        GameObject[] coins = GameObject.FindGameObjectsWithTag("$");
        foreach(GameObject coin in coins)
        {
            if(coin.GetComponent<BoidMovement>().GetCurrentState() == BoidMovement.State.Caught)
            {
                currentCash++;
            }
        }
        globalCashCaught = currentCash;
        if (currentCash >= requiredForVictory)
        {
            hasWon = true;
            m_VictoryEvent.Invoke();
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "$")
		{
			BoidMovement bm = other.gameObject.GetComponent(typeof(BoidMovement)) as BoidMovement;
			bm.catchBoid();
		}
		
	}

	public void loseByTimeUp() {
        if (hasWon != true)
        {
            defeatScreen.SetActive(true);
        }
	}
}
