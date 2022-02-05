using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSittingAnimationManager : MonoBehaviour
{
    private Animator anim;
    
    private string[] sittingAnims = new string[] { "sitting", "Sitting_Turning_Head_2", "Sitting_Turning_Head_1" };

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(StartRandom());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PickRandom()
    {
        int choice = Random.Range(0, sittingAnims.Length);

        switch (choice) {
            case 0:
                anim.SetBool("idle", true);
                anim.SetBool("TurnHead1", false);
                anim.SetBool("TurnHead2", false);

                break;
            case 1:
                anim.SetBool("idle", false);
                anim.SetBool("TurnHead1", true);
                anim.SetBool("TurnHead2", false);
                break;
            case 2:
                anim.SetBool("idle", false);
                anim.SetBool("TurnHead1", false);
                anim.SetBool("TurnHead2", true);
                break;
        }


        //anim.Play(a);
        StartCoroutine(WaitForNextRandom());
    }
    IEnumerator StartRandom()
    {
        yield return new WaitForSeconds(Random.Range(0, 3));
        PickRandom();
    }
    IEnumerator WaitForNextRandom()
    {
        yield return new WaitForSeconds(4);
        PickRandom();
        StartCoroutine(WaitForNextRandom());
    }
}
