using UnityEngine;

public class Thief : MonoBehaviour
{
    [Range(0f, 3f)] [SerializeField] private float _speed;

    public float Speed => _speed;
    private Animator _animator;

    private void Awake()
    {
        _speed = 1.3f;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _speed);
    }
}
