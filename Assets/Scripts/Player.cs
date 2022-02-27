using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10F;
    [SerializeField] private float speeding = 0.145F;
    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform bombSpawnPoint;
    private Vector2 direction;
    public Animator animator;
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public Joystick joystick;

    void Update()
    {
        MotionPlayer();
        CheckBomb();
    }

    private void MotionPlayer()
    {
        float horizontalMove = joystick.Horizontal;
        float verticalMove = joystick.Vertical;
        
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.D) || horizontalMove > 0)
        {
            direction = Vector2.right;
            spriteRenderer.flipX = false;
            
            if (Input.GetKey(KeyCode.S) || verticalMove < 0)
            {
                direction = Vector2.down + (Vector2.left * speeding);
                animator.SetTrigger("GoingDown");
            }
            else
                animator.SetTrigger("StoppingDown");
        }
        else if (Input.GetKey(KeyCode.A) || horizontalMove < 0)
        {
            direction = Vector2.left;
            spriteRenderer.flipX = true;
            
            if (Input.GetKey(KeyCode.W) || verticalMove > 0)
            { 
                direction = Vector2.up + (Vector2.right * speeding);
                animator.SetTrigger("GoingUp");
            }
            else
                animator.SetTrigger("StoppingUp");
        }
        
        direction *= speed;
        rigidBody.velocity = direction;
        
    }

    void CheckBomb()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(bomb, bombSpawnPoint.position, Quaternion.identity);
        }
    }
    
}
