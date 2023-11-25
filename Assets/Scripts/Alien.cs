using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public bool Assigned;
    public Vector3 targetLocation;

    public string desiredStation;

    public List<string> potentialStations = new List<string>();
    BusStates busref;
    StationManager stationref;
    // Start is called before the first frame update
    void Start()
    {
        SetDesiredStation();
        busref = GameObject.FindObjectOfType<BusStates>();
        stationref = GameObject.FindObjectOfType<StationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(busref.currentbusState == BusStates.BusState.Off)
        {
            if(stationref.currentStationName == desiredStation)
            {
                GetOff();
            }
        }
        else if(busref.currentbusState == BusStates.BusState.Travel)
        {

        }
    }
    void SetDesiredStation()
    {
        desiredStation = potentialStations[Random.Range(0, potentialStations.Count)];
    }

    void GetOff()
    {
        //Play Animation, and add to player score counter
    }
}
