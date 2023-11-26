using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parala : MonoBehaviour
{
    public bool isSpace;
    public BusStates busref;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSpace == true)
        {
            if(busref.currentbusState == BusStates.BusState.Travel)
            {
                transform.position += new Vector3(-12 * Time.deltaTime, 0);
                if (transform.position.x < -67.7)
                {
                    transform.position = new Vector3(-21.6f, transform.position.y);
                }
            }

        }
        else
        {
            if (busref.currentbusState == BusStates.BusState.Travel)
            {
                transform.position += new Vector3(-10 * Time.deltaTime, 0);
                if (transform.position.x < -67.7)
                {
                    transform.position = new Vector3(-21.6f, transform.position.y);
                }
            }

        }
    }
}
