using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIIntro : MonoBehaviour
{
    public List<GameObject> _conversation;
    public Transform _fingers;

    int currentSecuence = 0;

    bool _isFinished;

    public RectTransform _bg;

    void Start()
    {

        StartCoroutine(IncreaseBgSize());

        StartCoroutine(ContinuousMovementBGCo());
        StartCoroutine(MoveFingersCo(3, NextText));


        for (int i = _conversation.Count - 1; i >= 0; i--)
        {
            _conversation[i].SetActive(false);
        }
    }

    private IEnumerator IncreaseBgSize()
    {
        Vector2 initial = _bg.sizeDelta;
        Vector2 final = initial * 1.1f;

        float timestamp = 0;
        float time = 20;

        while (timestamp < time)
        {
            timestamp += Time.deltaTime;
            _bg.sizeDelta = Vector2.Lerp(initial, final, timestamp / time);
            yield return 0;
        }
        yield return 0;
    }

    private IEnumerator ContinuousMovementBGCo()
    {
        Vector3 initialPos = transform.position;

        Vector3 originPos = initialPos;
        Vector3 destinationPos = initialPos;

        float timestamp = 0;

        bool goingDown = true;

        float duration = UnityEngine.Random.Range(0.2f, 1f);
        float mod = UnityEngine.Random.Range(10f, 30f);
        destinationPos = originPos - Vector3.up * mod;

        while (!_isFinished)
        {
            timestamp += Time.deltaTime;

            if (timestamp < duration)
            {
                transform.position = Vector3.Lerp(originPos, destinationPos, timestamp / duration);
            }
            else
            {
                timestamp = 0;
                if (goingDown)
                {
                    destinationPos = initialPos;
                    originPos = transform.position;
                    duration = 0.5f;
                }
                else
                {
                    mod = UnityEngine.Random.Range(10f, 40f);
                    destinationPos = initialPos - Vector3.up * mod;
                    originPos = transform.position;
                    duration = UnityEngine.Random.Range(0.1f, 0.7f);

                }
                goingDown = !goingDown;
            }
            yield return 0;
        }
        yield return 0;

    }

    private IEnumerator MoveFingersCo(float totalTime, VoidDelegateVoid callWhenFinish)
    {
        float originalRotation = -3f;
        float timestamp = 0;

        float initialRotation = originalRotation;
        float finalRotation = 5;// UnityEngine.Random.Range(0.0f, 5.0f);

        bool flip = true;

        int times = UnityEngine.Random.Range(7, 15);
        int currentTime = 1;

        while (timestamp < totalTime)
        {
            timestamp += Time.deltaTime;
            if (timestamp < currentTime * totalTime / times)
            {
                _fingers.localRotation = Quaternion.Euler(Vector3.forward * Mathf.Lerp(initialRotation, finalRotation, timestamp / ( currentTime * totalTime / times )));
            }
            else
            {
                ++currentTime;
                if (flip)
                {
                    initialRotation = transform.rotation.eulerAngles.z;
                    finalRotation = originalRotation;
                }
                else
                {
                    initialRotation = originalRotation;
                    finalRotation = 5;// UnityEngine.Random.Range(0.0f, 5.0f);
                }
                flip = !flip;
            }
            yield return 0;

        }
        yield return 0;

        callWhenFinish();
    }


    private void StartSequence()
    {
        _conversation[currentSecuence++].SetActive(true);

        StartCoroutine(DelayNextStep(0.5f, NextText));
    }

    private IEnumerator DelayNextStep(float time, VoidDelegateVoid callWhenFinish)
    {
        yield return new WaitForSeconds(time);

        callWhenFinish();
    }

    private void NextText()
    {


        if (currentSecuence >= 9)
        {
            Finish();
            return;
        }

        _conversation[currentSecuence].SetActive(true);
        if (currentSecuence >= 3)
        {
            _conversation[currentSecuence - 3].SetActive(false);
        }
        if (currentSecuence == 2 || currentSecuence == 3 || currentSecuence == 4 || currentSecuence == 7)
        {
            StartCoroutine(MoveFingersCo(3, NextText));
        }
        else
        {
            StartCoroutine(DelayNextStep(2f, NextText));
        }
        ++currentSecuence;
    }

    private void Finish()
    {
        //GameManager.Instance.GetComponent<AudioSource>().pitch = 1;


        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
