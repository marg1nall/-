using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        var currentSpeed = GetComponent<Thief>().Speed;
        var target = _points[_currentPoint];

        Debug.Log(_points[_currentPoint].name);

        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * currentSpeed);

        if (transform.position.Equals(target.position))
        {
            Debug.Log("Дошел до точки");
            _currentPoint++;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            if (_currentPoint.Equals(_points.Length))
            {
                _currentPoint = 0;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}