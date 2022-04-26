using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float GameTimeInSeconds;
    private float timeRemaining;
    public Text textLabel;
    private bool gameWon = false;
    private bool sceneLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = GameTimeInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0 && SceneManager.GetActiveScene().name.Equals("Final Level"))
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime();
        }
        else if (!sceneLoaded)
        {
            LoadGameOverScene(true);
        }
    }

    private void DisplayTime()
    {
        int minutes = Mathf.Max(Mathf.FloorToInt((timeRemaining + 1f) / 60f), 0);
        int seconds = Mathf.FloorToInt((timeRemaining + 1f) % 60f);
        textLabel.text = string.Format("Time remaining: " + minutes + ":{0:00}", seconds);
    }

    public void LoadGameOverScene(bool _gameWon)
    {
        gameWon = _gameWon;
        sceneLoaded = true;
        gameObject.GetComponent<SpawnEntities>().enabled = false;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("GameOverScene");
    }

    public bool GameWon
    {
        get
        {
            return gameWon;
        }
    }

    public float TimeRemaining
    {
        get
        {
            return timeRemaining;
        }
    }
}
