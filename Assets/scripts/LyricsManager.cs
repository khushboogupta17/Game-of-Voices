using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class LyricsManager : MonoBehaviour {
    public Text lyrics;
    string[] lyricsPieces;
    string[] timePieces;



    public IEnumerator StartText(Sound s)
    {
        //Debug.Log("lyrics manager called");
        lyricsPieces = null;
        timePieces = null;
        lyricsPieces = s.lyrics.Split('/');
        timePieces = s.timing.Split('/');

        while (AudioManager.IsPlaying)
        {
           
            int i = 0;
               
            foreach (string piece in lyricsPieces)
            {
                //if (AudioManager.IsPlaying ==false|| Input.GetKey(KeyCode.P))
                //{
                //    Debug.Log("audio is off");
                                   
                   
                    
                //    break;
                //}
                    

                lyrics.text = piece;
                yield return new WaitForSecondsRealtime(float.Parse(timePieces[i]));
                if (AudioManager.IsPlaying == false || Input.GetKey(KeyCode.P) || AudioManager.SongStopped==true)
                {
                    Debug.Log("audio is off");
                    AudioManager.SongStopped = false;
                    break;
                }

                i++;



            }
        }

        
        lyrics.text = "YOU CLEARED THIS LEVEL,CONGO!!";
         
    }
    








}
