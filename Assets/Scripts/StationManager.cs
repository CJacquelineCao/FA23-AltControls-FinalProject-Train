using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationManager : MonoBehaviour
{
    public class StationsInfo
    {
        public string stationType;
        public bool istheplayerThere;
    }

    public string currentStationName;
    public string nextStationName;
    public List<StationsInfo> totalStations = new List<StationsInfo>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void goToNextStation()
    {
        for(int i =0; i< totalStations.Count; i++)
        {
            if(currentStationName == totalStations[i].stationType)
            {
                nextStationName = totalStations[i + 1].stationType;
            }
        }
    }
}
