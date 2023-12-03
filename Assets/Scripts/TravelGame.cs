using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TravelGame : MonoBehaviour
{
    public BusStates busref;

    public bool hasTurbulance;

    public bool handRailHeld;

    public Animator cameraanimations;

    public float elapsedTime;
    public float maxTime;
    public float t;

    public bool TimerStarted;

    public StationManager stationref;
    public FellasManager fellasref;

    bool turbcalled;

    bool canSomeoneDie;
    public bool delayFinished;

    // Start is called before the first frame update
    private void Awake()
    {
        elapsedTime = 0;
        maxTime = 10;

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (busref.currentbusState == BusStates.BusState.Travel)
        {
            if (hasTurbulance == false)
            {
                int willTurbulenceHappen = Random.Range(0, 300);
                if (willTurbulenceHappen == 0)
                {
                    hasTurbulance = true;
                }
            }
            else
            {
                if(turbcalled == false)
                {
                    StartCoroutine(TurbulanceTime());

                }
                if(delayFinished == true)
                {
                    HoldingCheckTime();
                }
 

            }

            if(Input.GetKey(KeyCode.Space))
            {
                handRailHeld = true;
            }
            if(Input.GetKeyUp(KeyCode.Space))
            {
                handRailHeld = false;
            }
        }
        if (TimerStarted == true)
        {
            elapsedTime += Time.deltaTime;
            t = maxTime - elapsedTime;
            if (t <= 0)
            {
                TravelGameEnd();
            }
        }
    }
    void TravelGameEnd()
    {
        stationref.updateStationName();
        TimerStarted = false;

        if (busref.calledtoStop == true)
        {
            busref.SetState(BusStates.BusState.Off);
            
        }
        else
        {
           
        }
        busref.TravelCalled = false;
    }
    public void TravelGameStart()
    {
        stationref.goToNextStation();
        elapsedTime = 0;
        maxTime = 10;
        TimerStarted = true;

    }

    IEnumerator TurbulanceTime()
    {
        turbcalled = true;
        cameraanimations.SetBool("Turbulence", true);
        StartCoroutine(checkHandRail());
        yield return new WaitForSeconds(Random.Range(3,5));
        hasTurbulance = false;
        cameraanimations.SetBool("Turbulence", false);
        turbcalled = false;
    }

    IEnumerator checkHandRail()
    {
        yield return new WaitForSeconds(2);
        delayFinished = true;
        canSomeoneDie = true;
    }

    void HoldingCheckTime()
    {
        if (handRailHeld == false)
        {
            if (canSomeoneDie == true)
            {
                StartCoroutine(KillOne());
               
            }

        }
        delayFinished = false;
    }

    IEnumerator KillOne()
    {
        canSomeoneDie = false;
        Debug.Log("someone died");
        fellasref.OneFellaFell();
        yield return new WaitForSeconds(5);
        canSomeoneDie = true;
    }
}
