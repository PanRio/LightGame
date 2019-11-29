using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimShootMethods : MonoBehaviour
{
    
    public HardLight2D HL2D;
    public float offset;
    private Rigidbody2D parentR;
    float angle;
    float lightRange;

    public float shootForce = 10f;

    public GameObject BulletLight;
    public GameObject BulletDark;

    public UnityEngine.Experimental.Rendering.LWRP.Light2D light2D;

    float R2, L2;
    bool R2Clicked = false, L2Clicked = false;

    Vector3 RStick;

    // Start is called before the first frame update

    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }

    void Start()
    {
        
        parentR = transform.parent.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        R2 = Input.GetAxisRaw("R2");
        L2 = Input.GetAxisRaw("L2");
        if(!R2Clicked && R2>=0.5f)
        {
            R2Clicked = true;
            FireLight();
        }
        if (!L2Clicked && L2 >= 0.5f)
        {
            L2Clicked = true;
            FireDark();
        }

        if (R2 < 0.5f) R2Clicked = false;
        if (L2 < 0.5f) L2Clicked = false;

        transform.localPosition.Set(0, offset, 0);   
        RStick = new Vector3(Input.GetAxisRaw("RStickH"), Input.GetAxisRaw("RStickV"),0);

        if(RStick != Vector3.zero)
        {
            angle = Vector3.Angle(Vector3.up, RStick);
            if (RStick.x > 0)
            {
                angle = 360.0f - angle;
            }
        }

        parentR.SetRotation(angle);
        transform.Translate(new Vector3(0, offset, 0) - transform.localPosition, parentR.transform);
        
    }


    void FireLight()
    {
        if (HL2D.Range <= 1)
        {
            Debug.Log("CANT FIRE LIGHT!");
        }
        else
        {
            Debug.Log("FireLight");
            GameObject bullet = Instantiate(BulletLight,transform.position,new Quaternion(0,0,0,0));

            bullet.GetComponent<Rigidbody2D>().AddForce(DegreeToVector2(angle+90).normalized * shootForce, ForceMode2D.Impulse);

            HL2D.Range--;
            light2D.pointLightInnerRadius-= 0.5f;
            light2D.pointLightOuterRadius--;
        }
    }
    
    void FireDark()
    {
        if (HL2D.Range >= 5)
        {
            Debug.Log("CANT FIRE DARK!");
        }
        else
        {
            Debug.Log("FireDark");

            GameObject bullet = Instantiate(BulletDark,transform.position,new Quaternion(0,0,0,0));

            Vector3 bulletVec = parentR.transform.forward;

            bullet.GetComponent<Rigidbody2D>().AddForce( DegreeToVector2(angle+90).normalized * shootForce, ForceMode2D.Impulse);
            

            HL2D.Range++;
            light2D.pointLightInnerRadius+= 0.5f;
            light2D.pointLightOuterRadius++;
        }
    }
    
}
