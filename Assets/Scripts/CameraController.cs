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

    public IEnumerator LerpToViewBoardTarget()
    {
        float totalLerpTime = 5f, startTime = Time.time;
        Vector3 initialPosition = transform.position;
        Quaternion initialRotation = transform.rotation;

        float progressionCoefficient = 0f;
        while (progressionCoefficient < .98f)
        {
            progressionCoefficient = (Time.time - startTime) / totalLerpTime;

            transform.position = Vector3.Lerp(initialPosition, gameViewTarget.transform.position, progressionCoefficient);
            transform.rotation = Quaternion.Lerp(initialRotation, gameViewTarget.transform.rotation, progressionCoefficient);

            yield return null;
        }

        transform.position = gameViewTarget.transform.position;
        transform.rotation = gameViewTarget.transform.rotation;
    }
}
