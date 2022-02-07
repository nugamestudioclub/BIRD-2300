using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour {
	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip attack;

	[SerializeField]
	private AudioClip death;

	public void Attack() {
		audioSource.PlayOneShot(attack);
	}

	public void Die() {
		audioSource.PlayOneShot(death);
	}
}