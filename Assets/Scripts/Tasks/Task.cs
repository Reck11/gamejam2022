using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour {

    public GameObject task;
    public GameObject door;
    public GameObject exclamationMark;

    public void StartTask() {
        task.SetActive(true);
    }
    public void EndTask() {
        GameObject.Destroy(exclamationMark);
        OpenDoor();
    }
    public void OpenDoor() {
        door.GetComponent<Door>().OpenDoor();
    }
}
