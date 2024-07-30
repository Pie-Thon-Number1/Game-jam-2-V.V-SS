using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class WeaponSwitch : MonoBehaviour
{
    public int selectedWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        selectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0) 
        {
            if(selectedWeapon < transform.childCount - 1) selectedWeapon++;
            else selectedWeapon = 0;
            selectWeapon();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedWeapon > 0) selectedWeapon--;
            else selectedWeapon = transform.childCount - 1;
            selectWeapon();
        }
        
    }

    void selectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true); 
            }
            else {
                if (weapon.gameObject.activeSelf) {
                    weapon.gameObject.GetComponent<projectileGun>().allowInvoke = false;
                    if (weapon.gameObject.GetComponent<projectileGun>().gunshotSound.isPlaying) { 
                        weapon.gameObject.GetComponent<projectileGun>().gunshotSound.Stop(); 
                    }

                    if (weapon.gameObject.GetComponent<projectileGun>().reloadSound.isPlaying)
                    {
                        weapon.gameObject.GetComponent<projectileGun>().reloadSound.Stop();
                    }
                }
                weapon.gameObject.SetActive(false);               
            }

            i++;
        }
    }
}
