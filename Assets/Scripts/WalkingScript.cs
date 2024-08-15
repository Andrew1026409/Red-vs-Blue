//   WHEN YOU BE WALKING
//           
//   UUUUUUUUUUUHHHHHHHH

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingScript : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float speed;
    [SerializeField] private Vector3 cameraOffset;

    [Header("Object References")]
    [SerializeField] private Camera mainCamera;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = Vector2.zero;
        }

        mainCamera.transform.position = transform.position + cameraOffset;
    }
}
