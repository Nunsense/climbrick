using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {

	private Tower tower;
	private int currentRotation;
	private static int[] rotations = { 0, 90, 180, 270 };

	//inside class
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	void Awake() {
		tower = FindObjectOfType<Tower>();
	}

	void Start() {
		Quaternion rot = new Quaternion();
		currentRotation = rotations[Random.Range(0, rotations.Length)];
		rot.eulerAngles = new Vector3(0, currentRotation, 0);
		transform.rotation = rot;
	}

	void Update() {
		KeyboardSwipe();
	}

	public void MobileSwipe() {
		if (Input.touches.Length > 0) {
			Touch t = Input.GetTouch(0);
			if (t.phase == TouchPhase.Began) {
				//save began touch 2d point
				firstPressPos = new Vector2(t.position.x, t.position.y);
			}
			if (t.phase == TouchPhase.Ended) {
				//save ended touch 2d point
				secondPressPos = new Vector2(t.position.x, t.position.y);
	                           
				//create vector from the two points
				currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
	               
				//normalize the 2d vector
				currentSwipe.Normalize();
	 
				//swipe upwards
				if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					Debug.Log("up swipe");
				}
				//swipe down
				if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					Debug.Log("down swipe");
				}
				//swipe left
				if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
					Debug.Log("left swipe");
				}
				//swipe right
				if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
					Debug.Log("right swipe");
				}
			}
		}
	}


	public void KeyboardSwipe() {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 pos = transform.position;
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (pos.y + tower.halfFloorH > mousePos.y && pos.y - tower.halfFloorH < mousePos.y) {
				firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);	
			} else {
				firstPressPos = Vector2.zero;
			}
		}
		if (firstPressPos != Vector2.zero && Input.GetMouseButtonUp(0)) {
			//save ended touch 2d point
			secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
       
			//create vector from the two points
			currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
           
			//normalize the 2d vector
			currentSwipe.Normalize();
 
			//swipe upwards
			if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
				Debug.Log("up swipe");
			}
			//swipe down
			if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
				Debug.Log("down swipe");
			}
			//swipe left
			if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
				Turn(-1);
			}
			//swipe right
			if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
				Turn(1);
			}
			firstPressPos = Vector2.zero;
		}
	}

	private void Turn(int direction) {
		Quaternion rot = new Quaternion();
		currentRotation = (currentRotation + direction + 1) % (rotations.Length - 1);
		Debug.Log(currentRotation);
		rot.eulerAngles = new Vector3(0, rotations[currentRotation], 0);
		transform.rotation = rot;
	}
}