using UnityEngine;
using System.Collections;

public class SFXManager: MonoBehaviour {

	static SFXManager instance;

	[SerializeField]
	AudioSource source;

	public static SFXManager Instance{
		get{ return instance; }
		private set{ instance = value; }
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake() {
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy(this.gameObject);
		}
	}

	public void playSound(AudioClip clip){
		source.PlayOneShot (clip);
	}
}
