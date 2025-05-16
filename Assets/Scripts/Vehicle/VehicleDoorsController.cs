using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDoorsController : MonoBehaviour
{
    [Header("Animation Settings")]
    [SerializeField] private float animationDuration = 0.5f;

    [Header("Animators")]
    [SerializeField] private List<Animator> doorAnimators;

    [Header("Local Variables")]
    private bool canToggle = true;
    private bool isOpen = false;

    public void ToggleDoors()
    {
        Debug.Log("Toggle1");
        if (canToggle)
        {
            Debug.Log("Toggle2");
            StartCoroutine(PerformToggleDoors());
        }
    }

    private IEnumerator PerformToggleDoors()
    {
        canToggle = false;

        isOpen = !isOpen;
        foreach (Animator animator in doorAnimators)
        {
            animator.SetBool("isOpen", isOpen);
        }

        yield return new WaitForSeconds(animationDuration);

        canToggle = true;
    }
}
