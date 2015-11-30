using UnityEngine;
using System.Collections;

public class grab_coin : MonoBehaviour {


    float lifeTimer;

    [SerializeField]
    AudioClip coinSound;

	[SerializeField]
	float volume = 100;

	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        lifeTimer = 0;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        
        /*if (coll.gameObject.tag == "Player")
            Destroy(coll.gameObject);*/

        if (coll.gameObject.tag == "Player" && lifeTimer > 1)
        {
            SFXManager.Instance.playSound(coinSound, volume);
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update () {
        lifeTimer += Time.deltaTime;
	}
}
