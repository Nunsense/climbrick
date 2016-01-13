using UnityEngine;
using System.Collections;

public class Step : MonoBehaviour {

	private Tower tower;
	public BoxCollider cube;

	void Awake() {
		cube = GetComponent<BoxCollider> ();
		tower = FindObjectOfType<Tower>();
	}

	void OnMouseDown() {
		tower.JumpToStep(transform);
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			cube.enabled = false;
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "Player") {
			cube.enabled = true;
		}
	}
}
