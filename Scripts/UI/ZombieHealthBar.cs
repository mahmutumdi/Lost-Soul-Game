using System.Collections;
using Characters.Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ZombieHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider healthBarSlider;
        [SerializeField] private float maxHealth = 100f;
        private float currentHealth;

        [SerializeField] private ZombieController zombieController;

        private bool canTakeDamage = true;

        private void Start()
        {
            currentHealth = maxHealth;
            UpdateHealthBar();
        }

        public void TakeDamage(float damage)
        {
            if (!canTakeDamage || zombieController.isZombieDead)
                return;

            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                zombieController.Die();
                healthBarSlider.gameObject.SetActive(false);
            }
            UpdateHealthBar();
            
            // if (healthBarSlider.gameObject.activeInHierarchy)
            // {
            //     StartCoroutine(DamageCooldown());
            // }
            
            if (healthBarSlider.isActiveAndEnabled)
            {
                StartCoroutine(DamageCooldown());
            }
            
        }

        private void UpdateHealthBar()
        {
            healthBarSlider.value = currentHealth / maxHealth;
        }

        private IEnumerator DamageCooldown()
        {
            canTakeDamage = false;
            yield return new WaitForSeconds(0.1f);
            canTakeDamage = true;
        } 
    }
}