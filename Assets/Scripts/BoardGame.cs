using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoardGame : MonoBehaviour
{
    [System.Serializable]
    public class HandRails
    {
        public GameObject handRailObject;
        public GameObject assignedAlien;
        public bool Taken;
    }

    public List<HandRails> totalRails = new List<HandRails>();

    public FellasManager fellaref;

    public TMP_Text timerText;
    private float elapsedTime;
    private float maxTime;
    public float t;

    public bool TimerStarted;

    public DoorController doorref;

    public bool BusFull;
    // Start is called before the first frame update
    public BusStates busref;
    void Start()
    {
        elapsedTime = 0;
        maxTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(busref.currentbusState == BusStates.BusState.Board)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                fellaref.CreateFella();
                AssigntoHandRail();
            }
        }
        if(TimerStarted == true)
        {
            elapsedTime += Time.deltaTime;
            t = maxTime - elapsedTime;
            string hours = ((int)t / 60).ToString();
            string minutes = ((int)t % 60).ToString("00");

            timerText.text = hours + ":" + minutes;
            if (t <= 0)
            {
                BoardGameEnd();

            }
        }
        refreshHandRail();

    }

    void AssigntoHandRail()
    {
        for(int i =0; i<totalRails.Count; i++)
        {
            if(totalRails[i].Taken == false)
            {
                for (int a = 0; a < fellaref.allFellasOnBoard.Count; a++)
                {
                    if(fellaref.allFellasOnBoard[a].GetComponent<Alien>().Assigned == false)
                    {
                        fellaref.allFellasOnBoard[a].GetComponent<Alien>().targetLocation = totalRails[i].handRailObject.transform.position;
                        totalRails[i].Taken = true;
                        totalRails[i].assignedAlien = fellaref.allFellasOnBoard[a];
                        fellaref.allFellasOnBoard[a].GetComponent<Alien>().Assigned = true;
                    }
                }
            }
        }
        if (AreAllRailsFull())
        {
            BusFull = true;
        }
        else
        {
            BusFull = false;
        }
    }
    void refreshHandRail()
    {
        for (int i = 0; i < totalRails.Count; i++)
        {
            if(totalRails[i].assignedAlien == null)
            {
                totalRails[i].Taken = false;
            }

        }
    }
    public bool AreAllRailsFull()
    {
        for (int i = 0; i < totalRails.Count; i++)
        {
            if (totalRails[i].Taken == false)
            {
                return false;
            }
  
        }
        return true;
    }
    public void BoardGameStart()
    {
        TimerStarted = true;
        doorref.OpenDoors();
    }
    void BoardGameEnd()
    {

        //when t == 0
        doorref.CloseDoors();
        busref.SetState(BusStates.BusState.Travel);
        busref.BoardCalled = false;
        TimerStarted = false;
        elapsedTime = 0;
        maxTime = 10;
    }
}
