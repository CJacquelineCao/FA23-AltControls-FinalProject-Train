using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource BGSound;
    public AudioClip motorSound;
    public AudioClip turbulenceSound;

    TravelGame travelref;
    BusStates busref;
    bool isMotorPlaying;
    bool isTurbPlaying;

    // Start is called before the first frame update
    void Start()
    {
        travelref = GameObject.FindObjectOfType<TravelGame>();
        busref = GameObject.FindObjectOfType<BusStates>();
    }

    // Update is called once per frame
    void Update()
    {
        if(travelref.hasTurbulance == false)
        {
            if(isMotorPlaying == false)
            {
                BGSound.clip = motorSound;
                BGSound.Play();
                isMotorPlaying = true;
                isTurbPlaying = false;
            }
        }

        else
        {
            if(busref.currentbusState == BusStates.BusState.Travel)
            {
                if (isTurbPlaying == false)
                {
                    BGSound.clip = turbulenceSound;
                    BGSound.Play();
                    isTurbPlaying = true;
                    isMotorPlaying = false;
                }
            }
            else
            {
                if (isMotorPlaying == false)
                {
                    BGSound.clip = motorSound;
                    BGSound.Play();
                    isMotorPlaying = true;
                    isTurbPlaying = false;
                }

            }


        }
    }
}
