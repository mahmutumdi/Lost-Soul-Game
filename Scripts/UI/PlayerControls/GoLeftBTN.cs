using Characters.Player;
using UnityEngine;
using UnityEngine.EventSystems;
using Utilities;

namespace UI.PlayerControls
{
    public class GoLeftBTN : UIPressBTN
    {
        [SerializeField] private PlayerController playerController;

        protected override void HandlePointerDown(PointerEventData eventData)
        {
            Debug.Log("Pointer down!");
            playerController.StartMoveLeft();
        }

        protected override void HandlePointerUp(PointerEventData eventData)
        {
            Debug.Log("Pointer up!");
            playerController.StopMove();
        }
    }
}