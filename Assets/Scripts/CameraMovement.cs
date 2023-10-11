using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float smoothing;
    public Vector3 offset;
    public Transform target;

    // Wird nach Update aufgerufen
    private void LateUpdate() {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothing * Time.deltaTime); // Kamera folgt Spieler relativ schnell zur Entfernung
    }
}