using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Destroyable : MonoBehaviour {

    [SerializeField]
    float health;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D hit)
    {
        AttackObject hitter = hit.gameObject.GetComponent<AttackObject>();
        if (hitter)
        {
            health -= hitter.Damage;
        }

        if (health <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

}
