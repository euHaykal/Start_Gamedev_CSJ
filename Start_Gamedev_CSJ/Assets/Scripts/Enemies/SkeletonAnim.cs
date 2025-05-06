using UnityEngine;

public class SkeletonAnim : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnim(int value)
    {
        if (value == 0) //Idle
        {
            anim.SetInteger("transition", 0); //Idle
        }
        else if (value == 1) //Walk
        {
            anim.SetInteger("transition", 1); //Walk
        }
        else if (value == 2) //Attack
        {
            anim.SetInteger("transition", 2); //Attack
        }
    }
}
