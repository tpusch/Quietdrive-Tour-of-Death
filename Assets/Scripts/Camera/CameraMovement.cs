using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public UnityStandardAssets._2D.PlatformerCharacter2D player1;
    public UnityStandardAssets._2D.PlatformerCharacter2D player2;

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
    //TODO: alter code to accept 1 - 4 players
    void MovePosition()
    {
        Vector3 newPos = transform.position; 
        newPos.x = (player1.transform.position.x + player2.transform.position.x)/2;
        Debug.DrawLine(player1.transform.position, newPos);
        Debug.Log(newPos.x);
        if (newPos.x > transform.position.x)
        {
            transform.position = newPos;
        }
    }

}
