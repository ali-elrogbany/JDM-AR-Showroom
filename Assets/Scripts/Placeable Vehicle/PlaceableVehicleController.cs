using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaceableVehicleController : MonoBehaviour
{
    [Header("Vehicle References")]
    [SerializeField] private VehicleColorController vehicleColorController;
    [SerializeField] private VehicleDoorsController vehicleDoorsController;
    [SerializeField] private VehicleAudioManager vehicleAudioManager;
    [SerializeField] private List<Rotator> vehicleRotators;

    [Header("Canvases References")]
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject specsCanvas;
    [SerializeField] private GameObject colorPickerCanvas;

    [Header("Spec Texts")]
    [SerializeField] private TMP_Text makeText;
    [SerializeField] private TMP_Text modelText;
    [SerializeField] private TMP_Text yearText;
    [SerializeField] private TMP_Text engineText;

    [Header("Scriptable Object References")]
    [SerializeField] private VehicleInfoSO vehicleInfoSO;

    [Header("Local Variables")]
    private PaintType paintType = PaintType.BODY;
    private bool isMainCanvasOpen = true;
    private bool isSpecsCanvasOpen = true;
    private bool isColorPickerCanvasOpen = false;

    [Header("References")]
    private AudioSource voiceoverSource;

    private void Awake()
    {
        voiceoverSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        FillSpecs();
    }

    private void FillSpecs()
    {
        makeText.text = vehicleInfoSO.make;
        modelText.text = vehicleInfoSO.model;
        yearText.text = vehicleInfoSO.year;
        engineText.text = vehicleInfoSO.engine;
    }

    public void OnToggleEngine()
    {
        vehicleAudioManager.ToggleEngine();
    }

    public void OnToggleDoors()
    {
        vehicleDoorsController.ToggleDoors();
    }

    public void OnToggleRotation()
    {
        foreach (Rotator rotator in vehicleRotators)
        {
            rotator.ToggleRotation();
        }
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

    public void OnPlayVoiceover()
    {
        voiceoverSource.Stop();

        voiceoverSource.clip = vehicleInfoSO.voiceover;

        voiceoverSource.Play();
    }

    public void OnToggleCanvas()
    {
        isMainCanvasOpen = true;
        isSpecsCanvasOpen = false;
        isColorPickerCanvasOpen = false;

        mainCanvas.SetActive(isMainCanvasOpen);
        specsCanvas.SetActive(isSpecsCanvasOpen);
        colorPickerCanvas.SetActive(isColorPickerCanvasOpen);
    }

    public void OnToggleSpecsCanvas()
    {
        isMainCanvasOpen = false;
        isSpecsCanvasOpen = true;
        isColorPickerCanvasOpen = false;

        mainCanvas.SetActive(isMainCanvasOpen);
        specsCanvas.SetActive(isSpecsCanvasOpen);
        colorPickerCanvas.SetActive(isColorPickerCanvasOpen);
    }

    public void OnToggleColorPickerCanvas()
    {
        isMainCanvasOpen = false;
        isSpecsCanvasOpen = false;
        isColorPickerCanvasOpen = true;

        mainCanvas.SetActive(isMainCanvasOpen);
        specsCanvas.SetActive(isSpecsCanvasOpen);
        colorPickerCanvas.SetActive(isColorPickerCanvasOpen);
    }
}

public enum PaintType
{
    BODY,
    WHEELS
}