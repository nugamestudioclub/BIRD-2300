using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour {
	[SerializeField]
	private bool destroyOnCollect = true;

	private bool isCollected = false;
	private float collectedTime;

	[SerializeField]
	private bool spinning = true;

	[SerializeField]
	[Range(0.0f, float.MaxValue)]
	private float spinSpeed = 100.0f;

	[SerializeField]
	AudioSource audioSource;

	[SerializeField]
	AudioClip collectSound;

	void OnTriggerEnter(Collider collision) {
		if( collision.tag == "Player" ) 
			Collect();
	}

	private void Collect() {
		GameManager.Instance.Notebook?.createNewEntry();
		audioSource.PlayOneShot(collectSound);
		if (destroyOnCollect)
			isCollected = true;
	}

	void Update() {
		if( spinning )
			transform.Rotate(0.0f, spinSpeed * Time.deltaTime, 0.0f);
		if (isCollected)
        {
			collectedTime += Time.deltaTime;
			if (collectedTime > collectSound.length)
			{
				Destroy(gameObject);
			}
		}
		
	}
}