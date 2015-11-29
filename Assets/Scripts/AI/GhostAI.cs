using UnityEngine;
using System.Collections;

public class GhostAI : BasicAI {

    [SerializeField]
    float moveSpeed = 10.0f;

    protected override void Awake()
    {
        base.Awake();

    }

	
	// Update is called once per frame
	protected override void Update () 
    {
        base.Update();
        MoveTowardPlayer();
	}

    void MoveTowardPlayer()
    {
        int moveLeft = -1;
        if (facingRight)
        {
            moveLeft = 1;
        }

        transform.position += Vector3.right * moveLeft * moveSpeed * Time.deltaTime;
    }
}
