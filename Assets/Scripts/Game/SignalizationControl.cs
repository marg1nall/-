using System.Collections;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(AudioSource))]
    public class SignalizationControl : MonoBehaviour
    {
        [SerializeField] private AudioClip _signalizationClip;

        private Signalization _signalization;
        private AudioSource _audioSource;
        private Coroutine _signalizationCoroutine;

        private const float MinVolume = 0;
        private const float MaxVolume = 1;

        private void Awake()
        {
            _signalization = GetComponent<Signalization>();
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = _signalizationClip;
        }

        private void OnEnable()
        {
            _signalization.Alarmed += UseSignalization;
        }

        private void OnDisable()
        {
            _signalization.Alarmed -= UseSignalization;
        }

        public void UseSignalization()
        {
            if (_signalizationCoroutine != null)
            {
                StopCoroutine(_signalizationCoroutine);
                _signalizationCoroutine = null;
            }

            if (_signalization.IsEntry)
            {
                _signalizationCoroutine =
                    StartCoroutine(StartSignal(MinVolume, MaxVolume, _signalizationClip.length, true));
            }
            else
            {
                _signalizationCoroutine =
                    StartCoroutine(StartSignal(_audioSource.volume, MinVolume, _signalizationClip.length, false));
            }
        }

        private IEnumerator StartSignal(float start, float end, float lenghtClip, bool looping)
        {
            _audioSource.Play();
            _audioSource.loop = looping;

            float stepVolume = 0f;

            while (stepVolume <= lenghtClip)
            {
                stepVolume += Time.deltaTime;
                _audioSource.volume = Mathf.Lerp(start, end, stepVolume / _signalizationClip.length);
                yield return null;
            }
        }
    }
}