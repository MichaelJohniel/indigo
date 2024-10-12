using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RDG;

public class SplashMenu : MonoBehaviour
{
    [SerializeField] GameObject ui;
    [SerializeField] GameObject gm;
    [SerializeField] GameObject environment;
    [SerializeField] GameObject cursor;

    void OnMouseDown() {
        ui.SetActive(true);
        gm.SetActive(true);
        environment.SetActive(true);
        cursor.SetActive(true);
        Vibration.Vibrate(30);
        gameObject.SetActive(false);
    }
}
