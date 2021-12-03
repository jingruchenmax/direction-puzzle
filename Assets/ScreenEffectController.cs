using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffectController : MonoBehaviour
{
    public Animator left;
    public Animator top;
    public Animator right;
    public Animator bottom;

    public void PlayLeftScreenEffect()
    {
        left.Play("LeftAnimation");
    }
    public void PlayRightScreenEffect()
    {
        right.Play("LeftAnimation");
    }
    public void PlayTopScreenEffect()
    {
        top.Play("LeftAnimation");
    }
    public void PlayBottomScreenEffect()
    {
        bottom.Play("LeftAnimation");
    }
}
