using UnityEngine;

public class World : GameObject {
	[SerializeField]
	private Vetor3 windowedPosition;
	
	[SerializeField]
	private Vector3 windowedEulerAngles;
	
	[SerializeField]
	private Vector3 fullscreenPosition;
	
	[SerializeField]
	private Vector3 fullscreenEulerAngles;]
	
	[SerializeField]
	private Camera cam;
	
	private bool fullscreen = true;
	
	public SwitchCamera() {
		if( fullScreen )
			SetWindowed();
		else
			SetFullscreen();
	}
	
	public SetFullScreen() {
		cam.transform.position = fullscreenPosition;
		cam.transform.rotation = windowedEulerAngles;
		fullscreen = true;
	}
	
	public SetWindowed() {
		cam.transform.position = windowedPosition;
		cam.transform.rotation = windowedEulerAngles;
		fullScreen = false;
	}
}