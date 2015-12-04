using UnityEngine;
using System.Collections;

public class headBounce : MonoBehaviour {

    [SerializeField]
    public float jumpPower;

    [SerializeField]
    public GameObject itemToSpawn;

    [SerializeField]
    public float numToSpawn;

    Destroyable destroyable;

    void Awake()
    {
        destroyable = GetComponent<Destroyable>();
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
            UnityStandardAssets._2D.PlatformerCharacter2D other = player.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
            //if (!other.Grounded)
			if(player.attachedRigidbody.velocity[1] < 0)
            {
                player.attachedRigidbody.velocity = Vector2.zero;
                player.attachedRigidbody.AddForce(jumpPower * player.transform.up, ForceMode2D.Impulse);
                destroyable.Damage(float.MaxValue);
                if (itemToSpawn)
                {
                    for (int i = 0; i < numToSpawn; i++)
                    {
                        GameObject obj;
                        obj = GameObject.Instantiate(itemToSpawn, transform.position, Quaternion.identity) as GameObject;
                    }
                }
            }
            
            
        }
    }

}
