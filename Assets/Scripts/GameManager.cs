using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    [SerializeField]
    float groundLength;

    [SerializeField]
    GameObject groundPrefab;

	// Use this for initialization
	void Start () 
    {
        BuildGround();
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
}
