using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour {

    [SerializeField]
    AttackObject attackObject;

    [SerializeField]
    Transform attackOrigin;

    bool canAttack;
	// Use this for initialization
	void Start () {
        canAttack = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Attack(float facing)
    {
        if (canAttack)
        {
            AttackObject attack = GameObject.Instantiate(attackObject, attackOrigin.position, transform.rotation) as AttackObject;
            if (facing < 0)
            {
                // Multiply the player's x local scale by -1.
                Vector3 rotation = attack.transform.rotation.eulerAngles;
                rotation.y = 180.0f;
                attack.transform.rotation = Quaternion.Euler(rotation);
            }
        }
    }
}
