using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUnitySingleton : MonoBehaviour {

    public AudioClip[] songs;
    AudioClip currentSong;
    AudioClip previousSong;
    AudioSource source;

    private static MyUnitySingleton instance = null;
    public static MyUnitySingleton Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            if(currentSong != null)
            {
                previousSong = currentSong;
            }
            bool isSameSong = true;
            while (isSameSong)
            {
                currentSong = songs[Random.Range(0, songs.Length)];
                if(currentSong != previousSong)
                {
                    isSameSong = false;
                }
            }
            source.PlayOneShot(currentSong);
        }
    }

}
