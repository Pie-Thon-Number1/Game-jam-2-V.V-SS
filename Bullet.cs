using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool delete;
    public float deathTime;
    public float attackEndTime;
    // Start is called before the first frame update
    float startTime;
    bool canAttack = true;
    public float damage;

    void Start()
    {
        startTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        if(delete)
        {
            if(Time.time - startTime >= deathTime) Destroy(gameObject);
        }
        if (Time.time - attackEndTime >= startTime) canAttack = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (canAttack)
            {
                collision.gameObject.GetComponent<EnemyScript>().isAttacked(damage);
                canAttack = false;
                // I dont know yet
                Debug.Log("Enemy Is Attacked");
            }
        }
    }
}
