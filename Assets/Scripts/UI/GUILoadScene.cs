using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUILoadScene : MonoBehaviour
{
    [SerializeField]
    private bool _autoLoadScene;

    [SerializeField]
    private int _sceneToLoad;

    [SerializeField]
    private float _delayToLoad;

    // Use this for initialization
    void Start()
    {
        if (_autoLoadScene)
        {
            StartCoroutine(DelayLoadSceneAtAStartCO());
        }
    }

    private IEnumerator DelayLoadSceneAtAStartCO()
    {
        yield return new WaitForSeconds(_delayToLoad);
        LoadSceneByIndex(_sceneToLoad);
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}
