using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Location
{
    public Vector3 position;
    public Vector3 rotation;
}
public class AnimationLocation : MonoBehaviour
{
    public Location[] presetAnimationLocation;
    public GameObject spriteAnimator;
    public Animator animator;
    ScreenEffectController screenEffect;
    void Start()
    {
        screenEffect = GetComponent<ScreenEffectController>();
    }

    public void SetAnimationLocation(int index)
    {
        if (index < presetAnimationLocation.Length)
        {
            spriteAnimator.transform.position = presetAnimationLocation[index].position;
            spriteAnimator.transform.eulerAngles = presetAnimationLocation[index].rotation;
        }

        PlayScreenEffect(index);
    }

    public void SetAnimationLocation()
    {
        //return random
        int index = Random.Range(0, presetAnimationLocation.Length);
        spriteAnimator.transform.position = presetAnimationLocation[index].position;
        spriteAnimator.transform.eulerAngles = presetAnimationLocation[index].rotation;

        PlayScreenEffect(index);
    }

    void PlayScreenEffect(int index)
    {
        if(index == 0)
        {
            screenEffect.PlayBottomScreenEffect();
        }

        if (index == 1)
        {
            screenEffect.PlayLeftScreenEffect();
        }

        if (index == 2)
        {
            screenEffect.PlayTopScreenEffect();
        }

        if (index == 3)
        {
            screenEffect.PlayRightScreenEffect();
        }
    }

    public void PlayVideo()
    {
          animator.Play("SnowmanAnimation");
    }

    public bool isVideoPlay()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("SnowmanAnimation"))
            return true;
        else return false;
    }

    public void Update()
    {

    }

}
