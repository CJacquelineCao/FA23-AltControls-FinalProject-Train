using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellasManager : MonoBehaviour
{

    public GameObject FellasPrefab;
    public Transform doorLocation;
    public List<GameObject> allFellasOnBoard = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateFella()
    {
       GameObject createdFella = Instantiate(FellasPrefab, doorLocation.position, Quaternion.identity);
        allFellasOnBoard.Add(createdFella);
    }

    public void OneFellaFell()
    {
        if(allFellasOnBoard.Count >0)
        {
            for(int i =0; i<allFellasOnBoard.Count; i++)
            {
                allFellasOnBoard[allFellasOnBoard.Count].GetComponent<Alien>().FellOffTheBus();
                break;
            }
        }
    }
}
