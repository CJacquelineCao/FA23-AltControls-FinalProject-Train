using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
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
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            LoadGameScene();
        }
    }
    public void LoadGameScene()
    {
        if(game !=null)
        {
            Destroy(game.gameObject);

        }
        SceneManager.LoadScene(1);
    }
    public void LoadMenu()
    {
        if (game != null)
        {
            Destroy(game.gameObject);

        }
        SceneManager.LoadScene(0);
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene(3);
    }
}
