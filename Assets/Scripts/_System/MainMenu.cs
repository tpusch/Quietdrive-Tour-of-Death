using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
    
	// Use this for initialization
	void Start () 
    {
        PlayerPrefs.SetInt("NumPlayers", 1);
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    public void PlayerCountChanged(int numPlayers)
    {
        PlayerPrefs.SetInt("NumPlayers", numPlayers + 1);
    }

    public void StartGame( int numPlayers)
    {
        PlayerPrefs.SetInt("NumPlayers", numPlayers);

        Application.LoadLevel("Game 1");
        Time.timeScale = 1.0f;
    }
}
