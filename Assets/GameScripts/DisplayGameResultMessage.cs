using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayGameResultMessage : MonoBehaviour
{
    public Text resultText;
    private Timer gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Timer>();
        DisplayResult();
    }

    public void DisplayResult()
    {
        resultText.text = gameManager.GameWon ?
            "Well done! You survived to the end" :
            "You died! You lasted " + Mathf.FloorToInt(gameManager.GameTimeInSeconds - gameManager.TimeRemaining) + " seconds";
    }
}
