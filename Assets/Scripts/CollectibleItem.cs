using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour {
	[SerializeField]
	private bool destroyOnCollect = true;

	void OnTriggerEnter(Collider collision) {
		if( collision.tag == "Player" )
			Collect();
	}

	private void Collect() {
		GameManager.Instance.Notebook?.createNewEntry();
		if( destroyOnCollect )
			Destroy(gameObject);
	}
}