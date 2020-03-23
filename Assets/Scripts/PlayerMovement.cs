using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed;
    public float moveSpeed;
    
    private Animator mAnimator=>GetComponent<Animator>();
    private Rigidbody mRigidBody => GetComponent<Rigidbody>();

    private Vector3 moveVector = Vector3.zero;
    private Quaternion rotateQuaternion = Quaternion.identity;



    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        moveVector.Set(horizontal, 0f, vertical);
        moveVector.Normalize();

        bool existInput = !Mathf.Approximately(vertical, 0f) || !Mathf.Approximately(horizontal, 0f);
        mAnimator.SetBool("IsWalking", existInput);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, moveVector, turnSpeed * Time.deltaTime, 0f);
        rotateQuaternion = Quaternion.LookRotation(desiredForward);

    }

    private void OnAnimatorMove() {
        mRigidBody.MovePosition(mRigidBody.position + moveVector * mAnimator.deltaPosition.magnitude*moveSpeed);
        mRigidBody.MoveRotation(rotateQuaternion);
    }
}
