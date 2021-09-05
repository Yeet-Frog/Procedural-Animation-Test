using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //public float Speed = 0;
    public int leggCount = 0;
    public Rigidbody2D rb2d;
    public int fallSpeed = 20;
    void Start()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        leggCount = GameObject.FindGameObjectsWithTag("Legg").Length;
        //rb2d.velocity = new Vector2(0.0f, 0.0f);
        
        
        if (leggCount == 0)
        {
            rb2d.gravityScale = fallSpeed;
        }
        else
        {
            rb2d.gravityScale = 0;
        }
        float x = Input.GetAxis("Horizontal");

        float y = Input.GetAxis("Vertical");

        Move(new Vector2(x, y));
    }

    private void Move(Vector2 direction)
    {
        if(direction == Vector2.zero)
        {
            return;
        }
         
        //Debug.Log(direction);

        Vector3 MoveAmount = new Vector3(direction.x, direction.y, 0) * Time.deltaTime * (leggCount + 1);

        transform.position += MoveAmount;
    }
    
}
