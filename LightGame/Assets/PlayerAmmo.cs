using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public int maxAmmo = 4;
    public int currentAmmo;

    public AmmoBar ammoBar;


    void Start()
    {
        currentAmmo = 2;
        ammoBar.SetMaxAmmo(maxAmmo);
        ammoBar.SetAmmo(currentAmmo);
    }

    /*void Update()
    {
        if (wystrzal bialy - trafi w przeciwnika/kolumne czarna)
        {
            GetsDarker();
        }
         if (wystrzal czarny - trafi w przeciwnika/kolumne biala)
        {
            GetsLighter();
        }

    }

    void GetsDarker()
    {
        currentAmmo -= 1;
        ammoBar.SetAmmo(currentAmmo);
    }


     void GetsLighter()
    {
        currentAmmo += 1;
        ammoBar.SetAmmo(currentAmmo);
    }
    */
}
