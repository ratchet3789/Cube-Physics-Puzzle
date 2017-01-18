using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OverlapWinner : MonoBehaviour {

    public Text WinMessage;

    void OnTriggerEnter(Collider other) //When any object overlaps with the 
    {
        if (other.tag == "Player") //If the object has the Tag "Player"
        {
            Debug.Log("YOU WON!"); //Log message "YOU WON!"
            WinMessage.text = "YOU WON"; //Set text on screen to "YOU WON"
        }
    }
}