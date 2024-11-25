using System.Collections;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Thief))]
    public class WayPoints : MonoBehaviour
    {
        [SerializeField] private Transform _path;

        private Transform[] _points;
        private int _currentPoint;
        private float _speed;

        private void Start()
        {
            _speed = GetComponent<Thief>().GetSpeed;
            _points = new Transform[_path.childCount];

            for (int i = 0; i < _path.childCount; i++)
            {
                _points[i] = _path.GetChild(i);
            }

            StartCoroutine(StartMoving());
        }

        private IEnumerator StartMoving()
        {
            for (int i = 0; i < _points.Length; i++)
            {
                while (!transform.position.Equals(_points[i].position))
                {
                    transform.position = Vector3.MoveTowards(transform.position, _points[i].position, Time.deltaTime * _speed);
                    yield return null;
                }

                if ((i + 1).Equals(_points.Length))
                {
                    i = -1;
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(1, 180, 1);
                }
            }
        }
    }
}
