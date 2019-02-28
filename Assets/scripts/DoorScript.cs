using UnityEngine;


public class DoorScript : MonoBehaviour {

    public float doorDistance=5f;
    public string BurnSceneName = "burn_scene";
    [HideInInspector]
    public static bool Actiavted = false;

    [SerializeField] private GameObject reverse_button;
    [SerializeField] private Transform car;
    [SerializeField] private GameObject[] effects;
    
    GameObject thedoor;

    private void Awake()
    {
        foreach (GameObject effect in effects)
        {
            effect.SetActive(false);
        }
    }


    private void FixedUpdate()
    {
      
        if (Vector3.Distance(transform.position, car.position)<=doorDistance)
        {
           // StartCoroutine(LoadNextScene());
            foreach (GameObject effect in effects)
            effect.SetActive(true);

            if (!Actiavted)
            {
                // yield return new WaitForSeconds(1f);
                
                thedoor = GameObject.FindWithTag("SF_Door");
                thedoor.GetComponent<Animation>().Play("open");
                Actiavted = true;
                reverse_button.SetActive(false);
                GameManager.instance.LoadTheScene(BurnSceneName);


            }
            
          
            
        }
    }

    //IEnumerator LoadNextScene()
    //{
    //    foreach(GameObject effect in effects)
    //    {
    //        effect.SetActive(true);
    //    }
    //   // yield return new WaitForSeconds(1f);
    //    GameManager.instance.LoadTheScene(BurnSceneName);

    //}


}
