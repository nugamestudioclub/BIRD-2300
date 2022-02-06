using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
	private GameObject player;
	private NavMeshAgent agent;

	void Start() {
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update() {
		agent.destination = player.transform.position;
	}
}