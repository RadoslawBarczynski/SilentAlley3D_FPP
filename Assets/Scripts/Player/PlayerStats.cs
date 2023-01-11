using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    //public int currentHealth { get; private set; }
    public int currentHealth = 60;

    public HealthBar healthBar;

    private void Awake()
    {
        //currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log(transform.name + "takes " + damage + " damage.");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void GetHealed(int health)
    {
        currentHealth += health;
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    public virtual void Die()
    {
        //die in some way
        Debug.Log("Died");
    }
}
