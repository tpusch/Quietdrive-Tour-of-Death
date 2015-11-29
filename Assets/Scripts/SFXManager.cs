using UnityEngine;
using System.Collections;

public class SFXManager: MonoBehaviour {

	static SFXManager instance;

	[SerializeField]
	AudioSource source;

    [SerializeField]
    AudioClip BGmusic;

	public static SFXManager Instance{
		get{ return instance; }
		private set{ instance = value; }
	}

	// Use this for initialization
	void Start () {
        source.clip = BGmusic;
        source.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (!source.isPlaying)
        {
            source.clip = BGmusic;
            source.Play();
        }
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
