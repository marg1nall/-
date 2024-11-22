using UnityEngine;
using UnityEngine.Events;

public class Signalization : MonoBehaviour
{
    [SerializeField] private UnityEvent _alarmed;

    public event UnityAction Alarmed
    {
        add => _alarmed.AddListener(value);
        remove => _alarmed.RemoveListener(value);
    }
    public bool IsEntry { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Thief>(out Thief thief))
        {
            IsEntry = !IsEntry;
            _alarmed?.Invoke();
            Debug.Log($"вор внутри {IsEntry}");
        }
    }
}
