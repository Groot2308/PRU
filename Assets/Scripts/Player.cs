using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    public Animator animator;

    public Vector3 moveInput;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        animator.SetFloat("speed", moveInput.sqrMagnitude);

        if (moveInput.x != 0)
        {
            if (moveInput.x < 0)
                transform.localScale = new Vector3((float)-0.4181544, (float)0.372213, 0);
            else
                transform.localScale = new Vector3((float)0.4181544, (float)0.372213, 0);
        }

    }
}
