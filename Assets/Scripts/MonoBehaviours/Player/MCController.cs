using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCController : MonoBehaviour
{
    public float speed = 10.0f;
    Vector2 lookDirection = new Vector2(1, 0);
    
    Rigidbody2D rigidbody2d;
    Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x,0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x,move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = rigidbody2d.position;
        position = position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log(lookDirection);
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position, lookDirection, 1f, LayerMask.GetMask("Interactable"));
            if (hit.transform != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    Debug.Log("Found interactable");
                    interactable.OnFocused(transform);
                }
            }
        }
    }
}
