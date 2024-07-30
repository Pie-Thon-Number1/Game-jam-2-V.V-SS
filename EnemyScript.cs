using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public float attackDistance = 80f;
    public float attackStopDistance = 200f;
    public float playerDistance = 6f;
    bool attacking = false;
    public GameObject player;
    public float timeBetweenAttacks;
    public float attackDamage;
    public float maxHealth;
    float currHealth;
    public Image healthBar;
    bool alive = true;
    public AudioSource deadSound;


    bool canAttack = true;

    public GameObject head;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
            //rotates to player
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));

            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= attackDistance) { if (distance >= playerDistance) agent.SetDestination(target.position); }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (alive)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Y");

                if (canAttack)
                {
                    player.GetComponent<PlayerLife>().onAttack(attackDamage);
                    canAttack = false;
                    Invoke("resetAttack", timeBetweenAttacks);
                }
            }
        }
     }

    private void resetAttack() { canAttack = true; }

    public void isAttacked(float damageDealt)
    {
        currHealth-=damageDealt;
        healthBar.fillAmount = currHealth / maxHealth;

        if (currHealth <= 0)
        {
            if(alive) deadSound.Play();
            alive = false;
            agent.enabled = false;
            head.GetComponent<LookAt>().canActivate = false;            
            this.enabled = false;            
        }

    }

    
    
        
}
