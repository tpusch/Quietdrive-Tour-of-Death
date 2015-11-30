using UnityEngine;
using System.Collections;

public class RobotAI : BasicAI {

    BottleThrower combat;
    float timeSinceAttack;
    [SerializeField]
    float attackDelay = 2.0f;

    protected override void Awake()
    {
        base.Awake();
        combat = GetComponent<BottleThrower>();
        timeSinceAttack = attackDelay;
    }

	protected override void Start ()
	{
		base.Start ();
	}

	// Update is called once per frame
	protected override void Update () 
    {
        base.Update();

        if (combat && timeSinceAttack > attackDelay)
        {
            combat.Attack(transform.localScale.x);
            timeSinceAttack = 0.0f;
        }
        else
        {
            timeSinceAttack += Time.deltaTime;
        }
    
	}
}
