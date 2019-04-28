using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AngryCommentGenerator : MonoBehaviour
{

    private int currentLevelIdx = 0;
    private string[][] commentLists = new string[4][]{
        new string[]{
            "Can you hurry up?", "What's taking so long?", "Hey man, I'm in a rush here.", "Dude, like, seriously?",
            "Is this gonna take all day?", "Buddy, there's a lotta folks queueing.", "Hot damn, this is like the DMV all over!",
            "Are you buying up the whole store or what?", "Are you paying or are you not?",
            "Are you waiting for the federal bank to pay for you or what?",
            "Dude, pay or that can will get neatly packaged up yours!",
            "Dude, pay or I’m calling the police, they’re gonna make you pay in lead, bro…"
        }, new string[]{
            "Lägg upp stålarna på brickan, tack…",
            "Kan du lägga pengarna på brickan?", 
            "Du, du kan inte försöka vara liiite långsammare?",
            "Hörru, det är folk som står i kö här.",
            "Asså, tänker du betala idag eller?",
            "Vi har väntat ganska länge här bak..."
        }, new string[]{
            "Comrade, hurry it up.", "I feel like been queueing since Perestroika!", "Blyad, can you be any slower?",
            "This is like queueing for buying Lada.", "Are you trying to bring down system by being slow, comrade?",
            "Comrade, are you waiting for inflation to make Vodka cheaper??",
            "Drog, vodka will evaporate, pay up and drink fast, for motherland!",
            "Are we waiting for next meltdown? Pay up already comrade!",
            "I’m turning into Babuchka, pay, pay, plati!!!!"
        }, new string[]{
            "Dost thou have naught but idle time?", "Make haste, knave!", "Hath thou not a care in the world!?",
            "Must the sun set beneath before thine affairs are in order?", "The course of affairs is not running smooth this day...",
            "A cashier! A cashier! My kingdom for a cashier!", "It doth feel like I've waited a forthnight",
            "Dost thou wish to pay with thine blood, peon!?"
        }
    };
    private TextMeshProUGUI[] uiTexts;

    void Start()
    {
        uiTexts = this.gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        currentLevelIdx = getIndexFromSceneName(SceneManager.GetActiveScene().name);
        StartCoroutine("CommenterFunction");
    }

    void Update()
    {

    }

    private int getIndexFromSceneName(string sceneName)
    {
        Dictionary<string, int> sceneIndexes = new Dictionary<string, int>{
            { "Level 1", 0 },
            { "Level 2", 1 },
            { "Level 3", 2 },
            { "Level 4", 3 }
        };
        int defaultValue = 0;
        sceneIndexes.TryGetValue(sceneName, out defaultValue);
        return defaultValue;
    }

    IEnumerator CommenterFunction()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));
            foreach (var uiText in uiTexts)
            {
                uiText.text = "";
            }
            uiTexts[Random.Range(0, uiTexts.Length - 1)].text = commentLists[currentLevelIdx][Random.Range(0, commentLists[currentLevelIdx].Length - 1)];
        }
    }
}
