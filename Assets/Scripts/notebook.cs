using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class notebook : MonoBehaviour
{
    [SerializeField]
    private string x;
    public GameObject entryGameObj;
    public GameObject parent;

    [SerializeField]

    private List<string> facts = new List<string>();
    private List<string> notebookList = new List<string>();
    private List<GameObject> entryList = new List<GameObject>();
    private bool needsUpdate = false;
    private int currentOffset = -50;


    [SerializeField]
    private GameObject buttonObject;
    [SerializeField]
    private Canvas entryCanvas;
    private int activeEntires = 0;
    private List<string> remFacts = new List<string>();
    private List<Button> entries = new List<Button>();
    public OutsideGameManager dialogManager;
    public TextAsset factsTxt;

    public bool isInteractible { get; set; } = false;


    // Start is called before the first frame update
    void Start()
    {
        string[] txt = factsTxt.text.Split('\n');
        foreach(string s in txt)
        {
            facts.Add("   - "+s);
        }


        facts.Add("   - Birds got feathers.");
        facts.Add("   - Birds are Birds.");
        facts.Add("   - I dunno pigeons exist.");

        remFacts.AddRange(facts);
        //createNewEntry();
        //createNewEntry();
        //createNewEntry();
        //createNewEntry();

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
        //    createNewEntry();
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


    public void createNewEntry()
    {
        
        GameObject newBtn = Instantiate(buttonObject,entryCanvas.transform);
        newBtn.transform.localPosition = new Vector3(0,200-(this.activeEntires*70),0);
        int i = Random.Range(0, remFacts.Count);
        newBtn.GetComponentInChildren<Text>().text = facts[i];
        remFacts.RemoveAt(i);
        if (remFacts.Count == 0)
        {
            remFacts.AddRange(facts);
        }
        this.activeEntires += 1;
        entries.Add(newBtn.GetComponent<Button>());
        newBtn.GetComponent<Button>().onClick.AddListener(delegate { this.SubmitTxt(facts[i]); });
        dialogManager.NotifyNoteAdded();
    }

    

    private void SubmitTxt(string txt) {
        //print("Conditions:" + GameManager.Instance.CanInteract + ":" + this.isInteractible);
        if (this.isInteractible)
        {
            this.removeEntry(txt);
            dialogManager.SubmitText(txt);
        }
    }
    
    public void removeEntry(string name)
    {
        int pos = -1;

        for(int i = 0; i < this.entries.Count; i++)
        {
            if (entries[i].GetComponentInChildren<Text>().text == name)
            {
                pos = i;
            }
        }
        if (pos != -1)
        {
            Button btn = entries[pos];
            Destroy(btn.gameObject);
            entries.RemoveAt(pos);
        }
        for(int i = pos; i < this.entries.Count; i++)
        {
            Vector3 localPos = this.entries[i].transform.localPosition;
            this.entries[i].transform.localPosition = new Vector3(localPos.x, localPos.y+70, localPos.z);
        }
        this.activeEntires -= 1;
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


   
    public int getEntryCount()
    {
        return this.facts.Count;
    }
}
