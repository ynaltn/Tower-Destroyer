using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        
    }
    public void PlayTargetAnimation(string targetAnim, bool isInteracting)
    {
        animator.SetBool(targetAnim, isInteracting);
    }
}
