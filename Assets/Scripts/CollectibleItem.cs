using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour {
	[SerializeField]
	private bool destroyOnCollect = true;

	[SerializeField]
	private bool spinning = true;

	[SerializeField]
	[Range(0.0f, float.MaxValue)]
	private float spinSpeed = 100.0f;

	void OnTriggerEnter(Collider collision) {
		if( collision.tag == "Player" )
			Collect();
	}

	private void Collect() {
		GameManager.Instance.Notebook?.createNewEntry();
		if( destroyOnCollect )
			Destroy(gameObject);
	}

	void Update() {
		if( spinning )
			transform.Rotate(0.0f, spinSpeed * Time.deltaTime, 0.0f);
	}
}