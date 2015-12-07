using UnityEngine;
using System.Collections;

public class Explosion : AttackObject {

    [SerializeField]
    float LifeTime;

    [SerializeField]
    float explodeRate;

    void Awake()
    {        
        GameObject.Destroy(gameObject, LifeTime);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.localScale += transform.localScale * explodeRate * Time.deltaTime;
	}

    protected override void OnCollisionEnter2D(Collision2D hit)
    {
    }
}
