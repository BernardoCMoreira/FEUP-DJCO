using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
	

	float dirY, moveSpeed = 2f;
	bool moveUp = true;

	private float initialPos;

	
	/* Public vars */
	public float distance;

	void Start(){
		initialPos = transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y > initialPos+distance)
			moveUp = false;
		if (transform.position.y < initialPos)
			moveUp = true;

		if (moveUp)
			transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
		else
			transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
	}
}
