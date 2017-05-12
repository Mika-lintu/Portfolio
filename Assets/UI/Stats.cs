using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {
    public int startHealth;
    public int health;
    int startDamage;
    public int damage;

    HealthUI hUI;
	void Start () {
        
        startHealth = health;
        startDamage = damage;
        hUI = GameObject.FindGameObjectWithTag("BattleUI").GetComponent<HealthUI>();
        
    }


    void Update () {
        int damageToMake = Random.Range(0, 20);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Debug.Log(hit.transform.name);
            if(hit.transform.name == "Cube")
            {
                TakeDamage(damageToMake);                
            }
        }
    }
    public void TakeDamage(int dmg)
    {
        Debug.Log(dmg);
        health -= damage;
        health = Mathf.Clamp(health, 0, startHealth);
        hUI.MinusHealth(dmg);
        
        if (health <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        gameObject.SetActive(false);
        hUI.DisableHealthBar();
        //bUI.DisableUI();
    }
}
