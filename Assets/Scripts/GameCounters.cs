using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class GameCounters : MonoBehaviour {
    private TextMeshProUGUI moneyCaughtLabel;
    private TextMeshProUGUI peopleInQueueLabel;

    private int peopleInQueue = 0;

    void Start() {
        List<TextMeshProUGUI> counterTextLabels = new List<TextMeshProUGUI>(this.gameObject.GetComponentsInChildren<TextMeshProUGUI>());
        moneyCaughtLabel = counterTextLabels.Where(e => e.name == "CounterText1").First();
        peopleInQueueLabel = counterTextLabels.Where(e => e.name == "CounterText2").First();
        StartCoroutine("PeopleInQueueIncrementer");
    }

    void Update() {
        moneyCaughtLabel.text = "Money caught: " + VictoryCondition.globalCashCaught;
        peopleInQueueLabel.text = "People in queue: " + peopleInQueue;
    }

    IEnumerator PeopleInQueueIncrementer() {
        while (true) {
            yield return new WaitForSeconds(3.0f);
            peopleInQueue += (int) Random.Range(1f, 3f);
        }
    }
}
