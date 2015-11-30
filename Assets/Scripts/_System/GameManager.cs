using UnityEngine;
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
    GameObject backgroundImage;

    [SerializeField]
    UnityStandardAssets._2D.PlatformerCharacter2D player1;
    [SerializeField]
    UnityStandardAssets._2D.PlatformerCharacter2D player2;

    [SerializeField]
    GameObject winPanel;

    [SerializeField]
    GameObject losePanel;

    int numPlayers;
       
    public static GameManager Instance{ get; private set;}

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () 
    {
        BuildLevel();
        numPlayers = PlayerPrefs.GetInt("NumPlayers", defaultPlayers);
        if (numPlayers == 1)
        {
            player2.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void BuildLevel()
    {
        //ground
        GameObject groundPieces = new GameObject("GroundPieces");
        for (int i = -10; i < groundLength; i++)
        {
            //GameObject piece = GameObject.Instantiate(groundPrefab, new Vector3(i*5.0f, -7.5f, 0.0f), Quaternion.identity) as GameObject;
            //piece.transform.SetParent(groundPieces.transform);
        }
        //background
        GameObject backgrounds = new GameObject("Backgrounds");
        for (int i = -1; i < groundLength / 5; i++)
        {
            GameObject back = GameObject.Instantiate(backgroundImage, new Vector3(i * 50, -2.25f, 1f), Quaternion.identity) as GameObject;
            back.transform.SetParent(backgrounds.transform);
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
            losePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void Menu()
    {
        Application.LoadLevel("Menu");
    }

}
