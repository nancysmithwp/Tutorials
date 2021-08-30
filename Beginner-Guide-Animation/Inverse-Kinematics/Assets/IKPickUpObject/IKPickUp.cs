using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKPickUp : MonoBehaviour {
	public Transform target;
	Animator anim;
	float weight = 1f;
	public Transform hand;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void OnAnimatorIK(int layerIndex){
		// we only want the hand going toward the burger during the actual animation of picking it 
		// up, so we set "IkPickup" parameter in the inspector for the lifting animation for curves.
		// The curve is set to 1 at the point where the hand grabs the burger on the floor.
		weight = anim.GetFloat ("IkPickup"); 
		if (weight > 0.95) {
			target.parent = hand;  // stick the burger to the hand
			target.localPosition = new Vector3(0f, 0.107f, 0.14f); // position burger in hand, or it'll be floating some distance from hand. 
			target.localRotation = Quaternion.Euler (331f, 0, 0);  // get these values by moving burger around during animation so it's in the hand.
					// Euler function converts x,y,z values into rotation values 
		}
		anim.SetIKPosition (AvatarIKGoal.RightHand, target.position);
		anim.SetIKPositionWeight (AvatarIKGoal.RightHand, weight);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetTrigger ("pickup");
		}
	}
}
