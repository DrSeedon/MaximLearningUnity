using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationText : MonoBehaviour
{
    public Animator animator;
    public AnimationImage animationImage;
    bool imageFlip;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Active", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x> 500 && transform.position.x < 1500)
        {
            animator.SetBool("Active", true);

            if (!imageFlip)
            {
                animationImage.animator.SetTrigger("Flip");
                imageFlip = !imageFlip;
            }
        }
        else
        {
            animator.SetBool("Active", false);
            imageFlip = false;
        }
    }

}
