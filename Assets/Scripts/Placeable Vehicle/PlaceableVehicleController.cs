using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableVehicleController : MonoBehaviour
{
    [Header("Vehicle References")]
    [SerializeField] private VehicleColorController vehicleColorController;
    [SerializeField] private VehicleDoorsController vehicleDoorsController;
    [SerializeField] private VehicleAudioManager vehicleAudioManager;

    [Header("Canvases References")]
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject colorPickerCanvas;

    [Header("Local Variables")]
    private PaintType paintType = PaintType.BODY;
    private bool isMainCanvasOpen = true;
    private bool isColorPickerCanvasOpen = false;

    public void OnToggleEngine()
    {
        vehicleAudioManager.ToggleEngine();
    }

    public void OnToggleDoors()
    {
        vehicleDoorsController.ToggleDoors();
    }

    public void OnChangePaintType(bool isBodyPaint)
    {
        this.paintType = isBodyPaint ? PaintType.BODY : PaintType.WHEELS;
    }

    public void OnColorChange(Color color)
    {
        if (paintType == PaintType.BODY)
        {
            vehicleColorController.SetBodyColor(color);
        }
        else if (paintType == PaintType.WHEELS)
        {
            vehicleColorController.SetWheelsColor(color);
        }
    }

    public void OnToggleCanvas(bool isMainCanvasOpen)
    {
        this.isMainCanvasOpen = isMainCanvasOpen;
        this.isColorPickerCanvasOpen = !isMainCanvasOpen;

        mainCanvas.SetActive(isMainCanvasOpen);
        colorPickerCanvas.SetActive(isColorPickerCanvasOpen);
    }
}

public enum PaintType
{
    BODY,
    WHEELS
}