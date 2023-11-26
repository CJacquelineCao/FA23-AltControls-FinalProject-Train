using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public bool Assigned;
    public Vector3 targetLocation;
    public float speed;
    public float lerpValue;
    public string desiredStation;

    public List<string> potentialStations = new List<string>();
    BusStates busref;
    StationManager stationref;

   public Animator alienAnimations;

    bool Scanned;

    public float MaxHealth;
    public bool isFalling;
    // Start is called before the first frame update
    void Start()
    {

        busref = GameObject.FindObjectOfType<BusStates>();
        stationref = GameObject.FindObjectOfType<StationManager>();
        StartCoroutine(BoardRoutine());
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
            if(Input.GetKey(KeyCode.W))
            {
                HoldOn();
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                LetGo();
            }

        }
        else
        {


        }
        if (Scanned == true)
        {
            Vector3 trueLocation = new Vector3(targetLocation.x, -2.56f, 0);
            if (transform.position != trueLocation)
            {
                lerpValue += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(transform.position, trueLocation, lerpValue);
            }
            else
            {
                lerpValue = 0;
                alienAnimations.SetBool("Sit", true);
            }
        }
    }

    IEnumerator BoardRoutine()
    {
        desiredStation = potentialStations[Random.Range(0, potentialStations.Count)];
        alienAnimations.SetTrigger("Scan");
        yield return new WaitForSeconds(1f);
        Scanned = true;
    }

    void HoldOn()
    {
        alienAnimations.SetBool("Hold", true);
        MaxHealth -= 0.1f;
    }

    void LetGo()
    {
        alienAnimations.SetBool("Hold", false);
    }
    public void FellOffTheBus()
    {
        if(isFalling == false)
        {
            isFalling = true;
        }
    }
    void GetOff()
    {
        //Play Animation, and add to player score counter
    }
}
