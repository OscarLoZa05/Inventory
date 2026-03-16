using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rBody2D;

    private float movementSpeed = 5;
    
    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        rBody2D.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rBody2D.linearVelocity.y);
    }
}
