using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationObserver : MonoBehaviour
{
    public Alien mainScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AlertObservers(string message)
    {
        if (message.Equals("AnimationEnded"))
        {
            mainScript.BroDied();
        }
    }
}
