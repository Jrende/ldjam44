using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AngryCommentGenerator : MonoBehaviour {

    public int currentLevelIdx = 0;

    private string[][] commentLists = new string[3][]{
        new string[]{
            "Can you hurry up?", "What's taking so long?", "Hey man, I'm in a rush here.", "Dude, like, seriously?",
            "Is this gonna take all day?", "Buddy, there's a lotta folks queueing.", "Hot damn, this is like the DMV all over!",
            "Are you buying up the whole store or what?", "Are you paying or are you not?",
            "Are you waiting for the federal bank to pay for you or what?",
            "Dude, pay or that can will get neatly packaged up yours!",
            "Dude, pay or I’m calling the police, they’re gonna make you pay in lead, bro…"

        }, new string[]{
            "Comrade, hurry it up.", "I feel like been queueing since Perestroika!", "Blyad, can you be any slower?",
            "This is like queueing for buying Lada.", "Are you trying to bring down system by being slow, comrade?",
            "Comrade, are you waiting for inflation to make your Vodka cheaper??",
            "Drog, the vodka will evaporate, pay up and drink it fast, for the motherland!",
            "Are we waiting for the next meltdown? Pay up already comrade!",
            "I’m turning into Babuchka, pay, pay, plati!!!!"
        }, new string[]{
            "Dost thou have naught but idle time?", "Make haste, knave!", "Hath thou not a care in the world!?",
            "Must the sun set beneath before thine affairs are in order?", "The course of affairs is not running smooth this day...",
            "A cashier! A cashier! My kingdom for a cashier!", "It doth feel like I've waited a forthnight",
            "Dost thou wish to pay with thine blood, peon!?"
        }
    };
    private TextMeshProUGUI[] uiTexts;

    void Start() {
        uiTexts = this.gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        StartCoroutine("CommenterFunction");
    }

    void Update() {
        
    }

    IEnumerator CommenterFunction() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));
            foreach (var uiText in uiTexts) {
                uiText.text = "";
            }
            uiTexts[Random.Range(0, uiTexts.Length-1)].text = commentLists[currentLevelIdx][Random.Range(0, commentLists[currentLevelIdx].Length-1)];
        }
    }
}
