using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 pos;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log((pos - transform.position).sqrMagnitude*100000);
        Vector3 MoveVec = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        MoveVec*=speed*Time.deltaTime;

       
        if(Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {

 
            MoveVec /= Mathf.Sqrt(2);
        }
        transform.Translate(MoveVec);
        pos = transform.position;
    }
}
