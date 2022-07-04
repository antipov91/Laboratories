using UnityEngine;

namespace Laboratories
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [Header("Player")]
        [Range(0.05f, 2)]
        public float rotationAmount = 0.2f;
        [Range(1f, 20)] 
        public float rotationSmooth = 6f;
        [Range(10, 120)] 
        public float lookLimit = 80.0f;
        [Range(0.5f, 10)] 
        public float lookSpeed = 2.0f;
        public float rayDistance = 1f;
    }
}