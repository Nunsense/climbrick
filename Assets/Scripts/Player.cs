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

			if (pos.y <= -5) {
				pos = Vector3.zero;
			}

			transform.position = pos;
		}
	}

	public void JumpTo(Vector3 target) {
		jumpTarget = target;
		isJumping = true;
		body.AddForce(Vector3.up * jumpForce);
	}

	void OnCollisionEnter(Collision col) {
		if (isJumping && col.gameObject.tag == "Step") {
			transform.position = jumpTarget;
			isJumping = false;
			tower.NextFloor();
		}
	}
}
