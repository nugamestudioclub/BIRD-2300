using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonShooterController : MonoBehaviour {
	public float turnSpeed = 4.0f;
	public float moveSpeed = 2.0f;
	public float minTurnAngle = -90.0f;
	public float maxTurnAngle = 90.0f;
	private float lookX;

	[SerializeField]
	private Camera cam;

	public Vector3 groundFacing;
	void Update() {
		if( !GameManager.Instance.IsTabbedOut ) {
			Look();
			Move();
		}
	}

	private Vector2 LookInput() {
		return Vector2.ClampMagnitude(
			new Vector2(
				Input.GetAxis("Mouse X"),
				Input.GetAxis("Mouse Y")),
			1f
		);
	}

	private void LookX(float deltaX) {
		lookX = Mathf.Clamp(lookX - deltaX, minTurnAngle, maxTurnAngle);
		cam.transform.eulerAngles = new Vector3(
			lookX,
			cam.transform.eulerAngles.y,
			cam.transform.eulerAngles.z
		);
	}

	private void LookY(float deltaY) {
		float lookY = transform.eulerAngles.y + deltaY;

		transform.eulerAngles = new Vector3(
			transform.eulerAngles.x,
			lookY,
			transform.eulerAngles.z
		);
	}

	private void Look() {
		float factor = 100 * turnSpeed * Time.deltaTime;
		var input = LookInput();

		LookX(input.y * factor);
		LookY(input.x * factor);
	}

	private Vector2 MoveInput() {
		return Vector2.ClampMagnitude(
			new Vector2(
				Input.GetAxis("Horizontal"),
				Input.GetAxis("Vertical")),
			1f
		);
	}

	private void Move() {
		var input = MoveInput();
		var moveInputs = new Vector3(input.x, 0.0f, input.y);
		var directionMovingForward = new Vector3(
			transform.forward.x,
			0.0f,
			transform.forward.z
		).normalized;
		var directionMovingSide = new Vector3(
			transform.right.x,
			0.0f,
			transform.right.z
		).normalized;
		var finalMoveDir = moveSpeed * Time.deltaTime *
			(directionMovingForward * moveInputs.z + directionMovingSide * moveInputs.x)
			.normalized;

		transform.Translate(finalMoveDir, Space.World);
	}
}
