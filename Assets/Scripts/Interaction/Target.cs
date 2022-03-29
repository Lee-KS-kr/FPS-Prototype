using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : InteractionObjects
{
    [SerializeField] private AudioClip clipTargetUp;
    [SerializeField] private AudioClip clipTargetDown;
    [SerializeField] private float targetUpDelay = 3;

    private AudioSource audioSource;
    private bool isPossibleHit = true;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0 && isPossibleHit)
        {
            isPossibleHit = false;
            StartCoroutine(OnTargetDown());
        }
    }

    private IEnumerator OnTargetDown()
    {
        audioSource.clip = clipTargetDown;
        audioSource.Play();

        yield return StartCoroutine(OnAnimation(0, 90));

        StartCoroutine(OnTargetUp());
    }

    private IEnumerator OnTargetUp()
    {
        yield return new WaitForSeconds(targetUpDelay);

        audioSource.clip = clipTargetUp;
        audioSource.Play();

        yield return StartCoroutine(OnAnimation(90, 0));

        isPossibleHit = true;
    }

    private IEnumerator OnAnimation(float start, float end)
    {
        float percent = 0;
        float current = 0;
        float time = 1;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / time;

            transform.rotation = Quaternion.Slerp(Quaternion.Euler(0, -90, -start), Quaternion.Euler(0, -90, -end), percent);

            yield return null;
        }
    }
}
