using UnityEngine;
using System.Collections;

public class SoundWaves : Combat {

    [SerializeField]
    AttackObject Waves;

    [SerializeField]
    Transform attackOrigin;

    [SerializeField]
    float attackDelay = .25f;
    float timeElapsed;



    [SerializeField]
    float horizontalPower;
    [SerializeField]
    float verticalPower;
    [SerializeField]
    float rotationPower;

    bool canAttack;
	// Use this for initialization
	void Start () {
        canAttack = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!canAttack)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= attackDelay)
            {
                canAttack = true;
            }
        }
	}


    public override void Attack(float facing, float delay)
    {
        StartCoroutine(DelayedAttack(facing, delay));
    }

    IEnumerator DelayedAttack(float facing, float delay)
    {
        yield return new WaitForSeconds(delay);
        Attack(facing);
    }

    public override void Attack(float facing)
    {
        if (canAttack)
        {
            AttackObject attack = CreateAttack(facing);
            ThrowAttack(attack, facing);
        }
    }

    

    public void Attack(Vector3 forward, Vector3 targetPosition)
    {
        if (canAttack)
        {
            AttackObject attack = CreateAttack(forward.x);
            CalculatePower(targetPosition);
            ThrowAttack(attack, -1);
        }
    }

    AttackObject CreateAttack(float facing)
    {
        AttackObject attack = GameObject.Instantiate(Waves, attackOrigin.position, transform.rotation) as AttackObject;
        if (facing > 0)
        {
            // Multiply the player's x local scale by -1.
            Vector3 rotation = attack.transform.rotation.eulerAngles;
            rotation.y = 0.0f;
            attack.transform.rotation = Quaternion.Euler(rotation);
        }
        else
        {
            Vector3 rotation = attack.transform.rotation.eulerAngles;
            rotation.y = 180.0f;
            attack.transform.rotation = Quaternion.Euler(rotation);            
        }
        canAttack = false;
        timeElapsed = 0;
        return attack;
    }

    void ThrowAttack(AttackObject bottle, float facing)
    {
        int throwRight;
        if (facing >= 0)
        {
            throwRight = 1;
        }
        else
        {
            throwRight = -1;
        }
        Rigidbody2D phys = bottle.GetComponent<Rigidbody2D>();
        phys.AddForce(transform.right * horizontalPower * throwRight, ForceMode2D.Impulse);
        phys.AddForce(transform.up * verticalPower, ForceMode2D.Impulse);
        phys.AddTorque(-bottle.transform.right.x * rotationPower, ForceMode2D.Impulse);
    }

    void CalculatePower(Vector3 targetPos)
    {

    }
}
