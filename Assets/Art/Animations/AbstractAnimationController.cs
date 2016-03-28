﻿using UnityEngine;
using System.Collections;

public abstract class AbstractAnimationController : MonoBehaviour {
	public static AbstractAnimationController instance;

	protected Transform mytrans;
	protected Animator myAnim;

	//Used to flip the character depending on its position
	protected Vector3 artScaleCache;

	// Use this for initialization
	void Start() {
		mytrans = this.transform;
		artScaleCache = mytrans.localScale;
	}

	//// Update is called once per frame
	//void Update () {

	//}
	public void FlipArt(float currentSpeed) {
		if ((currentSpeed < 0 && artScaleCache.x == 1) || //Going left and facing right
			(currentSpeed > 0 && artScaleCache.x == -1))  //Going right and facing left
		{
			artScaleCache.x *= -1;
			mytrans.localScale = artScaleCache;

		}
	}

	public void UpdateSpeed(float currentSpeed) {
		myAnim.SetFloat("speed", currentSpeed);
		FlipArt(currentSpeed);
	}

	public void UpdateIsGrounded(bool isGrounded) {
		myAnim.SetBool("isGrounded", isGrounded);
	}

	public void UpdateIsAttacking(bool isAttacking) {
		myAnim.SetBool("isAttacking", isAttacking);
	}
}