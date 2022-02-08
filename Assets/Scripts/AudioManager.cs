using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {
	[SerializeField]
	List<AudioClipManager> innerAudio;

	[SerializeField]
	List<AudioClipManager> outerAudio;

	[SerializeField]
	private AudioClipManager crows;

	public void FocusIn() {
		foreach( var audio in innerAudio )
			audio.Boost();
		foreach( var audio in outerAudio )
			audio.Muffle();
	}

	public void FocusOut() {
		foreach( var audio in innerAudio )
			audio.Muffle();
		foreach( var audio in outerAudio )
			audio.Boost();
		if( !crows.IsPlaying && GameManager.Instance.Birdiness >= 1 )
			crows.Play();
	}
}