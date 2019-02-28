
using UnityEngine;
using System.Collections;

public class Sensors: MonoBehaviour
{
    //Animator doorAnim;
  
    //public string doorAnimationName = "doorMovement";

    //public double doorDistance = 2.0;
    public double litDistance = 2.0;

    //public Transform door;
    public Transform lit;
    public Transform player;
    public GameObject identity;
    public GameObject IdentityCamera;
    public GameObject[] lights;
 


    private bool Activated = false;


    private void Awake()
    {
        //doorAnim = door.GetComponent<Animator>();
     
          if (identity.activeSelf)
            identity.SetActive(false);

        if (IdentityCamera.activeSelf)
            IdentityCamera.SetActive(false);

    }
    
    void LateUpdate()
    {
        
        if (Vector3.Distance(lit.position, player.position) <= litDistance)
        {
            if (!Activated)
            {
                foreach (GameObject light in lights)
                {
                    light.SetActive(false);
                }
                identity.SetActive(true);
                IdentityCamera.SetActive(true);
                AudioManager.IsPlaying = false;
                
                // AudioManager.instance.StopSound();
                Activated = true;

            }


        }      
        
           
                
     }

   





    
}

