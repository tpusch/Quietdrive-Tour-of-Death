﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    [SerializeField]
    int defaultPlayers = 2;

    [SerializeField]
    float groundLength;

    [SerializeField]
    GameObject groundPrefab;

    [SerializeField]
    UnityStandardAssets._2D.PlatformerCharacter2D player1;
    [SerializeField]
    UnityStandardAssets._2D.PlatformerCharacter2D player2;

    [SerializeField]
    GameObject winPanel;

    int numPlayers;
       
    public static GameManager Instance{ get; private set;}

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () 
    {
        BuildGround();
        numPlayers = PlayerPrefs.GetInt("NumPlayers", defaultPlayers);
        if (numPlayers == 1)
        {
            player2.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void BuildGround()
    {
        GameObject groundPieces = new GameObject("GroundPieces");
        for (int i = -10; i < groundLength; i++)
        {
            GameObject piece = GameObject.Instantiate(groundPrefab, new Vector3(i*5.0f, -7.5f, 0.0f), Quaternion.identity) as GameObject;
            piece.transform.SetParent(groundPieces.transform);
        }
    }

    public void EndGame(bool win)
    {
        if (win)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {

        }
    }

    public void Menu()
    {
        Application.LoadLevel("Menu");
    }

}
