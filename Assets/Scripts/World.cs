using UnityEngine;

public class World : MonoBehaviour {
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
		
		cam.transform.Rotate(
			windowedEulerAngles.x - cam.transform.rotation.eulerAngles.x,
			windowedEulerAngles.y - cam.transform.rotation.eulerAngles.y,
			windowedEulerAngles.z - cam.transform.rotation.eulerAngles.z
		);
		fullscreen = true;
	}
	
	public SetWindowed() {
		cam.transform.position = windowedPosition;
		
		cam.transform.Rotate(
			fullscreenEulerAngles.x - cam.transform.rotation.eulerAngles.x,
			fullscreenEulerAngles.y - cam.transform.rotation.eulerAngles.y,
			fullscreenEulerAngles.z - cam.transform.rotation.eulerAngles.z
		);
		fullScreen = false;
	}
}