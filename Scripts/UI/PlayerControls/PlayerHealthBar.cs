using Characters.Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI.PlayerControls
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBarImage;
        public float maxHealth = 100f;
        private float currentHealth;

        [SerializeField] private PlayerController _playerController;

        void Start()
        {
            currentHealth = maxHealth;
            UpdateHealthBar();
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                _playerController.isPlayerDead = true;
            }
            UpdateHealthBar();
        }

        public void Heal(float healAmount)
        {
            currentHealth += healAmount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            UpdateHealthBar();
        }

        void UpdateHealthBar()
        {
            healthBarImage.fillAmount = currentHealth / maxHealth;
        }
    }
}