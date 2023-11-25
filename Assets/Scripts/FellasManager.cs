using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellasManager : MonoBehaviour
{

    public GameObject FellasPrefab;
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
       GameObject createdFella = Instantiate(FellasPrefab);
        allFellasOnBoard.Add(createdFella);
    }
}
