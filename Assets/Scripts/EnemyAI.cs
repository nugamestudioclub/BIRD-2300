using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
	private GameObject player;

	private NavMeshAgent agent;

	[SerializeField]
	private float spotDistance = 10.0f;

	void Start() {
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update() {
		var distance = Vector3.Distance(transform.position, player.transform.position);


		Debug.Log(distance);
		if( distance <= spotDistance )
			agent.destination = player.transform.position;
		else
			agent.ResetPath();
	}
}