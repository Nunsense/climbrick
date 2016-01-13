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
}
