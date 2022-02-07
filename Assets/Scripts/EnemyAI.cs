using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
	private GameObject player;

	private NavMeshAgent agent;
	private Animator animator;

	[SerializeField]
	private float spotDistance = 10.0f;
	[SerializeField]
	private int maxHealth = 10;
	private int _currentHealth;

	[HideInInspector]
	public bool isDying = false;
	[SerializeField]
	private float deathtime = 1.5f;
	private float _currentDeathtime;

	[SerializeField]
	Bark bark;

	void Start() {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponentInChildren<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");

		_currentHealth = maxHealth;
		_currentDeathtime = 0f;
	}

	void Update() {
		
		if (isDying)
        {
			_currentDeathtime += Time.deltaTime;
        } else
        {
			var distance = Vector3.Distance(transform.position, player.transform.position);

			//Debug.Log(distance);
			if (distance <= spotDistance)
				agent.destination = player.transform.position;
			else
				agent.ResetPath();
		}
		

		if (_currentDeathtime > deathtime)
		{
			Destroy(gameObject);
		}
	}

	public void TakeDamage(int dmg)
    {
		_currentHealth -= dmg;
		if (_currentHealth <=0)
        {
			Die();
        }
    }

	private void Die()
    {
		//play death animation
		animator.Play("dying");
		//play death sound
		bark.Die();
		//start dying
		isDying = true;
    }
}