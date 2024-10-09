using Characters.Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.PlayerControls
{
    
    public class GoRightBTN : EventTrigger
    {
        [SerializeField] private PlayerController playerController;

        public override void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Pointer down!");
            playerController.StartMoveRight();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("Pointer up!");
            playerController.StopMove();
        }
    }
}