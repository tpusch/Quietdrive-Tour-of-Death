using UnityEngine;
using System.Collections;

public class AttackObject : MonoBehaviour {

    [SerializeField]
    float damage;
    public float Damage { get { return damage; } }

	// Use this for initialization
	protected virtual void Start () 
    {
	}

    protected virtual void OnCollisionEnter2D(Collision2D hit)
    {
        GameObject.Destroy(gameObject);
    }

    protected virtual void Update()
    {

    }

}
