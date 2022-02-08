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

	public void FocusIn() {
		isIn = true;
		outerAmbiance.Muffle();
		outerMusic.Muffle();
		innerAmbiance.Boost();
		innerMusic.Boost();
	}

	public void FocusOut() {
		isIn = false;
		outerAmbiance.Boost();
		outerMusic.Boost();
		innerAmbiance.Muffle();
		innerMusic.Muffle();
		if( !crows.IsPlaying && GameManager.Instance.Birdiness >= 1 )
			crows.Play();
	}
}