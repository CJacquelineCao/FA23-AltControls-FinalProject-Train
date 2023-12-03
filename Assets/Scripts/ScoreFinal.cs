using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreFinal : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    public GameController game;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameref = GameObject.FindGameObjectWithTag("Game");
        if (gameref != null)
        {
            game = gameref.GetComponent<GameController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(game !=null)
        {
            finalScore.text = "You earned: " + "$" + game.PlayerMoneyCount;
        }

    }
}
