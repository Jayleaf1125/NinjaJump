using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
        // Movement variables
        public float jumpForce = 10f; // Vertical jump force
        public float wallDistance = 2f; // Horizontal distance to walls
        public float gravityScale = 2f; // Gravity multiplier
        public LayerMask wallLayer; // Layer for the walls

        private Rigidbody2D rb;
        private bool isOnLeftWall = true; // Tracks the current wall
        private bool canSwitch = true; // Cooldown to prevent spamming jumps

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = gravityScale;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && canSwitch)
            {
                SwitchWall();
            }

            // Ensure the character continues to ascend
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, jumpForce));
        }

        private void SwitchWall()
        {
            // Toggle wall side
            isOnLeftWall = !isOnLeftWall;

            // Determine the new horizontal position
            float newX = isOnLeftWall ? -wallDistance : wallDistance;

            // Apply new position
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            // Add vertical jump force
            rb.velocity = new Vector2(0, jumpForce);

            StartCoroutine(SwitchWallCooldown());
        }

        private IEnumerator SwitchWallCooldown()
        {
            canSwitch = false;
            yield return new WaitForSeconds(0.2f); // Cooldown duration 
            canSwitch = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Check if the player has hit a wall
            if (wallLayer == (wallLayer | (1 << collision.gameObject.layer)))
            {
                rb.velocity = new Vector2(0, jumpForce); // Keep moving upward
            }
        }
    }

