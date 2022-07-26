using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private float _alarmVolume = 0.005f;
    private float _maxAlarmVolume = 1;
    private float _minAlarmVolume = 0;

    private void Start()
    {
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume > _alarmVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minAlarmVolume, _alarmVolume);
            yield return null;
        }
    }
}
