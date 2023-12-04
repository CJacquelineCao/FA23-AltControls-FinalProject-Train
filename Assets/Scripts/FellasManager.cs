using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellasManager : MonoBehaviour
{

    public GameObject FellasPrefab;
    public BusStates busref;
    public BoardGame boardref;
    public Transform doorLocation;
    public List<GameObject> allFellasOnBoard = new List<GameObject>();

    public StationManager stationref;
    public DoorController backdoor;
    public bool allFellasGone;
    public int AmountFellasLeave;
    bool StartCountingFellas;

    public GameController gamecontrollerref;

    public AudioSource beepSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RefreshList();
        if(StartCountingFellas == true)
        {
            if(AmountFellasLeave <= 1)
            {
                allFellasGone = true;
                StartCountingFellas = false;
                AmountFellasLeave = 0;
            }
            else
            {
                allFellasGone = false;
            }
        }
        if(allFellasGone == true)
        {
            StartCoroutine(getOffRoutine());
        }
    }

    public void CreateFella()
    {
        if(boardref.BusFull == false)
        {
            GameObject createdFella = Instantiate(FellasPrefab, doorLocation.position, Quaternion.identity);
            beepSound.Play();
            allFellasOnBoard.Add(createdFella);
        }
        else
        {
            //Bus is full, no one can get on now.
        }

    }

    public void OneFellaFell()
    {
        if(allFellasOnBoard.Count >0)
        {
            for (int i = 0; i < allFellasOnBoard.Count; i++)
            {
                allFellasOnBoard[allFellasOnBoard.Count-1].GetComponent<Alien>().FellOffTheBus();
                break;
            }
        }
    }

    public void RefreshList()
    {
        for (int i = 0; i < allFellasOnBoard.Count; i++)
        {
            if(allFellasOnBoard[i].gameObject == null)
            {
                allFellasOnBoard.Remove(allFellasOnBoard[i]);
            }
        }
    }

    public void LetFellasOff()
    {
        for (int i = 0; i < allFellasOnBoard.Count; i++)
        {
            if(allFellasOnBoard[i].gameObject.GetComponent<Alien>().desiredStation == stationref.currentStationName)
            {
                AmountFellasLeave += 1;
                allFellasOnBoard[i].gameObject.GetComponent<Alien>().GetOff();

                gamecontrollerref.PlayerMoneyCount += 10;
            }
        }
        StartCountingFellas = true;
    }
    IEnumerator getOffRoutine()
    {
        yield return new WaitForSeconds(3f);
        backdoor.CloseDoors();
        busref.SetState(BusStates.BusState.Board);
        busref.OffCalled = false;
        allFellasGone = false;
    }
}
