using UnityEngine;
using System.Collections;

public class BottleThrower : MonoBehaviour {

    [SerializeField]
    AttackObject Bottle;

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

    public void Attack(float facing)
    {
        if (canAttack)
        {
            AttackObject attack = CreateAttack(facing);
            ThrowAttack(attack);
        }
    }

    public void Attack(Vector3 forward, Vector3 targetPosition)
    {
        if (canAttack)
        {
            AttackObject attack = CreateAttack(forward.x);
            CalculatePower(targetPosition);
            ThrowAttack(attack);
        }
    }

    AttackObject CreateAttack(float facing)
    {
        AttackObject attack = GameObject.Instantiate(Bottle, attackOrigin.position, transform.rotation) as AttackObject;
        if (facing < 0)
        {
            // Multiply the player's x local scale by -1.
            Vector3 rotation = attack.transform.rotation.eulerAngles;
            rotation.y = 180.0f;
            attack.transform.rotation = Quaternion.Euler(rotation);
        }
        canAttack = false;
        timeElapsed = 0;
        return attack;
    }

    void ThrowAttack(AttackObject bottle)
    {
        Rigidbody2D phys = bottle.GetComponent<Rigidbody2D>();
        phys.AddForce(transform.right * horizontalPower, ForceMode2D.Impulse);
        phys.AddForce(transform.up * verticalPower, ForceMode2D.Impulse);
        phys.AddTorque(-bottle.transform.right.x * rotationPower, ForceMode2D.Impulse);
    }

    void CalculatePower(Vector3 targetPos)
    {

    }
}
