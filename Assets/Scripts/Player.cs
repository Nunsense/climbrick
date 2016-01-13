using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float jumpForce = 500f;

	private Tower tower;
	private Vector3 jumpTarget;
	private bool isJumping;
	private Rigidbody body;

	void Awake() {
		tower = FindObjectOfType<Tower>();
		body = GetComponent<Rigidbody>();
	}

	void Update() {
		if (isJumping) {
			Vector3 pos = transform.position;
			pos.x = Mathf.Lerp(pos.x, jumpTarget.x, Time.deltaTime);

			if (body.velocity.y < 0 && pos.y - jumpTarget.y <= 2) {
				pos.z = -0.1f;
			} else {
				pos.z = -5;
			}

			transform.position = pos;
		}
	}

	public void JumpTo(Vector3 target) {
		if (isJumping)
			return;

		jumpTarget = target;
		isJumping = true;
		body.AddForce(Vector3.up * jumpForce);
	}

	void OnCollisionEnter(Collision col) {
		if (isJumping && col.gameObject.tag == "Step") {
			isJumping = false;
			tower.NextFloor();
		}
	}
}
