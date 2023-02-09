using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public Rigidbody playerRB;

    public float speed;
    public float speedMultiplier;
    public float smoothing = 0.9f;

    Vector3 moveDirection;

    public float tempPlayerx;
    public float tempPlayerz;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float y = playerRB.velocity.y;

        moveDirection = transform.forward * vertical + transform.right * horizontal;

        playerRB.AddForce(moveDirection.normalized * speed * speedMultiplier * Time.deltaTime, ForceMode.Impulse);

        if (Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0f)
        {
            tempPlayerx = playerRB.velocity.x;
            tempPlayerz = playerRB.velocity.z;
            playerRB.velocity = Vector3.zero;
            playerRB.angularVelocity = Vector3.zero;

            playerRB.velocity = new Vector3(tempPlayerx, playerRB.velocity.y, tempPlayerz);

            playerRB.velocity = playerRB.velocity * smoothing;
        }

        if (playerRB.velocity.magnitude > speed)
        {
            playerRB.velocity = playerRB.velocity.normalized * speed;
        }

        playerRB.velocity = new Vector3(playerRB.velocity.x, y, playerRB.velocity.z);
    }
}
