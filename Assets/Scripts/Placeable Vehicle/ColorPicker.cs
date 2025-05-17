using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorPicker : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [Header("Vehicle References")]
    [SerializeField] private PlaceableVehicleController placeableVehicleController;

    [Header("UI References")]
    public RawImage svImage;
    public Slider hueSlider;
    public RawImage colorPreview;

    private Texture2D svTexture;
    private float hue = 0;
    private float saturation = 1;
    private float value = 1;

    void Start()
    {
        UpdateSVTexture();
        hueSlider.onValueChanged.AddListener(OnHueChanged);
    }

    void OnHueChanged(float h)
    {
        hue = h;
        UpdateSVTexture();
        UpdateColor();
    }

    public void OnPointerDown(PointerEventData eventData) => HandleSV(eventData);
    public void OnDrag(PointerEventData eventData) => HandleSV(eventData);

    void HandleSV(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            svImage.rectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint);

        var rect = svImage.rectTransform.rect;
        saturation = Mathf.Clamp01((localPoint.x - rect.x) / rect.width);
        value = Mathf.Clamp01((localPoint.y - rect.y) / rect.height);

        UpdateColor();
    }

    void UpdateColor()
    {
        Color color = Color.HSVToRGB(hue, saturation, value);
        colorPreview.color = color;
        placeableVehicleController.OnColorChange(color);
    }

    void UpdateSVTexture()
    {
        if (svTexture == null)
            svTexture = new Texture2D(100, 100);

        for (int y = 0; y < 100; y++)
        {
            for (int x = 0; x < 100; x++)
            {
                float s = x / 99f;
                float v = y / 99f;
                svTexture.SetPixel(x, y, Color.HSVToRGB(hue, s, v));
            }
        }
        svTexture.Apply();
        svImage.texture = svTexture;
    }
}
