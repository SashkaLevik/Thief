﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(House))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private House _house;
    private float _speedVolumeChange = 0.002f;
    private float _minAlarmVolume = 0;
    private float _maxAlarmVolume = 1;    
    private Coroutine _changeVolume;

    
    private void Start()
    {
        _audioSource.volume = _minAlarmVolume;
    }

    private void OnEnable()
    {
        _house = GetComponent<House>();
        _house.Breached += OnVolumeChange;
    }

    private void OnDisable()
    {
        _house.Breached -= OnVolumeChange;
    }

    private void OnVolumeChange(bool isBreached)
    {
        if (isBreached)
        {
            _changeVolume = StartCoroutine(ChangingVolume(_maxAlarmVolume));
            return;
        }

        StopCoroutine(ChangingVolume(_maxAlarmVolume));
        _changeVolume = StartCoroutine(ChangingVolume(_minAlarmVolume));
    }    

    private IEnumerator ChangingVolume(float target)
    {
        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _speedVolumeChange);
            yield return null;
        }
    }   
}
