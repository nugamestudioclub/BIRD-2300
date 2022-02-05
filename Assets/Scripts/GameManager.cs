using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager Instance { get; private set; }

	public bool IsTabbedOut { get; private set; }


	public void ToggleTab() {
		SwitchCamera();
		IsTabbedOut = !IsTabbedOut;
	}

	public void TabOut() {
		IsTabbedOut = true;
	}

	public void TabIn() {
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

	public void SwitchCamera() {
		if( IsTabbedOut )
			SetFullscreen();
		else
			SetWindowed();
	}

	public void SetFullscreen() {
		cam.transform.position = fullscreenPosition;
		cam.transform.Rotate(
			windowedEulerAngles.x - cam.transform.rotation.eulerAngles.x,
			windowedEulerAngles.y - cam.transform.rotation.eulerAngles.y,
			windowedEulerAngles.z - cam.transform.rotation.eulerAngles.z
		);
	}

	public void SetWindowed() {
		cam.transform.position = windowedPosition;
		cam.transform.Rotate(
			fullscreenEulerAngles.x - cam.transform.rotation.eulerAngles.x,
			fullscreenEulerAngles.y - cam.transform.rotation.eulerAngles.y,
			fullscreenEulerAngles.z - cam.transform.rotation.eulerAngles.z
		);
	}

	void Awake() {
		Instance = this;
	}

	void Update() {
		if( Input.GetKeyDown(KeyCode.Tab) )
			ToggleTab();
	}

}
