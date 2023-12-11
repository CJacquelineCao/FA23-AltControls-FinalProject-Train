using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alien : MonoBehaviour
{
    public bool Assigned;
    public Vector3 targetLocation;
    public Transform leavingArea;
    public float speed;
    public float lerpValue;
    public string desiredStation;
    public GameObject OrbIndicator;
    public List<string> potentialStations = new List<string>();
    BusStates busref;
    StationManager stationref;

   public Animator alienAnimations;

    bool Scanned;

    public float MaxHealth;
    public float currentHealth;
    public bool isFalling;
    bool GetOffTime;

    public Slider HealthBar;
    // Start is called before the first frame update
    void Start()
    {

        busref = GameObject.FindObjectOfType<BusStates>();
        stationref = GameObject.FindObjectOfType<StationManager>();
       
        leavingArea = GameObject.FindGameObjectWithTag("Leave").transform;
        StartCoroutine(BoardRoutine());

        currentHealth = MaxHealth;
        HealthBar.maxValue = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(busref.currentbusState == BusStates.BusState.Off)
        {
            alienAnimations.SetBool("Hold", false);
        }
        else if(busref.currentbusState == BusStates.BusState.Travel)
        {
            if(Input.GetKey(KeyCode.RightArrow))
            {
                HoldOn();
            }
            if(Input.GetKeyUp(KeyCode.RightArrow))
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
                Scanned = false;
            }
        }
        if(GetOffTime == true)
        {
            if (transform.position != leavingArea.position)
            {
                lerpValue += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(transform.position, leavingArea.position, lerpValue);
            }
            else
            {
                Destroy(this.gameObject, 2f);
            }
        }
        currentHealth -= 0.03f;
        HealthBar.value = currentHealth;
        if(currentHealth <=0)
        {
            alienAnimations.SetBool("Die", true);
        }
    }

    IEnumerator BoardRoutine()
    {
        desiredStation = potentialStations[Random.Range(0, potentialStations.Count)];
        if(desiredStation == "Red")
        {
            OrbIndicator.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (desiredStation == "Green")
        {
            OrbIndicator.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            OrbIndicator.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
        alienAnimations.SetTrigger("Scan");
        yield return new WaitForSeconds(1f);
        Scanned = true;
    }

    void HoldOn()
    {
        alienAnimations.SetBool("Hold", true);
        currentHealth -= 0.1f;
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
            alienAnimations.SetBool("Falling", true);
        }
    }
    public void BroDied()
    {
        Destroy(gameObject);
    }
    public void GetOff()
    {
        alienAnimations.SetBool("Sit", false);
        GetOffTime = true;
    }
}
