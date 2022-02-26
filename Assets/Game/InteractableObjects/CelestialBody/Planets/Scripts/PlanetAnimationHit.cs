using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAnimationHit: MonoBehaviour
{
    public AnimationCurve _curveDamageAnimation;

    private CelestialBody _body;


    private void Awake()
    {
        _body = GetComponent<CelestialBody>();
    }

    private void OnEnable()
    {
        _body.OnGetDamage += DamageAnimation;
    }
    private void OnDisable()
    {
        _body.OnGetDamage -= DamageAnimation;
    }
    private void DamageAnimation(float damage)
    {
        StartCoroutine("DamageAnimationCor");
    }
    private IEnumerator DamageAnimationCor()
    {
        float time = 1f;
        float currentTime = 0;
        Vector3 currentScale = transform.localScale;
        while (currentTime < time)
        {
            transform.localScale = currentScale * _curveDamageAnimation.Evaluate(currentTime);
            currentTime += Time.deltaTime;
            yield return null;
        }


    }
}
