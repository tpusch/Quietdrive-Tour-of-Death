using UnityEngine;
using System.Collections;

public class SFXManager: MonoBehaviour {

	static SFXManager instance;

	[SerializeField]
	AudioSource source;

    [SerializeField]
    AudioClip BGmusic;

    [SerializeField]
    [Range(0, 100)]
    float musicVolume;



	public static SFXManager Instance{
		get{ return instance; }
		private set{ instance = value; }
	}

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        PlayMusic();    
	}

    void PlayMusic()
    {
        if (!source.isPlaying)
        {
			source.pitch = 0.5f;
            source.clip = BGmusic;
            source.volume = musicVolume / 100;
            source.Play();
        }

    }

	public void playSound(AudioClip clip, float volume = 100){
        
		source.PlayOneShot (clip, volume/100);
        
	}
}
