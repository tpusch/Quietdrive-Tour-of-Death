using UnityEngine;
using System.Collections;

public class InputComponent : MonoBehaviour {

    public Character character;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        GetInput();
	}

    protected virtual void GetInput()
    {
        
    }

    void Move()
    {
        character.Move();
    }

}
