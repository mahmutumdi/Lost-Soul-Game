using UnityEngine;

namespace Characters.Player
{
    public class CameraManager : MonoBehaviour
    {
        public Transform gamecamera;
        public float gamecamera_cameraspeed;

        void Start()
        {
        
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.E))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -10);
                transform.position = Vector3.Slerp(transform.position, new Vector3(transform.position.x + 1, transform.position.y, -10), gamecamera_cameraspeed);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -10);
                transform.position = Vector3.Slerp(transform.position, new Vector3(transform.position.x - 1, transform.position.y, -10), gamecamera_cameraspeed);
            }
        }
    }
}