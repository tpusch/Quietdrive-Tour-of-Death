﻿using UnityEngine;
using System.Collections;

public class MovingAttack : AttackObject {

    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float verticalSpeed;
    [SerializeField]
    float rotationSpeed;
	[SerializeField]
	float lifeTime = 0.0f;
	float timeAlive = 0.0f;

    Rigidbody2D physics;
    void Awake()
    {
        physics = GetComponent<Rigidbody2D>();

    }


	// Use this for initialization
	protected override void Start () 
    {
        base.Start();
        //physics.AddForce(transform.right * movementSpeed, ForceMode2D.Impulse);
        //physics.AddForce(transform.up * verticalSpeed, ForceMode2D.Impulse);
        //physics.AddTorque(-transform.right.x * rotationSpeed, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	protected override void Update () 
    {
        base.Update();

		if (lifeTime != 0.0f) {
			if(timeAlive > lifeTime){
				Destroy(gameObject);
			}else{
				timeAlive += Time.deltaTime;
			}
		}
    }

    void Move()
    {
        Vector3 newPosition = transform.position;
        newPosition += transform.right * movementSpeed * Time.deltaTime;
        transform.position = newPosition;   
    }
}
