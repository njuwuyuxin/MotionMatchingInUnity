using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RotationCurve
{
    public Quaternion[] keyFrame;
}

[CreateAssetMenu(menuName = "BVHAnimationClip")]
public class BVHAnimationClip : ScriptableObject
{
    public GameObject model; 
    public int totalFrame;
    public float frameTime;
    public List<string> boneList;

    public List<RotationCurve> boneRotations;
    public Vector3 rootBoneOffset;
    public Vector3[] rootMotionCurve;
}
