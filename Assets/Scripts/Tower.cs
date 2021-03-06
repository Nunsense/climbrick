﻿using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public GameObject[] floorPrefavs;

	public Player player;

	public int visibleFloors;
	public float floorH;
	public float halfFloorH;

	private GameObject[] floors;

	private int currentFloor;
	private CameraController cam;

	void Awake() {
		halfFloorH = floorH / 2;
		cam = FindObjectOfType<CameraController>();
	}

	void Start() {
		currentFloor = -1;

		floors = new GameObject[visibleFloors];
		for (int i = 0; i < visibleFloors; i++) {
			GameObject floor = GameObject.Instantiate(floorPrefavs[Random.Range(0, floorPrefavs.Length)]);
			floors[i] = floor;
			floor.transform.parent = transform;
			floor.transform.localPosition = new Vector3(0, i * floorH, 0);
		}
	}

	void Update() {
	}

	public void JumpToStep(Transform trans) {
		if (Vector3.Distance(player.gameObject.transform.position, trans.position) < 10) {
			player.JumpTo(trans.position);
		}		
	}

	public void NextFloor() {
		currentFloor++;
		cam.MoveY(floorH * currentFloor);

		floors[fixIndex(currentFloor - 2)].transform.localPosition = new Vector3(0, fixIndex(currentFloor + 3) * floorH, 0);
	}

	private int fixIndex(int i) {
	Debug.Log(i);
		if (i < 0) i = floors.Length - i;
		if (i > floors.Length - 1) i = i - (floors.Length - 1);
		Debug.Log(i);
		return i;
	}
}
