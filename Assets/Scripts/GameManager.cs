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

	[SerializeField]
	private Vector3 windowedPosition;

	[SerializeField]
	private Vector3 windowedEulerAngles;

	[SerializeField]
	private Vector3 fullscreenPosition;

	[SerializeField]
	private Vector3 fullscreenEulerAngles;

	[SerializeField]
	private Camera cam;

	private bool fullscreen = true;

	public void SwitchCamera()
	{
		if (fullscreen)
			SetWindowed();
		else
			SetFullscreen();
	}

	public void SetFullscreen()
	{
		cam.transform.position = fullscreenPosition;
		//cam.transform.rotation = windowedEulerAngles;
		fullscreen = true;
	}

	public void SetWindowed()
    {
        cam.transform.position = windowedPosition;
       // cam.transform.rotation = windowedEulerAngles;
        fullscreen = false;
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
