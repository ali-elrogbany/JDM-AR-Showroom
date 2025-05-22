using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaceableVehiclesManager : MonoBehaviour
{
    [Header("GO References")]
    [SerializeField] private AlteredARGestureInteractor alteredARGestureInteractor;

    [Header("SO References")]
    [SerializeField] private PlaceableVehiclesSO placeableVehiclesSO;

    [Header("UI References")]
    [SerializeField] private GameObject buttonParent;
    [SerializeField] private GameObject buttonPrefab;

    private void Awake()
    {
        alteredARGestureInteractor.SetPlaceableVehicleSO(placeableVehiclesSO);

        for (int i = 0; i < placeableVehiclesSO.objects.Count; i++)
        {
            int index = i;

            GameObject newButton = Instantiate(buttonPrefab);

            Button newButtonComponent = newButton.GetComponent<Button>();
            newButtonComponent.onClick.AddListener(() => alteredARGestureInteractor.SetPlaceableObject(index));

            TMP_Text newButtonText = newButton.GetComponentInChildren<TMP_Text>();
            newButtonText.text = placeableVehiclesSO.objects[i].name;

            newButton.transform.SetParent(buttonParent.transform);
        }

    }
}
