using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float moveTime = 1f;
	private float currentTime;
	private Vector3 movTarget;
	private bool isMoving = false;
	
	public void MoveY(float dy) {
		movTarget = transform.position;
		movTarget.y += dy;
		isMoving = true;
		currentTime = 0;
	}

	void Update () {
		if (isMoving) {
			currentTime += Time.deltaTime;
			transform.position = Vector3.Lerp(transform.position, movTarget, currentTime / moveTime);

			if (currentTime >= moveTime) {
				isMoving = false;
			}
		}
	}
}
