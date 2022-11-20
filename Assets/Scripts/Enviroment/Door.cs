using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    [SerializeField] private float openAmount;

    public void OpenDoor() {
        leftDoor.transform.Translate(new Vector2 (leftDoor.transform.position.x - openAmount, leftDoor.transform.position.y));
        rightDoor.transform.Translate(new Vector2(leftDoor.transform.position.x + openAmount, leftDoor.transform.position.y));
        GetComponent<Collider2D>().enabled = false;
    }
}
