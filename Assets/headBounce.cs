using UnityEngine;
using System.Collections;

public class headBounce : MonoBehaviour {

    [SerializeField]
    public float jumpPower;

    [SerializeField]
    public GameObject itemToSpawn;

    [SerializeField]
    public float numToSpawn;

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
            player.attachedRigidbody.AddForce(jumpPower*player.transform.up, ForceMode2D.Impulse);

            if (itemToSpawn)
            {
                Destroy(gameObject);
                for (int i = 0; i < numToSpawn; i++)
                {
                    GameObject obj;
                    obj = GameObject.Instantiate(itemToSpawn, transform.position, Quaternion.identity) as GameObject;

                    //obj.GetComponent<Rigidbody2D>().AddForce(Random)
                }
            }
            
            
        }
    }

}
