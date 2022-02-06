using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPresentingManager : MonoBehaviour
{
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("waitForNextAnim", 4, 0);
        
    }

   void waitForNextAnim()
    {
        //yield return new WaitForSeconds(4);
        int state = Random.Range(0,3);
        switch (state) {
            case 0:
                anim.SetBool("Idle", true);
                anim.SetBool("Pointing_Left", false);
                anim.SetBool("Pointing_Right", false);
                break;
            case 1:
                anim.SetBool("Idle",false);
                anim.SetBool("Pointing_Left", true);
                anim.SetBool("Pointing_Right", false);
                break;
            case 2:
                anim.SetBool("Idle", false);
                anim.SetBool("Pointing_Left", false);
                anim.SetBool("Pointing_Right", true);
                break;
        }
       // StartCoroutine(waitForNextAnim());

    }
}
