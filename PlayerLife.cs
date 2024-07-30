using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public float PlayerHealth;
    public Text HealthText;

    public ParticleSystem bloodEffect;

    public AudioSource hitSound;

    float currHealth;

    public Image healthBar;

    public GameObject deathUI;
    public GameObject gunHolder;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = PlayerHealth;
        healthBar.fillAmount = currHealth / PlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onAttack(float damageDone)
    {
        if(hitSound.isPlaying) hitSound.Stop();
        hitSound.Play();
        Debug.Log("U R Attacked!");
        currHealth -= damageDone;
        healthBar.fillAmount = currHealth / PlayerHealth;

        if (currHealth <= 0 ) Die();
        else {
            if (bloodEffect.isPlaying) bloodEffect.Stop();
            bloodEffect.Play();
        }
    }

    private void Die()
    {
        deathUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        gunHolder.SetActive(false);
        gameObject.SetActive(false);
        
    }
}
