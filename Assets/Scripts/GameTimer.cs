using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float initialGameTime = 60f;
    public GameObject va;
    
    private TextMeshProUGUI textGui;
    private float startTime;

    void Start() {
        textGui = this.gameObject.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        StartCoroutine("GameTimerFunction");
    }

    public void resetTimer() {
        StartCoroutine("GameTimerFunction");
    }

    void Update() {
        float remainingTime = initialGameTime - (Time.fixedTime - startTime);
        if (remainingTime > 0) {
            textGui.text = string.Format("{0,5:N2}", remainingTime);
        } else {
            textGui.text = "0.00";
        }
    }

    IEnumerator GameTimerFunction() {
        startTime = Time.fixedTime;
        yield return new WaitForSeconds(initialGameTime);
        Debug.Log("Time is up");
        VictoryCondition vc = va.gameObject.GetComponentInChildren(typeof(VictoryCondition)) as VictoryCondition;
        vc.loseByTimeUp();
    }
}
