using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int PlayerMoneyCount;
    public TMP_Text MoneyText;

    public bool GameEnded;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = "$" + PlayerMoneyCount;

        if(GameEnded == true)
        {
            if(SceneManager.GetActiveScene().buildIndex ==1)
            {
                SceneManager.LoadScene(2);
            }

        }
    }

    
}
