using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkManager : MonoBehaviour
{
    private Animator animator;

    public float blinkTime=0.5f;

    [HideInInspector]
    public bool isEyeClosed = false;

    [Header("Debug")]
    public bool TEST_BLINK = false;
    public bool ENABLE_AUTOMATIC_BLINK=true;
    public float timeToBlink = 5f;

    private void Awake()
    {
            animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(TEST_BLINK)
        {
            TEST_BLINK=false;
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

    public IEnumerator ResetBlink()
    {
        yield return new WaitForSeconds(timeToBlink);

        if (ENABLE_AUTOMATIC_BLINK)
        {
            StartBlink();
        }
    }
}
