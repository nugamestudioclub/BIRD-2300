using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TextAsset dialogText;
    public OutsideGameManager manager;
    private bool finishedInitLines = false;

    private string[] eventOptions;
    private string[] initLines;
    private bool waitingOnSubmit = true;

    // Start is called before the first frame update
    void Start()
    {
        string initDialog = dialogText.text.Split('_')[0];
        string randDialog = dialogText.text.Split('_')[1];
        this.eventOptions = randDialog.Split('\n');
        this.initLines = initDialog.Split('\n');

        
    }
    //Starts initial dialog and events.
    public void StartEvents()
    {
        StartCoroutine(SayInitialLine(0, this.initLines));
        
    }

    //Say each iniital lines with 8 second delay between each line. When finished start randomly called events.
    IEnumerator SayInitialLine(int i,string[] initLines)
    {
        
        manager.Say(initLines[i]);
        
        yield return new WaitForSeconds(4);
        if (initLines.Length > i+1)
        {
            StartCoroutine(SayInitialLine(i + 1,initLines));
        }
        else
        {
            print("Starting new coroutine");
            this.finishedInitLines = true;
            StartCoroutine(WaitForNextEvent());
        }
        
    }

    //Say random event between 15 to 30 seconds.
    IEnumerator WaitForNextEvent()
    {
        float dur = Random.Range(20, 30);
        yield return new WaitForSeconds(dur);
        int choice = Random.Range(1, this.eventOptions.Length);
        
        manager.Say(this.eventOptions[choice]);
        this.waitingOnSubmit = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (manager.hasSubmitted()&&waitingOnSubmit)
        {
            waitingOnSubmit = false;
            StartCoroutine(WaitForNextEvent());
        }
    }
}
