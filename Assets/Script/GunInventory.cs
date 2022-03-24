using UnityEngine;

public class GunInventory : MonoBehaviour
{
    private int weaponSwitch = 0;

    private void Start()
    {
        Selectweapon();
    }
    private void Update()
    {
        int currentSwitch = weaponSwitch;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            weaponSwitch = weaponSwitch >= (transform.childCount - 1) ?  0 : weaponSwitch+1;
        
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            weaponSwitch = weaponSwitch <= 0? (transform.childCount - 1) : weaponSwitch-1;
        }
        if(currentSwitch != weaponSwitch)
        {
            Selectweapon();
        }
    }

    private void Selectweapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if( i == weaponSwitch)
            {
                weapon.gameObject.SetActive(true);   
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
