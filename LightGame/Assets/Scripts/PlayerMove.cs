using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   
    public float speed = 5f;
    
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
       
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(HL2D.Range);
        Vector2 MoveVec = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        MoveVec*=speed*Time.deltaTime;

       
        //if(Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        //{
        //
        //
        //    MoveVec /= Mathf.Sqrt(2);
        //}
        rb.MovePosition(rb.position + MoveVec);
       
       
    }
}
