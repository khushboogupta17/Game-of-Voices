using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    
  
    

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
            return;
         }
        DontDestroyOnLoad(gameObject);
        
       
    }
    public void LoadTheScene(string NextsceneName)
    {
        AudioManager.IsPlaying = false;
        AudioManager.instance.StopSound();
        //StartCoroutine(WaitInLoading(NextsceneName));
        SceneManager.LoadSceneAsync(NextsceneName);
        AudioManager.instance.PlaySound(NextsceneName);


    }

    //IEnumerator WaitInLoading(string NextsceneName)
    //{
    //    yield return new WaitForSecondsRealtime(3f);
    //    FinalLoading(NextsceneName);


    //}

    //private void FinalLoading(string NextsceneName)
    //{
    //    SceneManager.LoadScene(NextsceneName);
    //    AudioManager.instance.PlaySound(NextsceneName);

    //}



}
