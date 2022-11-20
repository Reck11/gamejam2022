using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HotDog : MonoBehaviour
{
    private GraphicRaycaster raycaster;

    void Awake() {
        this.raycaster = GetComponent<GraphicRaycaster>();
    }
    void Update() {
        if (Input.GetButton(Axis.FIRE)) {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            List<RaycastResult> results = new List<RaycastResult>();

            pointerData.position = Input.mousePosition;
            this.raycaster.Raycast(pointerData, results);
            if (results.Count > 0 && results[0].gameObject.CompareTag("Sausage")) {
                RaycastResult result = results[0];
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition.z = 0;
                result.gameObject.transform.position = worldPosition;
            }
        }
    }
}
