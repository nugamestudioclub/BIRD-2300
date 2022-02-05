using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class test : MonoBehaviour
{
    [SerializeField]
    private string x;
    public GameObject g;
    private List<string> facts =  new List<string>();
    private List<string> notebook = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        facts.Add("Birds got feathers");
        facts.Add("Birds are Birds");
        facts.Add("I dunno pigeons exist");
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addRandomToList()
    {
        if(facts.Count != 0)
        {
            string newFact = facts[Random.Range(0, facts.Count)];
            facts.Remove(newFact);
            notebook.Add(newFact);
        }
    }
}
