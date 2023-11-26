using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int PlayerMoneyCount;
    public TMP_Text MoneyText;

    public float elapsedTime;
    public float maxTime;
    public float t;

    public bool TimerStarted;
    // Start is called before the first frame update
    void Start()
    {
        TimerStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = "$" + PlayerMoneyCount;

        if (TimerStarted == true)
        {
            elapsedTime += Time.deltaTime;
            t = maxTime - elapsedTime;
            if (t <= 0)
            {
                //load endscene and show playerScore
            }
        }
    }
}
