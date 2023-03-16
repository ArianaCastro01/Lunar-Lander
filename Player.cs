using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject thruster; // thruster object

    public Slider FuelSlider; // Slider object

    Vector2 dest = Vector2.zero; // references X and Y positions

    Rigidbody2D playerRB; // Rigidbody variable
    public float speed = 10; //sets landing speed limit

    public float MaxFuel = 10; // sets fuel limit

    public float CurrentFuel; // Shows current fuel as it reduces

    public Vector2 thrust;
    public AreaCollision areaCollide; // Class reference to AreaCollision script

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        CurrentFuel = MaxFuel;
    }
    void Update() // Player movement
    {
        Vector2 dir = dest - (Vector2)transform.position; // object position

        if (Input.GetKey(KeyCode.D))
        {
            playerRB.AddTorque(-thrust.x, ForceMode2D.Impulse); // Rotate Right
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerRB.AddTorque(thrust.x, ForceMode2D.Impulse); // Rotate left
        }
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W) && CurrentFuel > 0)
        {
            thruster.SetActive(true); //gives player visual input thruster is active
            playerRB.AddForce(transform.up * thrust.y, ForceMode2D.Impulse); // Slows landing
            CurrentFuel = CurrentFuel - Time.deltaTime; // Takes away 1 fuel per second
            FuelSlider.value = CurrentFuel / MaxFuel; // updates slider visual
        }
        else if (!Input.GetKeyDown(KeyCode.W))
        {
            thruster.SetActive(false); // gives player visual input thruster is inactive
        }
    }

    private void OnCollisionEnter2D(Collision2D collide) //Collision tracker for the entire area
    {
        if(collide.collider.tag == "Area") //Compare's tag to check if player landed incorrectly
        {
            areaCollide.GameOver(); // references  and activates Game Over function in AreaCollision script
        }

        if(collide.collider.tag == "Win") // Compare's tag to check if the player landed correctly
        {
            if(collide.relativeVelocity.sqrMagnitude > speed * speed)
            {
                areaCollide.Crash(); // references and activates Crash function in AreaCollision script
            }
            else
            {
                areaCollide.Win(); // references and activates Win function in AreaCollision script
            }
        }
    }
}
