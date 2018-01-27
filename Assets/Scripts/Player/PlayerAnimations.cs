using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    public AnimationClip _walk;
    public AnimationClip _run;
    public AnimationClip _push;

    SkillController _skillController;
    public Animation _animation;

    public float _closeToMaxToConsiderRun;

    public PlayerRunScript _playerMovement;
    public PlayerScript _playerScript;


    float CDRemaining = 0;
    float _pushAnimTime = 1.0f;

    void Start()
    {
        _skillController = GameObject.FindObjectOfType<SkillController>();
    }

    // Update is called once per frame
    void Update()
    {
        CDRemaining -= Time.deltaTime;

        if (_skillController)
        {
            //if (CDRemaining <= 0 && !_skillController.skillsList[1].isActive() && _skillController.skillsList[1].getPlayerID() == _playerScript.getPlayerNumber())
            if (!_skillController.skillsList[1].isActive() && _skillController.skillsList[1].getPlayerID() == _playerScript.getPlayerNumber())
            {
                if (!_animation.IsPlaying(_push.name))
                {
                    if (CDRemaining <= 0)
                    {
                        _animation.Play(_push.name);
                        CDRemaining = _skillController.skillsList[1].coolDown - _skillController.skillsList[1].elapseTime;
                        StartCoroutine(CancelAnimAfterCo(_pushAnimTime));
                    }
                }
                else
                {
                    if (CDRemaining <= 0)
                    {
                        _animation.Play(_run.name);
                    }
                }
            }
            else
            {
                if (_closeToMaxToConsiderRun < _playerMovement.velocity / _playerMovement.velocityMax)
                {
                    if (!_animation.IsPlaying(_run.name))
                    {
                        _animation.Play(_run.name);
                    }
                }
                else
                {
                    if (!_animation.IsPlaying(_walk.name))
                    {
                        _animation.Play(_walk.name);
                    }
                }
            }
        }
    }

    private IEnumerator CancelAnimAfterCo(float _pushAnimTime)
    {
        yield return new WaitForSeconds(_pushAnimTime);

        if (!_animation.IsPlaying(_run.name))
        {
            _animation.Play(_run.name);
        }
    }
}
