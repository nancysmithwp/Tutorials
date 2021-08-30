using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKPuppet : MonoBehaviour
{
    public Transform target;
    Animator anim;
    public float weight = 1f; // 0-1

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            target.transform.Translate(0f, 0.1f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            target.transform.Translate(0f, -0.1f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            target.transform.Translate(0.1f, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            target.transform.Translate(-0.1f, 0f, 0f);
        }

    }

    private void OnAnimatorIK(int layerIndex) // called if select ik in animator base layer
    {
        anim.SetIKPosition(AvatarIKGoal.RightHand, target.position);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
        // either hand or either food can follow a target with IK  

        anim.SetIKPosition(AvatarIKGoal.RightFoot, target.position);
        anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, weight);

    }


}


/*
 * 
 * IKDemo
 * 
 * Set a sphere as a target that you move with keys.  Hand or foot will follow target around.  Must set IK checkbox in animator base layer.
 * 
 */