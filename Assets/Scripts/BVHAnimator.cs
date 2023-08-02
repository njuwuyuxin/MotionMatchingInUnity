using System.Linq;
using UnityEngine;

public class BVHAnimator : MonoBehaviour
{
    public BVHAnimationClip animationClip;

    private Transform[] m_BoneList;
    private int m_CurrentFrame;
    private float m_Timer;
    private Transform rootBone;

    // Start is called before the first frame update
    void Start()
    {
        rootBone = transform.Find("Model:Hips");
        m_BoneList = new Transform[animationClip.boneList.Count];
        if (animationClip != null)
        {
            var bones = transform.GetComponentsInChildren<Transform>().ToList();
            for (int i = 0; i < animationClip.boneList.Count; i++)
            {
                var boneName = animationClip.boneList[i];
                Transform bone = bones.Find((boneTransform) => { return boneTransform.name.Contains(boneName); });
                if (bone != null)
                {
                    m_BoneList[i] = bone;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Timer > (1f / 30f))
        {
            SampleAnimation();
            m_CurrentFrame++;
            m_Timer -= (1f / 30f);
        }
        m_Timer += Time.deltaTime;
    }

    private void SampleAnimation()
    {
        for (int i = 0; i < m_BoneList.Length; i++)
        {
            m_BoneList[i].localRotation = animationClip.boneRotations[i].keyFrame[m_CurrentFrame];
        }

        transform.position = animationClip.rootMotionCurve[m_CurrentFrame] - animationClip.rootBoneOffset;
    }
}
