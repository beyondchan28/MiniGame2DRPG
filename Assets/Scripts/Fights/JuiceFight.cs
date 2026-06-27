using UnityEngine;
using System.Collections;

public class JuiceFight : MonoBehaviour
{
    public void AttackAnimation()
    {
        StartCoroutine(SwingingAndBack());
    }
    IEnumerator SwingingAndBack()
    {
        yield return StartCoroutine(Rotating(Quaternion.Euler(new Vector3(0f, 0f, 30f)), 0.1f));
        yield return StartCoroutine(Rotating(Quaternion.Euler(new Vector3(0f, 0f, -30f)), 0.2f));
        yield return StartCoroutine(Rotating(Quaternion.Euler(Vector3.zero), 0.1f));
    }

    public void DefendAnimation()
    {
        StartCoroutine(Rotate360());
    }
    IEnumerator Rotate360()
    {
        yield return StartCoroutine(Rotating(Quaternion.Euler(new Vector3(0f, 0f, 180f)), 0.3f));
        yield return MovingAndBack();
        yield return StartCoroutine(Rotating(Quaternion.Euler(new Vector3(0f, 0f, 0f)), 0.1f));
    }

    public void DodgeAnimation()
    {
        StartCoroutine(MovingAndBack());
    }
    IEnumerator MovingAndBack()
    {
        yield return StartCoroutine(Moving(new Vector3(0.5f, 1f, 0f), 0.3f));
        yield return StartCoroutine(Moving(new Vector3(0.5f, 0f, 0f), 0.1f));
    }

    IEnumerator Rotating(Quaternion endRotation, float duration)
    {
        float elapsedTime = 0f;

        Quaternion startRotation = transform.rotation;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / duration;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, percentageComplete);
            yield return null;
        }
        transform.rotation = endRotation;
    }

    IEnumerator Moving(Vector3 target, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.localPosition;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            transform.localPosition = Vector3.Lerp(startingPosition, target, t);
            yield return null;
        }
        transform.localPosition = target;
    }
}
