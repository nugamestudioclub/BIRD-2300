using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonShooterController : MonoBehaviour {
	public float turnSpeed = 4.0f;
	public float moveSpeed = 2.0f;
	public float minTurnAngle = -90.0f;
	public float maxTurnAngle = 90.0f;
	private float rotX;

	[SerializeField]
	private Camera cam;

	private Vector2 lookInput;
	private Vector2 moveInput;

	public Vector3 groundFacing;
	void Update() {

		if( !GameManager.Instance.IsTabbedOut ) {
			GetInputs();
			UpdateGroundFacing();
		}
		else {
			ResetInputs();
		}
		Look();
		Move();
	}

	private void UpdateGroundFacing() {
		Vector3 trueGroundFacing = transform.rotation.eulerAngles;


		Vector3 removeY = new Vector3(trueGroundFacing.x, 0, trueGroundFacing.y);
		


		groundFacing = removeY;
	}
	void Look() {
		// get the mouse inputs
		float y = lookInput.x * turnSpeed * Time.deltaTime * 100;
		rotX += lookInput.y * turnSpeed * Time.deltaTime * 100;
		// clamp the vertical rotation
		rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);
		// rotate the camera
		transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
	}
	//move to movement script
	void Move() {
		//get my position in the world
		Vector3 moveInputs = new Vector3(moveInput.x, 0, moveInput.y);
		//move in only x and z direction (not y's up or down)
		Vector3 directionMovingForward =
			(new Vector3(transform.forward.x, 0, transform.forward.z)).normalized;

		Vector3 directionMovingSide =
			(new Vector3(transform.right.x, 0, transform.right.z)).normalized;

		Vector3 finalMoveDir = (directionMovingForward * moveInputs.z + directionMovingSide * moveInputs.x)
			.normalized * moveSpeed * Time.deltaTime;

		transform.Translate(finalMoveDir, Space.World);
	}

	public void GetInputs() {
		lookInput = LookInput();
		moveInput = MoveInput();
	}

	private void ResetInputs() {
		lookInput = Vector2.zero;
		moveInput = Vector2.zero;
	}

	public Vector2 MoveInput() {
		return Vector2.ClampMagnitude(
			new Vector2(
				Input.GetAxis("Horizontal"),
				Input.GetAxis("Vertical")),
			1f
		);
	}

	public Vector2 LookInput() {
		return Vector2.ClampMagnitude(
			new Vector2(
				Input.GetAxis("Mouse X"),
				Input.GetAxis("Mouse Y")),
			1f
		);
	}
}
