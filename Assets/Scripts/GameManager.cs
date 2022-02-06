using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	
    public static GameManager Instance { get; private set; }


    public bool IsTabbedOut { get; private set; }


    public void ToggleTab()
    {
		if (IsTabbedOut) {
			TabIn();
        }
        else
        {
			TabOut();
        }
    }

    public void TabOut()
    {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		IsTabbedOut = true;
    }

    public void TabIn()
    {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		IsTabbedOut = false;
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

	public Camera innerPlayerCam;

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
		TabIn();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            ToggleTab();
    }

	private int grade;

	public string LetterGrade
	{
		get
		{
			if (grade > 100)
				return "S";
			if (grade >= 97)
				return "A+";
			if (grade >= 94)
				return "A";
			if (grade >= 90)
				return "A-";
			if (grade >= 87)
				return "B+";
			if (grade >= 84)
				return "B";
			if (grade >= 80)
				return "B-";
			if (grade >= 77)
				return "C+";
			if (grade >= 74)
				return "C";
			if (grade >= 70)
				return "C-";
			if (grade >= 67)
				return "D+";
			if (grade >= 64)
				return "D";
			return "F";
		}
	}

	public int Grade { get; set; }

	public int Birdiness { get; set; }
}
