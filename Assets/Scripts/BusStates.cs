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

    public bool BoardCalled;
    public bool TravelCalled;
    public bool OffCalled;

    public Animator cameraanimations;

    public TravelGame travelref;
    public BoardGame boardref;

    public DoorController backdoor;
    public FellasManager fellasref;
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
                OffTime();
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
        //start board Coroutine;
        if(BoardCalled == false)
        {
            cameraanimations.SetBool("Traveling", false);
            //start board minigame
            boardref.BoardGameStart();
            BoardCalled = true;
        }
    }

    void TravelTime()
    {
        if(TravelCalled == false)
        {
            //check camera animation controller, close bus doors and pan to left
            //start travel Coroutine;
            travelref.TravelGameStart();
            cameraanimations.SetBool("Traveling", true);
            TravelCalled = true;
        }

        
    }
    public void OffTime()
    {
        if(OffCalled == false)
        {
            calledtoStop = false;
            cameraanimations.SetBool("Turbulence", false);
            backdoor.OpenDoors();
            fellasref.LetFellasOff();
            OffCalled = true;
        }

        //check for all aliens that need to get off at stop, if theres none left, then 

    }

}
