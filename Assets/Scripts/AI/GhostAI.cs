using UnityEngine;
using System.Collections;

public class GhostAI : BasicAI {

    [SerializeField]
    float moveSpeed = 10.0f;

    [SerializeField]
    GameObject explosion;

    protected override void Awake()
    {
        base.Awake();

    }

	protected override void Start(){
		base.Start ();
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!other.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().Attacking)
            {
                if (explosion)
                {
                    GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
                }
                GameObject.Destroy(gameObject);
            }
        }
    }
}
