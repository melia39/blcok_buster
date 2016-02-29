using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted){
			// Lock the ball to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			// Wait for left mouse and launch ball
			if (Input.GetMouseButtonDown(0)){
				Debug.Log("Left Mouse Clicked");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
	}
	
	void OnCollisionExit2D (Collision2D collision) {
		
		// tweak is adding to velocity to help prevent boring loops
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		// Ball does not trigger sound when brick is destroyed
		// No idea why - possibly becuase the bick isn't there???
		if (hasStarted){
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
