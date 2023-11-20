using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerController : MonoBehaviour
{
    public bool canFlicker;
    [Range(1f, 100f)]
    public float flickerPercent;
    [Range(0.1f,1f)]
    public float flickerSpeedMin;
    [Range(0.1f, 1f)]
    public float flickerSpeedMax;

    public float flickerCooldown;

    bool cooldown = false;
    Light bulb;

    private void Awake()
    {
        bulb = GetComponentInChildren<Light>();
    }

    private void Update()
    {
        if(canFlicker && !cooldown)
        {
            cooldown = true;
            if(Random.Range(0,100)<=flickerPercent)
            {
                StartCoroutine(Flicker());
            }
        }
    }

    public IEnumerator Flicker()
    {
        bulb.enabled = false;
        yield return new WaitForSeconds(Random.Range(flickerSpeedMin, flickerSpeedMax));
        bulb.enabled = true;
        StartCoroutine(CoolDown());
    }
    public IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(flickerCooldown);
        cooldown = false;
    }
}
