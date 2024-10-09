using UI.PlayerControls;
using Unity.VisualScripting;
using UnityEngine;
using Utilities;
using System.Collections;

namespace Developer
{
    public class TestDamageVolume : MonoBehaviour
    {
        [SerializeField] private PlayerHealthBar _playerHealthBar;
        [SerializeField] private float damagePerSecond = 1f;

        private Coroutine damageCoroutine;

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Collision Enter!");
                //_playerHealthBar.TakeDamage(10);
                if (damageCoroutine == null)
                {
                    damageCoroutine = StartCoroutine(DamageOverTime(collision.gameObject));
                }
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Collision Exit!");
                if (damageCoroutine != null)
                {
                    StopCoroutine(damageCoroutine);
                    damageCoroutine = null;
                }
            }
        }

        private IEnumerator DamageOverTime(GameObject player)
        {
            while (true)
            {
                _playerHealthBar.TakeDamage(damagePerSecond);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}