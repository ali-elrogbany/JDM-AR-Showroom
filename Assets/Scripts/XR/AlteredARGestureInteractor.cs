using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine.EventSystems;

public class AlteredARGestureInteractor : ARPlacementInteractable
{
    private PlaceableVehiclesSO placeableVehiclesSO;
    private bool hasPlacedObject = false;
    private GameObject placedGameObject;

    public void SetPlaceableVehicleSO(PlaceableVehiclesSO placeableVehiclesSO)
    {
        this.placeableVehiclesSO = placeableVehiclesSO;
    }

    protected override GameObject PlaceObject(Pose pose)
    {
        GameObject obj = base.PlaceObject(pose);
        placedGameObject = obj;
        return obj;
    }

    protected override void OnEndManipulation(TapGesture gesture)
    {
        if (IsPointerOverUI(gesture))
        {
            Debug.Log("Tap was over UI. Ignoring placement.");
            return;
        }
        
        if (!gesture.isCanceled && (!(base.xrOrigin == null) || !(base.arSessionOrigin == null)) && TryGetPlacementPose(gesture, out var pose))
        {
            if (!hasPlacedObject)
            {
                hasPlacedObject = true;
                base.OnEndManipulation(gesture);
            }
            else
            {
                Debug.Log("Object already placed. Ignoring further taps.");
                return;
            }
        }
        else
        {
            Debug.Log("Can't Place");
        }
    }

    private bool IsPointerOverUI(TapGesture gesture)
    {
        if (EventSystem.current == null)
            return false;

        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = gesture.startPosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }


    private void ResetComponent()
    {
        Destroy(placedGameObject);
        placedGameObject = null;

        hasPlacedObject = false;
    }

    public void SetPlaceableObject(int index)
    {
        GameObject obj = placeableVehiclesSO.objects[index];

        ResetComponent();

        placementPrefab = obj;
    }
}
