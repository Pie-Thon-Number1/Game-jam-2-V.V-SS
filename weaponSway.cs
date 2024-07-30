using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSway : MonoBehaviour
{
    public float swayMultiplier;
    public float smoothMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * swayMultiplier;
        float y = Input.GetAxis("Mouse Y") * swayMultiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-y, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(x, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoothMultiplier * Time.deltaTime);
    }
}
