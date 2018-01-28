using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    public AnimationClip _idle;
    public AnimationClip _walk;
    public AnimationClip _run;
    public AnimationClip _push;
    public AnimationClip _slash;

    SkillController _skillController;
    public Animation _animation;

    public float _closeToMaxToConsiderRun;

    public PlayerRunScript _playerMovement;
    public PlayerScript _playerScript;


    float CDRemainingPush = 0;
    float _pushAnimTime = 1.0f;

    float CDRemainingSlash = 0;
    float _slashAnimTime = 1.0f;


    void Start()
    {
        _skillController = GameObject.FindObjectOfType<SkillController>();
    }

    // Update is called once per frame
    void Update()
    {
        CDRemainingPush -= Time.deltaTime;

        if (_skillController)
        {
            //if (CDRemaining <= 0 && !_skillController.skillsList[1].isActive() && _skillController.skillsList[1].getPlayerID() == _playerScript.getPlayerNumber())
            if (!_skillController.skillsList[1].isActive() && _skillController.skillsList[1].getPlayerID() == _playerScript.getPlayerNumber())
            {
                if (!_animation.IsPlaying(_push.name))
                {
                    if (CDRemainingPush <= 0)
                    {
                        _animation.Play(_push.name);
                        CDRemainingPush = _skillController.skillsList[1].coolDown - _skillController.skillsList[1].elapseTime;
                        StartCoroutine(CancelAnimAfterCo(_push, _pushAnimTime));
                    }
                }
                else
                {
                    if (CDRemainingPush <= 0)
                    {
                        _animation.Play(_run.name);
                    }
                }
            }
            else
            {
                if (!_skillController.skillsList[2].isActive() && _skillController.skillsList[2].getPlayerID() == _playerScript.getPlayerNumber())
                {
                    if (!_animation.IsPlaying(_push.name))
                    {
                        if (CDRemainingSlash <= 0)
                        {
                            _animation.Play(_slash.name);
                            CDRemainingSlash = _skillController.skillsList[2].coolDown - _skillController.skillsList[2].elapseTime;
                            StartCoroutine(CancelAnimAfterCo(_slash, _slashAnimTime));
                        }
                    }
                    else
                    {
                        if (CDRemainingSlash <= 0)
                        {
                            _animation.Play(_run.name);
                        }
                    }
                }
                else
                {
                    float speedPercentage = _playerMovement.velocity / _playerMovement.velocityMax;

                    if (speedPercentage > 0.1f)
                    {
                        if (_closeToMaxToConsiderRun < speedPercentage)
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
                    else
                    {
                        if (!_animation.IsPlaying(_idle.name))
                        {
                            _animation.Play(_idle.name);
                        }

                    }
                }
            }
        }
    }


    private IEnumerator CancelAnimAfterCo(AnimationClip anim, float animTime)
    {
        yield return new WaitForSeconds(animTime);

        if (!_animation.IsPlaying(anim.name))
        {
            _animation.Play(anim.name);
        }
    }
}
