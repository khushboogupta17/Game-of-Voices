using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DistanceCalculator : MonoBehaviour {
    public Transform End;
    public Transform car;
    public TextMeshProUGUI distanceText;
     float distance;
    

	
	// Update is called once per frame
	void Update () {

        distance =  End.position.z - car.position.z ;
        distanceText.text = distance.ToString("00") + " m to go...";

	}
}
