using UnityEngine;

public class AudioManager : MonoBehaviour {
	[SerializeField]
	private AudioSource classroomAmbiance;

	[SerializeField]
	[Range(0.0f, float.MaxValue)]
	private float classroomMinVolume = 0.5f;

	[SerializeField]
	[Range(0.0f, float.MaxValue)]
	private float classroomMaxVolume = 1.0f;

	[SerializeField]
	private AudioSource crows;

	[SerializeField]
	private AudioSource hedgeAmbiance;

	// remove hack when better option is available
	void Start() {
		FocusOnGame();
	}

	// remove hack when better option is available
	void Update() {
		if( Input.GetKeyDown(KeyCode.Tab) ) {
			if( hedgeAmbiance.isPlaying )
				FocusOnClassroom();
			else
				FocusOnGame();
		}
	}
	
	public void FocusOnClassroom() {
		hedgeAmbiance.Stop();
		classroomAmbiance.volume = classroomMaxVolume;
	}
	public void FocusOnGame() {
		hedgeAmbiance.Play();
		classroomAmbiance.volume = classroomMinVolume;
	}
}