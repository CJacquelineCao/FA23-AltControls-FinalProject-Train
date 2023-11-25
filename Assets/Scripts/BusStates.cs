using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStates : MonoBehaviour
{
    public enum BusState
    {
        Board,
        Travel,
        Off
    }
    public BusState currentbusState;

    public bool calledtoStop;
    public StationManager stationref;

    public bool BoardCalled;
    public bool TravelCalled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentbusState)
        {
            case BusState.Board:
                BoardTime();
                break;

            case BusState.Travel:
                TravelTime();
                break;
            case BusState.Off:
                break;

        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(currentbusState == BusState.Travel)
            {
                calledtoStop = true;
            }

        }
    }
    public void SetState(BusState newState)
    {
        if (currentbusState != newState)
        {
            currentbusState = newState;
        }
    }

    void BoardTime()
    {
        //check camera animation controller
        //start board Coroutine;
        if(BoardCalled == false)
        {
            //start board minigame
            BoardCalled = true;
        }
    }

    void TravelTime()
    {
        if(TravelCalled == false)
        {
            //check camera animation controller, close bus doors and pan to left
            //start travel Coroutine;
            stationref.goToNextStation();
            TravelCalled = true;
        }

        
    }
    public void OffTime()
    {
        //check for all aliens that need to get off at stop, if theres none left, then 
        BoardTime();
    }

}
