using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPresentingManager : MonoBehaviour
{
    public Animator anim;
    [SerializeField]
    private GameObject birdHead;

    [SerializeField]
    private int threshold = 4;
    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("waitForNextAnim", 4, 0);
        manager = GameManager.Instance;
    }
    private void Update()
    {
        if (manager.Birdiness >= threshold)
        {
            birdHead.gameObject.SetActive(true);
        }else if (manager.Birdiness < threshold)
        {
            birdHead.gameObject.SetActive(false);
        }
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
