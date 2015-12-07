using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Destroyable : MonoBehaviour {

    [SerializeField]
    AudioClip deathClip;

    [SerializeField]
    float health;
    float maxHealth;

    void Awake()
    {
        maxHealth = health;       
    }

	// Use this for initialization
	void Start () {
        if (gameObject.tag == "Player" && gameObject.activeInHierarchy)
        {
            SetUIHealth();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
			if(gameObject.tag == "Player") return;
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
            if (gameObject.tag == "Player")
            {
                gameObject.SetActive(false);
            }
            else
            {
                GameManager.Destroy(gameObject);
            }
        }

        if (gameObject.tag == "Player")
        {
            SetUIHealth();   
        }
    }

    void SetUIHealth()
    {
        UnityStandardAssets._2D.PlatformerCharacter2D player = gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
        UIManager.Instance.SetHealth(player.PlayerNum, Mathf.RoundToInt(health / maxHealth * 100 / 40));
    }

    public void Heal()
    {
        health = maxHealth;
        SetUIHealth();
    }

}
