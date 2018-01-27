using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChild : MonoBehaviour
{

    [SerializeField]
    private Transform _childToFollow;

    void LateUpdate()
    {
        if (_childToFollow == null)
            return;

        Vector3 offset = -_childToFollow.localPosition;
        _childToFollow.localPosition = Vector3.zero;
        transform.position -= offset;


        Vector3 rotation = -_childToFollow.localRotation.eulerAngles;
        _childToFollow.localRotation = Quaternion.identity;
        transform.Rotate(-rotation);
    }
}
