using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleColorController : MonoBehaviour
{
    [Header("Body Panels")]
    [SerializeField] private List<MeshRenderer> bodyPanelRenderers;
    [SerializeField] private Material bodyColorMaterial;
    [SerializeField] private List<Material> bodyPanelMaterials = new List<Material>();

    [Header("Wheels")]
    [SerializeField] private List<MeshRenderer> wheelRenderers;
    [SerializeField] private Material wheelMaterial;
    [SerializeField] private List<Material> wheelMaterials = new List<Material>();

    private void Awake()
    {
        GetBodyPanelMaterials();
        GetWheelMaterials();
        SetWheelsColor(Color.red);
    }

    private void GetBodyPanelMaterials()
    {
        bodyPanelMaterials.Clear();

        foreach (MeshRenderer renderer in bodyPanelRenderers)
        {
            Material[] sharedMats = renderer.sharedMaterials;

            for (int i = 0; i < sharedMats.Length; i++)
            {
                Material sharedMat = sharedMats[i];

                if (sharedMat == bodyColorMaterial)
                {
                    Material[] mats = renderer.materials;
                    bodyPanelMaterials.Add(mats[i]);
                }
            }
        }
    }

    private void GetWheelMaterials()
    {
        wheelMaterials.Clear();

        foreach (MeshRenderer renderer in wheelRenderers)
        {
            Material[] sharedMats = renderer.sharedMaterials;

            for (int i = 0; i < sharedMats.Length; i++)
            {
                Material sharedMat = sharedMats[i];

                if (sharedMat == wheelMaterial)
                {
                    Material[] mats = renderer.materials;
                    wheelMaterials.Add(mats[i]);
                }
            }
        }
    }

    public void SetBodyColor(Color newColor)
    {
        foreach (Material mat in bodyPanelMaterials)
        {
            mat.color = newColor;
        }
    }

    public void SetWheelsColor(Color newColor)
    {
        foreach (Material mat in wheelMaterials)
        {
            mat.color = newColor;
        }
    }
}
