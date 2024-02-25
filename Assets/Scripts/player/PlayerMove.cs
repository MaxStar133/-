using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   [SerializeField] private float speed;

   private Rigidbody2D rg;
   private Vector2 moveInput;

   private void Start()
   {
     rg = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
    moveInput.x = Input.GetAxisRaw("Horizontal");
    moveInput.y = Input.GetAxisRaw("Vertical");

   }
    private void FixedUpdate()
    {
        rg.MovePosition(rg.position + moveInput * speed * Time.fixedDeltaTime);
    }
}