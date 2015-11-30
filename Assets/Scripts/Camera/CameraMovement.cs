using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public UnityStandardAssets._2D.PlatformerCharacter2D[] players;    

    Camera cam;


	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        //TODO: Dynamically place border colliders        
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        MovePosition();
	}

    /// <summary>
    /// Pans the camera based on the average position of the 2 players
    /// </summary>
    //TODO: code accepts 1 or 2 players, not so well at 4
    void MovePosition()
    {
        Vector3 newPos = transform.position;

        float newX = 0.0f;
        int numPlayers = 0;
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].isActiveAndEnabled)
            {
                newX += players[i].transform.position.x;
                numPlayers++;
            }
        }

        if (numPlayers == 0)
        {
            GameManager.Instance.EndGame(false);
            return;
        }

        newPos.x = newX / numPlayers;

        if (newPos.x != transform.position.x)
        {
            transform.position = newPos;
        }
    }

}
