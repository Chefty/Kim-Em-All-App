using UnityEngine;
using System.Collections;

public class ThirdPersonMove : MonoBehaviour {


    public float RunSpeed = 9;

    // public float JumpSpeed = 9;
    public float TurnSpeed = 25f;
    public float Gravity = 20;
    public float ThumbStickDeadZone = 0.1f;

    // [HideInInspector]
    public float Speed = 0;

    [HideInInspector]
    public Vector3 MoveDirection = Vector3.zero;

    [HideInInspector]
    public Transform Transform;

    [HideInInspector]
    public CharacterController Controller;

    public float X = 0f;
    public float Y = 0f;

    public virtual void Awake()
    {
        Controller = GetComponent<CharacterController>();
        Transform = transform;
    }

    public virtual void Update()
    {
        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");
    }

    public virtual void FixedUpdate()
    {
        Move(X, Y);
    }

    public void SetSpeed(float rs, float ts)
    {
        RunSpeed = rs;
        TurnSpeed = ts;
    }

    public void Move(float h, float v)
    {
        Speed = 0;
        MoveDirection.y -= Gravity * Time.deltaTime;
        if (Mathf.Abs(v) > ThumbStickDeadZone || (Mathf.Abs(h) > ThumbStickDeadZone))
        {
            var lookRotation = new Vector3();
            lookRotation.Set(h, 0, v);
            lookRotation = lookRotation.normalized;

            var rotation = Quaternion.LookRotation(lookRotation, Vector3.up);
            if (lookRotation.magnitude > ThumbStickDeadZone)
            {
                Speed = RunSpeed;
                transform.rotation = Quaternion.Slerp(Transform.rotation, rotation, Time.deltaTime * TurnSpeed);
            }
        }
        if (Controller.isGrounded)
        {
            MoveDirection = Transform.TransformDirection(Vector3.forward).normalized;
            MoveDirection *= Speed * Time.deltaTime;
            //if (Input.GetButton("Fire1"))
            //      MovementProperties.MoveDirection.y = JumpSpeed;
        }
        Controller.Move(MoveDirection);
    }
}
