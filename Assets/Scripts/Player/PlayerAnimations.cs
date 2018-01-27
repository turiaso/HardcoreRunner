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
    bool _doingPush;

    public PlayerRunScript _playerMovement;
    public PlayerScript _playerScript;



    void Start()
    {
        _skillController = GameObject.FindObjectOfType<SkillController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_skillController)
        {
            if (!_skillController.skillsList[1].isActive() && _skillController.skillsList[1].getPlayerID() == _playerScript.getPlayerNumber())
            {
                if (!_doingPush)
                {
                    _animation.Play(_push.name);
                }
                else
                {
                    _animation.Play(_run.name);
                    _doingPush = false;
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
}
