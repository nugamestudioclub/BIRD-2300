using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isTabbbedOut { get; private set; }


    public void ToggleTab()
    {
        isTabbbedOut = !isTabbbedOut;
    }

    public void TabOut()
    {
        isTabbbedOut = true;
    }

    public void TabIn()
    {
        isTabbbedOut = false;
    }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            ToggleTab();
    }

}
