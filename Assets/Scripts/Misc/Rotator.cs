using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 2f;

    [Header("Local Variables")]
    private bool isRotating = false;

    private void Update()
    {
        if (!isRotating)
            return;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (transform.up * rotationSpeed * Time.deltaTime));
    }

    public void ToggleRotation()
    {
        isRotating = !isRotating;
    }
}
