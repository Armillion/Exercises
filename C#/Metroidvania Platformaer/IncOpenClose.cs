using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncOpenClose : MonoBehaviour
{
    Animator animator;
    bool isOpen = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnClick()
    {
        animator.SetBool("isUsed", !isOpen);
        isOpen = !isOpen;
    }
}
