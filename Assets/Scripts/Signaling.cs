using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource),typeof(ISensor))]
public class Signaling : MonoBehaviour
{
    private ISensor _sensor;
    private AudioSource _audioSource;

    private float _targetVolume;

    private const float _onVolumeLevel = 1f;
    private const float _offVolumeLevel = 0f;
    private const float _speedOfVolumeChanges = 0.3f;

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _offVolumeLevel;
        _sensor = GetComponent<ISensor>();
        _sensor.TriggeredUp += OnSomebodyEnter;
        _sensor.TriggeredDown += OnSomebodyExit;
        this.enabled = false;
    }

    private void OnSomebodyExit(GameObject obj)
    {
        if (obj.GetComponent<Thief>() == null)
            return;

        StartDecaying();
    }

    private void StartDecaying()
    {
        this.enabled = true;
        _targetVolume = _offVolumeLevel;
    }

    private void OnSomebodyEnter(GameObject obj)
    {
        if (obj.GetComponent<Thief>() == null)
            return;

        Launch();
    }

    private void Launch()
    {
        _targetVolume = _onVolumeLevel;
        _audioSource.Play();
        this.enabled = true;
    }

    private void Update()
    {       
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, Time.deltaTime * _speedOfVolumeChanges);

        if (_audioSource.volume == _targetVolume)
            StopChanges();
    }

    private void StopChanges()
    {
        if (_targetVolume == _offVolumeLevel)
            _audioSource.Stop();

        this.enabled = false;
    }

    private void OnDestroy()
    {
        _sensor.TriggeredUp -= OnSomebodyEnter;
        _sensor.TriggeredDown -= OnSomebodyExit;
    }
}
