using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour {

    GameObject[] players;
    float distToPlayer;
	int count = 0;
    
    protected bool facingRight = true;
    protected GameObject closestPlayer;

	protected virtual void Awake () 
    {
	}

	protected virtual void Start(){
		
		players = GameObject.FindGameObjectsWithTag("Player");
	}
	// Update is called once per frame
	protected virtual void Update () 
    {
        FindClosestPlayer();
        LookAtPlayer();
	}


    void FindClosestPlayer()
    {
        distToPlayer = float.MaxValue;
        for (int i = 0; i < players.Length; i++)
        {            
            float newDist = Vector3.Distance(transform.position, players[i].transform.position);
            if (newDist < distToPlayer)
            {
                distToPlayer = newDist;
                closestPlayer = players[i];
            }
        }
    }

    void LookAtPlayer()
    {
        Vector3 toPlayer = closestPlayer.transform.position - transform.position;
        if (toPlayer.x <= 0 && facingRight && count == 0) {
			Flip ();
			count++;
		} else if (toPlayer.x > 0 && !facingRight && count == 0) {
			Flip ();
			count++;
		} else if (count >= 60) {
			count = 0;
		} else {
			count ++;
		}
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        facingRight = !facingRight;
    }
}
