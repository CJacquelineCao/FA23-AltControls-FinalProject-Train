using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TotalGameTimeManager : MonoBehaviour
{
    public Transform clockHand;
    private float timeValue = 200f;

    public float day;

   public GameController gameref;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        day += Time.deltaTime / timeValue;
        float dayNormalized = day % 1;
        float rotationDegreesPerDay = 180f;
        clockHand.eulerAngles = new Vector3(0, 0, 90 - dayNormalized * rotationDegreesPerDay);
        if (day >= 1)
        {
            gameref.GameEnded = true;
        }
        else
        {
            
        }



    }
}
