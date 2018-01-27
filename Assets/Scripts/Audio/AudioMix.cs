using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AudioLevel
{
    Easy,
    Medium,
    Hard
}

public class AudioMix : MonoBehaviour
{
    public AudioSource _introAudioSource;
    public List<AudioSource> _audioSources;

    public AudioClip _intoEasy;
    public AudioClip _intoMedium;
    public AudioClip _intoHard;

    public AudioClip _trackEasy;
    public AudioClip _trackMedium;
    public AudioClip _trackHard;

    [SerializeField]
    private string _player01Tag;

    [SerializeField]
    private string _goalTag;
    private Transform _player01;
    private Transform _goal;

    public float _fadeOutTime;

    public List<AudioLevel> _levelTrack;

    private int _currentTrack;

    float _distancePercentage;
    float _maxDistance;

    private int _currentAudioSource;

    private float _timeStamp;

    public void Start()
    {
        var go = GameObject.FindGameObjectWithTag(_player01Tag);
        if (go != null)
            _player01 = go.transform;

        go = GameObject.FindGameObjectWithTag(_goalTag);
        if (go != null)
            _goal = go.transform;

        _maxDistance = ( _goal.transform.position - _player01.transform.position ).magnitude;

        _distancePercentage = _maxDistance / _levelTrack.Count;
    }

    public void Update()
    {
        if (CheckDistance())
        {
            NextLevel();
        }
    }

    public bool CheckDistance()
    {
        float currentDistance = ( _goal.transform.position - _player01.transform.position ).magnitude;
        return ( ( _currentTrack + 1 ) * _distancePercentage ) < ( 1 - ( currentDistance / _maxDistance ) );
    }

    public void NextLevel()
    {
        StartCoroutine(FadeOutCo());
        StartIntro();
        ++_currentTrack;
    }

    private void StartIntro()
    {
        int nextAudio = _currentTrack + 1;
        switch (_levelTrack[nextAudio])
        {
            case AudioLevel.Easy:
                _introAudioSource.clip = _intoEasy;
                break;
            case AudioLevel.Medium:
                _introAudioSource.clip = _intoMedium;
                break;
            case AudioLevel.Hard:
                _introAudioSource.clip = _intoHard;

                break;
        }
        _introAudioSource.Play();
        StartCoroutine(StartAudioInSecCo(_introAudioSource.clip.length));
    }

    private IEnumerator StartAudioInSecCo(float length)
    {
        yield return new WaitForSeconds(length);
        ++_currentAudioSource;
        if (_currentAudioSource >= _audioSources.Count)
            _currentAudioSource = 0;

        _audioSources[_currentAudioSource].clip = GetTrack(_levelTrack[_currentTrack]);
    }

    private AudioClip GetTrack(AudioLevel audioLevel)
    {
        switch (audioLevel)
        {
            case AudioLevel.Easy:
                return _trackEasy;
            case AudioLevel.Medium:
                return _trackMedium;
            case AudioLevel.Hard:
                return _trackHard;
        }
        return null;
    }

    private IEnumerator FadeOutCo()
    {
        while (_timeStamp < _fadeOutTime)
        {
            _audioSources[_currentAudioSource].volume = Mathf.Lerp(1, 0, _timeStamp / _fadeOutTime);
            yield return 0;
        }
    }
}
