using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideGameManager : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    
    private bool animRunning = false;
    private bool notebookOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)&&!animRunning)
        {
            if (notebookOpen)
            {
                anim.Play("Hide");
            }
            else
            {
                anim.Play("Show");
            }
            notebookOpen = !notebookOpen;
            StartCoroutine(WaitForAnimationOver());
        }
    }

    IEnumerator WaitForAnimationOver()
    {
        animRunning = true;
        yield return new WaitForSeconds(2f);
        animRunning = false;
    }
}
