using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkManager : MonoBehaviour
{
    private Animator animator;

    public float blinkTime=0.5f;
    public float timeToBlink = 5f;

    [HideInInspector]
    public bool isEyeClosed = false;
    public bool directEyeContact = false;

    [Header("Debug")]
    public bool TEST_BLINK = false;
    public bool ENABLE_AUTOMATIC_BLINK=true;
    private float baseTimeToBlink;
    
    [Range(0.01f,0.1f)]
    public float blinkSpeedUpRate;

    public float minTimeToBlink = 1f;

    private void Awake()
    {
            animator = GetComponent<Animator>();
        baseTimeToBlink = timeToBlink;
    }

    private void Update()
    {
        if(TEST_BLINK)
        {
            TEST_BLINK=false;
            StartBlink();
        }
    }
    private void FixedUpdate()
    {
        if (directEyeContact && timeToBlink > minTimeToBlink)
        {
            Debug.Log("Le estoy mirando y timeToBlink es de " + timeToBlink);
            timeToBlink-=blinkSpeedUpRate;
            if(timeToBlink<minTimeToBlink)
            {
                timeToBlink = minTimeToBlink;
            }
        }
        else if (!directEyeContact)
        {
            Debug.Log("He parado de mirar");
            timeToBlink = baseTimeToBlink;
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
        isEyeClosed = false;
        animator.SetTrigger("Open");
        
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
