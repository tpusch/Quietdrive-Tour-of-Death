using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    [SerializeField]
    GameObject enemy;


    void OnTriggerEnter2D(Collider2D other)    
    {
        if (other.tag == "Player")
        {
            GameObject.Instantiate(enemy, transform.position, transform.rotation);
            GameObject.Destroy(gameObject);
        }
    }
}
