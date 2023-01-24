using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    float hInput;
    float vInput;
    Rigidbody2D playerRigidbody;
    [SerializeField] Transform groundDetectPosition;
    [SerializeField] LayerMask groundDetectLayerMask;
    [SerializeField] float maxSpeed = 10.0f;
    [SerializeField] float jumpForce;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        GetInput();
        Jump();
    }
    private void GetInput() {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
    }
    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && CheckGround())
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0);
            playerRigidbody.velocity += Vector2.up * jumpForce;
            SoundManager.instance.playJumpSound();
        }
        if (playerRigidbody.velocity.y < 0)
        {
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (playerRigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        //playerRigidbody.velocity = new Vector2(hInput * playerSpeed, playerRigidbody.velocity.y);
        Vector2 dir = new Vector2(hInput, vInput);
        playerRigidbody.velocity = (new Vector2(dir.x * maxSpeed, playerRigidbody.velocity.y));
    }
    private bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundDetectPosition.position, 0.3f, groundDetectLayerMask);
    }
}
