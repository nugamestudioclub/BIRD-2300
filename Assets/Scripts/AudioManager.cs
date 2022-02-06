using UnityEngine;

public class AudioManager : MonoBehaviour {
	[SerializeField]
	private AudioSource classroomAmbiance;

	[SerializeField]
	[Range(0.0f, 0.5f)]
	private float classroomAmbianceBoost = 0.1f;

	[SerializeField]
	private AudioSource gameMusic;

	[SerializeField]
	[Range(0.0f, 0.5f)]
	private float gameMusicBoost = 0.5f;

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
		classroomAmbiance.volume += classroomAmbianceBoost;
		gameMusic.volume -= gameMusicBoost;
		if( !crows.isPlaying && GameManager.Instance.Birdiness >= 1 )
			crows.Play();
	}
	public void FocusOnGame() {
		hedgeAmbiance.Play();
		classroomAmbiance.volume -= classroomAmbianceBoost;
		gameMusic.volume += gameMusicBoost;
	}
}