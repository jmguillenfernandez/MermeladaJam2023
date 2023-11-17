using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkManager : MonoBehaviour
{
    private Animator animator;

    public float blinkTime=0.5f;

    [HideInInspector]
    public bool isEyeClosed = false;

    public bool DEBUG_TEST_BLINK = false;

    private void Awake()
    {
            animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(DEBUG_TEST_BLINK)
        {
            DEBUG_TEST_BLINK=false;
            StartBlink();
        }
    }

    public void StartBlink()
    {
        animator.SetTrigger("Close");
        
    }

    public IEnumerator HoldBlink()
    {
        isEyeClosed = true;
        yield return new WaitForSeconds(blinkTime);
        animator.SetTrigger("Open");
        isEyeClosed=false;
    }

}
