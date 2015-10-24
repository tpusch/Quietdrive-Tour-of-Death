using UnityEngine;
using System.Collections;

public class MovingAttack : AttackObject {

    [SerializeField]
    float movementSpeed;

    Rigidbody2D physics;
    void Awake()
    {
        physics = GetComponent<Rigidbody2D>();

    }


	// Use this for initialization
	protected override void Start () 
    {
        base.Start();
        physics.AddForce(transform.right * movementSpeed, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	protected override void Update () 
    {
        base.Update();
    }

    void Move()
    {
        Vector3 newPosition = transform.position;
        newPosition += transform.right * movementSpeed * Time.deltaTime;
        transform.position = newPosition;   
    }
}
