using UnityEngine;

public class AudioManager : MonoBehaviour {
	[SerializeField]
	private AudioClipManager outerAmbiance;

	[SerializeField]
	private AudioClipManager outerMusic;

	[SerializeField]
	private AudioClipManager innerAmbiance;

	[SerializeField]
	private AudioClipManager innerMusic;

	[SerializeField]
	private AudioClipManager crows;

	private bool isIn;

	// remove hack when better option is available
	void Start() {
		FocusOut();
	}

	// remove hack when better option is available
	void Update() {
		if( Input.GetKeyDown(KeyCode.Tab) ) {
			if( isIn )
				FocusOut();
			else
				FocusIn();
		}
	}
	
	public void FocusIn() {
		isIn = true;
		outerAmbiance.Muffle();
		outerMusic.Muffle();
		innerAmbiance.Boost();
		innerMusic.Boost();

		DebugClip(outerAmbiance);
		DebugClip(outerMusic);
		DebugClip(innerAmbiance);
		DebugClip(innerMusic);
	}
	public void FocusOut() {
		isIn = false;
		outerAmbiance.Boost();
		outerMusic.Boost();
		innerAmbiance.Muffle();
		innerMusic.Muffle();
		if( !crows.IsPlaying && GameManager.Instance.Birdiness >= 1 )
			crows.Play();

		DebugClip(outerAmbiance);
		DebugClip(outerMusic);
		DebugClip(innerAmbiance);
		DebugClip(innerMusic);
	}

	private void DebugClip(AudioClipManager clip) {
		Debug.Log($"{clip.Name}: {clip.IsPlaying}, {clip.Volume}");
	}
}