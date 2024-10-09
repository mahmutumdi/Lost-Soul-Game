using System;
using System.Collections;
using Datas;
using Events;
using UI.PlayerControls;
using UI.PlayerControls.EquipAndInject;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D playerRB;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private EquipAndInjectPanelManager _equipAndInjectPanelManager;
        
        public float moveSpeed = 1f;
        private bool isLookingRight;
        private bool isMovingLeft;
        private bool isMovingRight;

        public float jumpForce = 1f;
        private bool isGrounded;
        
        public float bulletForce = 1f;
        private bool isFiring;

        public bool isPlayerDead;
        private bool hasPlayedDeathAnimation;
        
        private bool isStumbling;

        private void Awake()
        {
            _equipAndInjectPanelManager.weaponState = "Pistol";
            isPlayerDead = false;
            isFiring = false;
            isLookingRight = true;
            isMovingRight = false;
            isMovingLeft = false;
            isStumbling = false;
        }

        void Start()
        {
            SceneEpisode1Data.Instance.SetPlayerTrans(transform);
            SubscribeToEvents();
        }
        
        void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        private void SubscribeToEvents()
        {
            PlayerEvents.JumpBTNAction += Jump;
            PlayerEvents.ShootBTNAction += Shoot;
        }
        
        private void UnsubscribeFromEvents()
        {
            PlayerEvents.JumpBTNAction -= Jump;
            PlayerEvents.ShootBTNAction -= Shoot;
        }

        void Update()
        {
            if (!isPlayerDead)
            {
                float horizontalInput = Mathf.Abs(playerRB.velocity.x);
                
                if (horizontalInput > 0.1f && isGrounded && isFiring == false)
                {
                    PlayAnimations("Walk");
                }
                else if (horizontalInput < 0.1f && isGrounded && isFiring == false && !isStumbling)
                {
                    PlayAnimations("Idle");
                }
            
                SetPlayerVelocity();
            
                if (playerRB.velocity.x > 0 && !isLookingRight)
                {
                    Turnface();
                }
                else if (playerRB.velocity.x < 0 && isLookingRight)
                {
                    Turnface();
                }
            }
            else
            {
                if (!hasPlayedDeathAnimation)
                {
                    Debug.Log("dead");
                    PlayAnimations("Death");
                    hasPlayedDeathAnimation = true; // Set the flag to true to indicate the death animation has been played
                }
            }
        }

        

        #region Player Movement
        
        private void SetPlayerVelocity()
        {
            if (isMovingLeft)
            {
                playerRB.velocity = new Vector2(-moveSpeed, playerRB.velocity.y);
            }
            else if (isMovingRight)
            {
                playerRB.velocity = new Vector2(moveSpeed, playerRB.velocity.y);
            }
            else
            {
                playerRB.velocity = new Vector2(0, playerRB.velocity.y);
            }
        }

        public void StartMoveRight()
        {
            isMovingRight = true;
        }

        public void StartMoveLeft()
        {
            isMovingLeft = true;
        }

        public void StopMove()
        {
            isMovingLeft = false;
            isMovingRight = false;
        }
        
        public void Turnface()
        {
            isLookingRight = !isLookingRight;
            Vector3 playerTempLocalScale = transform.localScale;
            playerTempLocalScale.x *= -1;
            transform.localScale = playerTempLocalScale;
        }

        #endregion
        
        
        public void Stumble()
        {
            if (isPlayerDead) return; // Don't stumble if the player is dead
            if (isStumbling) return;
            
            StartCoroutine(StumbleRoutine());
            
            Debug.Log("stumble");
        }

        internal IEnumerator StumbleRoutine()
        {
            isStumbling = true;
            
            isMovingLeft = false;
            isMovingRight = false;
            PlayTimeAfterTimeAnimations("Stumble");

            yield return new WaitForSeconds(1f);

            //yield return null;
            isStumbling = false;
        }
        

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = false;
            }
        }

        
        public void Shoot()
        {
            isFiring = true;
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            bullet.transform.Rotate(Vector3.forward * -90f);
            
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            
            if (bulletRB != null)
            {
                bulletRB.AddForce(shootPoint.right * bulletForce, ForceMode2D.Impulse);
            }
            
            PlayTimeAfterTimeAnimations("Fire");
            //Destroy(bullet,5f);
            
            StartCoroutine(ResetFiringFlag());
            //isFiring = false;
        }
        
        private IEnumerator ResetFiringFlag()
        {
            yield return new WaitForSeconds(/*animator.GetCurrentAnimatorStateInfo(0).length*/ 0.3f);
            isFiring = false;
        }
        
        public void Jump()
        {
            if (isGrounded)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                PlayAnimations("Jump");
                isGrounded = false;
            }
        }
        
        
        private void PlayAnimations(string animationState)
        {
            string weaponState = _equipAndInjectPanelManager.weaponState;
            animator.Play($"{weaponState} {animationState}");
        }
        
        private void PlayTimeAfterTimeAnimations(string animationState)
        {
            string weaponState = _equipAndInjectPanelManager.weaponState;
            animator.Play($"{weaponState} {animationState}", -1, 0);
        }
    }
}
