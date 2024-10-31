using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    int currentHealth;
    public int maxHealth;
    public bool biteActive = true;
    
    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        GameObject player = GameObject.Find("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        currentHealth -= amount;

        if(currentHealth <= 0)
        { 
            playerController.kills += 1;
            playerController.UILoad();
            Invoke("Death", 0.1f); 
        }
    }
    void Update()
    {

        GameObject player = GameObject.Find("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        
        if (Vector3.Distance(transform.position, player.transform.position) <= 2 && biteActive)
        {
            biteActive = false;
            playerController.health -= 1;
            playerController.damageOverlay.SetActive(true);
            playerController.UILoad();
            playerController.Overlay();
            Invoke("BiteRenew", 3f);
        }
        transform.LookAt(new Vector3(player.transform.position.x, 1, player.transform.position.z));
        transform.position += transform.forward * 1f * Time.deltaTime;
    }

    void BiteRenew()
    {
        biteActive = true;
    }

    void Death()
    {
        // Death function
        // TEMPORARY: Destroy Object
        Destroy(gameObject);
    }
}
