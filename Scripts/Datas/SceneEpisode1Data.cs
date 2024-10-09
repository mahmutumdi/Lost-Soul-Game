using System;
using UnityEngine;

namespace Datas
{
    public class SceneEpisode1Data: MonoBehaviour
    {
        public static SceneEpisode1Data Instance { get; private set; }
        public Transform PlayerTransform { get; private set; }
        private void Awake()
        {
            Instance = this;
        }

        public void SetPlayerTrans(Transform playerTrans)
        {
            PlayerTransform = playerTrans;
        }
    }
}