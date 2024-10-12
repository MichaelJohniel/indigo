using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimer : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private bool black;

    void OnMouseDown() {
        if (black == gm.black) {
            if (gm.selectedPoint != null) {
                if (gm.selectedPoint.occupant == null) {
                    gm.selectedPoint.PlaceStone();
                }
            }
        }
    }
}