//   WHEN YOU BE WALKING
//           
//   UUUUUUUUUUUHHHHHHHH

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingScript : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(2.0f, rb.velocity.y);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-2.0f, rb.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = Vector2.zero;
        }
    }
}
