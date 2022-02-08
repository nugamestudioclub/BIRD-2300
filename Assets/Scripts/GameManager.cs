using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	
    public static GameManager Instance { get; private set; }

	public bool IsTabbedOut { get; private set; }

	[SerializeField]
	private notebook notebook;
	public notebook Notebook => notebook;

	[SerializeField]
	AudioManager audioManager;

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
		audioManager.FocusOut();
    }

    public void TabIn()
    {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		IsTabbedOut = false;
		audioManager.FocusIn();
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
    }

	void Start() {
		TabOut();
	}

	void Update()
    {
		//debugging
		if (Input.GetKeyDown(KeyCode.B))
        {
			//Birdiness++;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
            ToggleTab();
    }

	[SerializeField]
	private int grade = 100;

	public void AdjustGrade(int delta)
    {
		grade += delta;
    }
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

	public int Birdiness { get; set; }
}
