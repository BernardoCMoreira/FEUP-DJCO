using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
	bool moveUp;
	float initialPos;
	
	[SerializeField] float distance = 4f;
 	[SerializeField] float moveSpeed = 2f;

	void Start(){
		initialPos = transform.position.y;
		moveUp = true;
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
