using System.Collections;
using Characters.Player;
using Datas;
using UnityEngine;
using Pathfinding;
using UI;
using UI.PlayerControls;
using UI.PlayerControls.EquipAndInject;

public class ZombieController : MonoBehaviour
{
    [Header("Targeting")]
    [SerializeField] private Transform target;
    [SerializeField] private float activeDistance = 1f;

    [Header("Pathfinding")]
    [SerializeField] private float pathUpdateSeconds = 0.5f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float nextWaypointDistance = 1f;
    private Path path;
    private int currentWaypoint = 0;
    [SerializeField] private Seeker seeker;
    [SerializeField] private Rigidbody2D zombieRB;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    [Header("Health and Attack")]
    [SerializeField] private PlayerHealthBar playerHealthBar;
    [SerializeField] private ZombieHealthBar zombieHealthBar;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private PlayerController playerController;
    private bool isAttacking;
    private Coroutine attackCoroutine;

    [Header("Settings")]
    [SerializeField] private bool followEnabled = true;
    [SerializeField] private bool directionLookEnabled = true;

    public bool isZombieDead;
    [SerializeField] private EquipAndInjectPanelManager _equipAndInjectPanelManager;

    private void Start()
    {
        InvokeRepeating(nameof(UpdatePath), 0f, pathUpdateSeconds);
        
        
    }

    private void FixedUpdate()
    {
        if (isZombieDead)
        {
            return;
        }

        if (isAttacking)
        {
            animator.Play("Zombie Attack");
        }
        else if (TargetInDistance() && followEnabled)
        {
            PathFollow();
        }
        else
        {
            animator.Play("Zombie Idle");
        }
    }

    private void UpdatePath()
    {
        if (followEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(zombieRB.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        //((Vector2)path.vectorPath[currentWaypoint] - zombieRB.position).normalized
        Vector2 direction = SceneEpisode1Data.Instance.PlayerTransform.position - transform.position;
        Vector2 velocity = direction * speed;
        zombieRB.velocity = velocity;

        float distance = Vector2.Distance(zombieRB.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (velocity != Vector2.zero)
        {
            animator.Play("Zombie Run");
        }
        else
        {
            animator.Play("Zombie Idle");
        }

        if (directionLookEnabled)
        {
            FlipZombie(direction.x);
        }
    }

    private void FlipZombie(float directionX)
    {
        if (directionX > 0.5f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (directionX < -0.5f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.position) < activeDistance;
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isAttacking = true;
            if (attackCoroutine == null)
            {
                attackCoroutine = StartCoroutine(AttackPlayerRoutine());
            }
        }
        
        if (other.CompareTag("Bullet"))
        {
            if(_equipAndInjectPanelManager.weaponState == "Pistol")
                zombieHealthBar.TakeDamage(23); // Assume each bullet does 10 damage
            else if (_equipAndInjectPanelManager.weaponState == "Rifle")
                zombieHealthBar.TakeDamage(38);
            else
                zombieHealthBar.TakeDamage(100);
            Destroy(other.gameObject); // Destroy the bullet on collision
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isAttacking = false;
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
                attackCoroutine = null;
            }
        }
    }

    private IEnumerator AttackPlayerRoutine()
    {
        while (isAttacking)
        {
            animator.Play("Zombie Attack", -1, 0);

            if (playerController != null && !playerController.isPlayerDead)
            {
                playerController.Stumble();
                playerHealthBar.TakeDamage(10);
            }
            else
            {
                GameOver();
            }

            yield return new WaitForSeconds(1f);
        }
    }

    public void Die()
    {
        isZombieDead = true;
        followEnabled = false;
        path = null;
        isAttacking = false;
        zombieRB.velocity = Vector2.zero;
        animator.Play("Zombie Death");
        
        
        zombieRB.simulated = false;
    }

    private void GameOver()
    {
        followEnabled = false;
        path = null;
        isAttacking = false;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }
}
