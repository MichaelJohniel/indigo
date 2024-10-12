using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RDG;

public class DenyRequest : MonoBehaviour
{
    [SerializeField] public bool pressed = false;
    
    void OnMouseDown() {
        pressed = true;
        Vibration.Vibrate(30);
    }

    void OnMouseUp() {
        pressed = false;
    }
}
