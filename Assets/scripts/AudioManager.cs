using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {


    
    public Sound[] sounds;
    public static AudioManager instance;
    private Sound currentlyPlaying;


    [HideInInspector]
    public static bool IsPlaying = false;
    [HideInInspector]
    public static bool SongStopped = false;
    private LyricsManager lyricsManager;
  


    void Awake () {
        if (instance == null)
        {
            instance = this
;        }
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(gameObject);
        lyricsManager = GetComponent<LyricsManager>();
        

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = s.loop;

        }
        }
   

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound does not exist");
        }
        else
        {
           
            IsPlaying = true;
            
            currentlyPlaying = s;
            s.source.PlayDelayed(0.5f);
            StartCoroutine(lyricsManager.StartText(s));
            
        }
    }


    public void StopSound()
    {
        if (currentlyPlaying == null)
        {
            Debug.Log("No sound is playing");
        }
        else
        {
            IsPlaying = false;
            SongStopped = true;
                        
            currentlyPlaying.source.Stop();
        
        }

    }
    public void Mute()
    {
       if (currentlyPlaying.source.volume != 0)
            currentlyPlaying.source.volume = 0;
        else currentlyPlaying.source.volume = currentlyPlaying.volume;
    }


}
