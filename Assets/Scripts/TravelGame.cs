using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelGame : MonoBehaviour
{
    public BusStates busref;

    public bool hasTurbulance;

    public bool handRailHeld;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasTurbulance == true)
        {
            StartCoroutine(checkHandRail());
        }
    }
    void TravelGameEnd()
    {
        //when t == 0
        if(busref.calledtoStop == true)
        {
            busref.OffTime();
        }
        else
        {
            busref.SetState(BusStates.BusState.Travel);
            busref.BoardCalled = false;
        }
    }
    void TravelGameStart()
    {
        int willTurbulenceHappen = Random.Range(0, 10);
        if(willTurbulenceHappen == 0)
        {
            hasTurbulance = true;
        }

    }

    IEnumerator TurbulanceTime()
    {
        //play animation
        yield return new WaitForSeconds(Random.Range(3,5));
        hasTurbulance = false;
        //end animation
    }

    IEnumerator checkHandRail()
    {
        yield return new WaitForSeconds(1);
        if (handRailHeld == false)
        {
            //kill one of the aliens on the bus
        }
    }
}
