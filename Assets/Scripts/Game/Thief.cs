using UnityEngine;

namespace Game
{
    public class Thief : MonoBehaviour
    {
        private const float Speed = 1.3f;

        public float GetSpeed => Speed;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetFloat("Speed", Speed);
        }
    }
}
