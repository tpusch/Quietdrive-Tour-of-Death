using UnityEngine;
using System.Collections;

public class BaseCollider : MonoBehaviour {

	
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.EndGame(true);
        }
    }

}
