using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Destroyable : MonoBehaviour {

    [SerializeField]
    AudioClip deathClip;

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
        if (hit.gameObject.tag == "Player")
        {
            UnityStandardAssets._2D.PlatformerCharacter2D player = hit.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
            if (player.Attacking)
            {
                Damage(player.AttackDamage);
            }
        }
        
        AttackObject hitter = hit.gameObject.GetComponent<AttackObject>();
        
        if (hitter)
        {
            Damage(hitter.Damage);            
        }



    }

    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            SFXManager.Instance.playSound(deathClip);
            GameManager.Destroy(gameObject);
        }
    }

}
