using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

    [SerializeField]
    GameObject heart;

    [SerializeField]
    GameObject[] PlayerPanels;

    private static UIManager mInstance;
    public static UIManager Instance
    {
        get
        {
            return mInstance;
        }
    }

    void Awake()
    {
        if (!mInstance)
        {
            mInstance = this;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetHealth(int player, int health)
    {
        print("setting health");


        Transform group = PlayerPanels[player].GetComponentInChildren<HorizontalLayoutGroup>().transform;

        LinkedList<Transform> hearts = new LinkedList<Transform>();
        foreach (Transform child in group)
        {
            hearts.AddFirst(child);
        }

        print(hearts.Count);
        foreach (Transform t in hearts)
        {
            print(t);
        }

        print(player);
        print(health);

        if (hearts.Count == 0)
        {
            for (int i = 0; i < health; i++)
            {
                GameObject g = GameObject.Instantiate(heart);
                g.transform.parent = group;
            }
        }
        else if (hearts.Count > health)
        {
            for (int i = 0; i < hearts.Count - health; i++)
            {
                GameObject.Destroy(hearts.First.Value.gameObject);
                hearts.RemoveFirst();
            }
        }
        else if (health > hearts.Count)
        {
            for (int i = 0; i < health - hearts.Count; i++)
            {
                GameObject g = GameObject.Instantiate(heart);
                g.transform.parent = group;
            }
        }
    }


}
