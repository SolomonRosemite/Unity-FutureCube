using UnityEngine;

public class Fade : MonoBehaviour
{
    public bool UseInspectorInput;

    [Space]

    public string AnimatorString;
    public bool AnimatorBool = true;
    private Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();

        if (UseInspectorInput)
        {
            CallAnimatorBool(AnimatorString, AnimatorBool);
        }

    }

    public void CallAnimatorBool(string AnimatorString, bool AnimatorBool)
    {
        animator.SetBool(AnimatorString, AnimatorBool);
    }

}