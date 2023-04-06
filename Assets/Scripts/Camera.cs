using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Camera : MonoBehaviour {

    public Transform player;
    public float zoom;
    float xPos;
    public float vertOffset;
    public GameObject Top, Bottom;

    void Start () {
        xPos = transform.position.x;
    }

    // Update is called once per frame
    void Update () {
        Vector3 newPos = new Vector3(xPos, player.transform.position.y + vertOffset, 0);
        transform.position = newPos + new Vector3(0, 0, zoom);
    }
}