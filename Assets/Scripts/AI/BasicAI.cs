using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour {

    BottleThrower combat;
    	
	void Awake () 
    {
        combat = GetComponent<BottleThrower>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        combat.Attack(transform.forward.x);
	}


    void FindPlayer()
    {

    }

}
