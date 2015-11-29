using UnityEngine;
using System.Collections;

public class PlatformBounce : MonoBehaviour {

    [SerializeField]
    public float jumpPower;


    void Awake()
    {
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D player)
    {
        
        if (player.gameObject.tag == "Player")
        {
            player.attachedRigidbody.velocity = Vector2.zero;
            player.attachedRigidbody.AddForce(jumpPower*player.transform.up, ForceMode2D.Impulse);
            
            
        }
    }

}
