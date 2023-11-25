using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGame : MonoBehaviour
{
    [System.Serializable]
    public class HandRails
    {
        public GameObject handRailObject;
        public bool Taken;
    }

    public List<HandRails> totalRails = new List<HandRails>();

    public FellasManager fellaref;
    // Start is called before the first frame update
    public BusStates busref;
    void Start()
    {
        
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
                        fellaref.allFellasOnBoard[a].GetComponent<Alien>().Assigned = true;
                    }
                }
            }
        }
    }
    void BoardGameStart()
    {
        //when t == 0
        busref.SetState(BusStates.BusState.Travel);
        busref.BoardCalled = false;
    }
}
