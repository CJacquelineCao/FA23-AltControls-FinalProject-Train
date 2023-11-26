using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGate : MonoBehaviour
{
    FellasManager managerref;
    // Start is called before the first frame update
    void Start()
    {
        managerref = GameObject.FindObjectOfType<FellasManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Alien")
        {
            managerref.AmountFellasLeave -= 1;
        }
    }
}
