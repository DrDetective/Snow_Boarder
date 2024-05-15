using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float Torque = 1f;
    [SerializeField] float BoostSpeed = 25f;
    [SerializeField] float Speed = 20f;
    Rigidbody2D RB2D;
    SurfaceEffector2D surfaceEFF2D;
    bool canMove = true;

    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        surfaceEFF2D = FindAnyObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Rotate();
            Boost();
        }
        //else { NotMove(); }
    }
    public void NotMove()
    {
        canMove = false;
    }
    void Boost()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            surfaceEFF2D.speed = BoostSpeed;
        }
        else { surfaceEFF2D.speed = Speed; }

    }
    void Rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            RB2D.AddTorque(Torque);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            RB2D.AddTorque(-Torque);
        }
    }
}
