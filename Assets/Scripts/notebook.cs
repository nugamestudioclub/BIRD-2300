using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class notebook : MonoBehaviour
{
    [SerializeField]
    private string x;
    public GameObject entryGameObj;
    public GameObject parent;

    private List<string> facts = new List<string>();
    private List<string> notebookList = new List<string>();
    private List<GameObject> entryList = new List<GameObject>();
    private bool needsUpdate = false;
    private int currentOffset = -50;
    // Start is called before the first frame update
    void Start()
    {
        facts.Add("   - Birds got feathers.");
        facts.Add("   - Birds are Birds.");
        facts.Add("   - I dunno pigeons exist.");
    }

    // Update is called once per frame
    void Update()
    {

        if (needsUpdate)
        {
            addNewEntry();
            currentOffset -= 50;
            needsUpdate = false;
        }
    }

    private void addNewEntry()
    {
        GameObject newEntry = Instantiate(entryGameObj, new Vector3(0, 0, 0), new Quaternion());
        newEntry
            .GetComponentInChildren<Canvas>()
            .GetComponentInChildren<UnityEngine.UI.Button>()
            .GetComponentInChildren<UnityEngine.UI.Text>().text =
            notebookList[notebookList.Count - 1];
        newEntry
            .GetComponentInChildren<Canvas>()
            .GetComponentInChildren<UnityEngine.UI.Button>()
            .transform
            .Translate(new Vector3(0, currentOffset, 0));
        newEntry.transform.parent = parent.GetComponentInChildren<Canvas>().transform;
        newEntry.transform.localScale = parent.transform.localScale;
        newEntry.transform.position = entryGameObj.transform.position;
        newEntry.SetActive(true);
        entryList.Add(newEntry);
    }

    public void addRandomToList()
    {
        if (facts.Count != 0)
        {
            string newFact = facts[Random.Range(0, facts.Count)];
            facts.Remove(newFact);
            notebookList.Add(newFact);
            needsUpdate = true;
        }
    }
}
