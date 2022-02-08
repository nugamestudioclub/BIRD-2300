using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioClipManager : MonoBehaviour {
	private AudioSource audioSource;

	private float originalVolume;

	[SerializeField]
	[Range(0.0f, 1.0f)]
	private float muffle = 1.0f;

	void Awake() {
		audioSource = GetComponent<AudioSource>();
		originalVolume = audioSource.volume;
	}

	public bool IsPlaying => audioSource.isPlaying;

	public float Volume {
		get => audioSource.volume;
		private set => audioSource.volume = value;
	}

	public string Name => audioSource.clip.name;

	public void Play() {
		audioSource.Play();
	}

	public void Stop() {
		audioSource.Stop();
	}

	public void Boost() {
		Volume = originalVolume;
		if( !IsPlaying )
			Play();
	}

	public void Muffle() {
		Debug.Log(nameof(Muffle));
		Debug.Log(audioSource == null);
		try {
			Volume *= 1.0f - muffle;
		}
		catch( System.Exception ex) {
			Debug.Log(ex.Message);
		}
	}
}
