using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSittingAnimationManager : MonoBehaviour
{
    private Animator anim;
    
    private string[] sittingAnims = new string[] { "sitting", "Sitting_Turning_Head_2", "Sitting_Turning_Head_1" };

    [SerializeField]
    private GameObject birdHead;
    private GameManager manager;
    [SerializeField]
    private int birdinessThreshold = 4;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(StartRandom());
        manager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
     
        if (manager.Birdiness>=birdinessThreshold)
        {
            birdHead.gameObject.SetActive(true);
        }
        else if(manager.Birdiness<birdinessThreshold)
        {
            birdHead.gameObject.SetActive(false);
        }

    }

    void PickRandom()
    {
        int choice = Random.Range(0, sittingAnims.Length);

        switch (choice) {
            case 0:
                anim.SetBool("Idle", true);
                anim.SetBool("TurnHead1", false);
                anim.SetBool("TurnHead2", false);

                break;
            case 1:
                anim.SetBool("Idle", false);
                anim.SetBool("TurnHead1", true);
                anim.SetBool("TurnHead2", false);
                break;
            case 2:
                anim.SetBool("Idle", false);
                anim.SetBool("TurnHead1", false);
                anim.SetBool("TurnHead2", true);
                break;
        }


        //anim.Play(a);
        InvokeRepeating("WaitForNextRandom", 4, 0);
        //StartCoroutine(WaitForNextRandom());
    }
    IEnumerator StartRandom()
    {
        yield return new WaitForSeconds(Random.Range(0, 3));
        PickRandom();
    }
    void WaitForNextRandom()
    {
        //yield return new WaitForSeconds(4);
        PickRandom();
        //StartCoroutine(WaitForNextRandom());
    }
}
