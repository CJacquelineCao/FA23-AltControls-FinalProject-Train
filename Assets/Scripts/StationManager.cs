using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationManager : MonoBehaviour
{
    [System.Serializable]
    public class StationsInfo
    {
        public string stationType;
        public bool istheplayerThere;
    }

    public string currentStationName;
    public string nextStationName;
    public List<StationsInfo> totalStations = new List<StationsInfo>();


    public Slider ProgressBar;
    public float totalTime;
    public float currentTime;

    public TravelGame travref;
    public bool reverseTime;
    // Start is called before the first frame update
    void Start()
    {
        totalTime = travref.maxTime * 2;
        currentTime = travref.maxTime;
        SliderSetting();
    }

    // Update is called once per frame
    void Update()
    {
        if(travref.TimerStarted)
        {
            if (currentStationName == "Red")
            {
                ProgressBar.value = travref.elapsedTime;
            }
            else if (currentStationName == "Green")
            {
                if (reverseTime == false)
                {
                    ProgressBar.value = currentTime + travref.elapsedTime;
                }
                else
                {
                    ProgressBar.value = travref.maxTime - travref.elapsedTime;
                }

            }
            else if (currentStationName == "Purple")
            {
                ProgressBar.value = ProgressBar.maxValue - travref.elapsedTime;
            }
        }


    }

    void SliderSetting()
    {
        ProgressBar.minValue = 0;
        ProgressBar.maxValue = totalTime;

    }

    public void updateStationName()
    {
        currentStationName = nextStationName;
    }
    public void goToNextStation()
    {
        for(int i =0; i< totalStations.Count; i++)
        {
            if(currentStationName == totalStations[i].stationType)
            {
                totalStations[i].istheplayerThere = true;
                if(currentStationName == "Purple")
                {
                    nextStationName = totalStations[i-1].stationType;
                    reverseTime = true;
                }
                else
                {
                    if(currentStationName == "Red")
                    {
                        if (reverseTime == true)
                        {
                            reverseTime = false;

                        }
                    }
                    if(reverseTime == false)
                    {
                        nextStationName = totalStations[i + 1].stationType;
                    }
                    else
                    {

                       nextStationName = totalStations[i - 1].stationType;


                    }

                }
            }
            else
            {
                totalStations[i].istheplayerThere = false;
            }
        }
    }
}
