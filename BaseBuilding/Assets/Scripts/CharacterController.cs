using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed;
    private float finalMoveSpeed;

    Rigidbody2D rb2d;

    private Vector2 moveInput;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (Mathf.Abs(moveInput.x) > 0.5f && Mathf.Abs(moveInput.y) > 0.5f)
            finalMoveSpeed = moveSpeed * 0.75f;
        else
            finalMoveSpeed = moveSpeed;

        rb2d.velocity = new Vector2(moveInput.x * finalMoveSpeed, moveInput.y * finalMoveSpeed);
    }
}
