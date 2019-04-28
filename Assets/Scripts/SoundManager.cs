using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SoundManager : MonoBehaviour
{
    public AudioSource ratSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var states = getStates();
        int totalCoins = states.Count;
        int numberOfPanicked = states.Where(state => state == BoidMovement.State.Panic).Count();
        float volume = ((float) numberOfPanicked / (float) totalCoins);
        Debug.Log("volume: " + volume);
        ratSound.volume = volume;
    }

    List<BoidMovement.State> getStates()
    {
        List<GameObject> coinList = GameObject.FindGameObjectsWithTag("$").ToList();
        return coinList.Select(coin => coin.GetComponent<BoidMovement>().GetCurrentState()).ToList();
    }

}
