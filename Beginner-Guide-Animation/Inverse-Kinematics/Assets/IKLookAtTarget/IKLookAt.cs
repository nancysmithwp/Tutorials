using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKLookAt : MonoBehaviour {
	Animator anim;
	public Transform target;
	public float weight = 1f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void OnAnimatorIK(int layerIndex)
	{
		anim.SetLookAtPosition (target.position);
		anim.SetLookAtWeight (weight);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
