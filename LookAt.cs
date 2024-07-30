using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class LookAt : MonoBehaviour
{
    public Transform target;
    public bool canActivate = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //rotates to player
        if(canActivate) transform.LookAt(target.position);


    }

}
