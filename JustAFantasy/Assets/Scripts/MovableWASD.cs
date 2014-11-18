﻿using UnityEngine;
using System.Collections;

public class MovableWASD : MonoBehaviour {

	public float speed = 1f;
	public float maxSpeed = 1f;
	public float jumpHeight = 5f;
	private Rigidbody2D rb;
	private bool inAir = false;
	private bool canJump = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> () as Rigidbody2D;
	}

	bool isForward(){
		return Input.GetKey (KeyCode.D);
		}

	bool isBackward(){
		return Input.GetKey (KeyCode.A);
	}

	bool isJump(){
		return Input.GetKey (KeyCode.W) || Input.GetKey(KeyCode.Space);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag.Equals ("floor")) {
						inAir = false;
				}
		}

	void OnCollisionExit2D(Collision2D other){
		inAir = true;
	}

	void OnTriggerStay2D(Collider2D other){
		canJump = true;

		}

	void OnTriggerExit2D(Collider2D other){
		canJump = false;
	}

	void capSpeed(){
		if (rb.velocity.x > maxSpeed)
						rb.velocity = new Vector2 (maxSpeed, rb.velocity.y);
		if (rb.velocity.x < -maxSpeed)
						rb.velocity = new Vector2 (-maxSpeed, rb.velocity.y);
		}
	
	// Update is called once per frame
	void Update () {
		if (isForward () && !inAir) {
			rb.AddForce (transform.right * speed, ForceMode2D.Impulse);
				}
		if (isBackward () && !inAir) {
			rb.AddForce (transform.right * (-speed), ForceMode2D.Impulse);
				}
		if (isJump () && canJump) {
			rb.AddForce (transform.up * jumpHeight, ForceMode2D.Impulse);
		}
		capSpeed ();
	}
}