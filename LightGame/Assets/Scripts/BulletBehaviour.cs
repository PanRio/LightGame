using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("DARK alive!");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string colTag = col.gameObject.tag;
        switch (colTag)
            {
            case "Enemy":
                EnemyHit();
                break;
            case "Wall":
                WallHit();
                break;
            case "Absorb":
                AbsorbWallHit();
                break;
            default:
                WallHit();
                    break;
        }
        

        Debug.Log("OnCollisionEnter2D");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void EnemyHit()
    {
        Debug.Log("Enemy HIT!");
        Destroy(gameObject);
    }

    void WallHit()
    {
        Debug.Log("Wall HIT!");
    }

    void AbsorbWallHit()
    {
        Debug.Log("Absorb Wall HIT!");
        Destroy(gameObject);
    }
}
