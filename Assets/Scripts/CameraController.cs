using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    [SerializeField] private Camera gameViewTarget;

    void Awake()
    {
        instance = this;
    }

    public IEnumerator LerpToCameraViewTargets(Vector3 position, Vector3 eulerAngles, float totalTime)
    {
        float startTime = Time.time;
        Vector3 initialPosition = transform.position;
        Vector3 initialRotation = transform.eulerAngles;

        float progressionCoefficient = 0f;
        while (progressionCoefficient < .98f)
        {
            progressionCoefficient = (Time.time - startTime) / totalTime;

            transform.position = Vector3.Lerp(initialPosition, position, progressionCoefficient);
            transform.eulerAngles = Vector3.Lerp(initialRotation, eulerAngles, progressionCoefficient);

            yield return null;
        }

        transform.position = position;
        transform.eulerAngles = eulerAngles;
    }

    public IEnumerator LerpToViewBoardTarget(float totalTime)
    {
        yield return LerpToCameraViewTargets(gameViewTarget.transform.position, gameViewTarget.transform.eulerAngles, totalTime);
    }
}
