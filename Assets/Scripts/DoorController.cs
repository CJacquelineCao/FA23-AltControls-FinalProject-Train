using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator leftDoor;
    public Animator rightDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoors()
    {
        leftDoor.SetBool("Close", false);
        rightDoor.SetBool("Close", false);

        leftDoor.SetBool("Open", true);
        rightDoor.SetBool("Open", true);
    }

    public void CloseDoors()
    {
        leftDoor.SetBool("Close", true);
        rightDoor.SetBool("Close", true);

        leftDoor.SetBool("Open", false);
        rightDoor.SetBool("Open", false);
    }
}
