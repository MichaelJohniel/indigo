using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horGridManager : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject[] gridIndex;
    
    // Update is called once per frame
    void LateUpdate()
    {
        for (int i = 0; i < 14; i++) {
            if (gm.selectedPoint != null) {
                if (gm.selectedPoint.yID == i) {
                    gridIndex[i].SetActive(true);
                } else {
                    gridIndex[i].SetActive(false);
                }
            } else {
                gridIndex[i].SetActive(false);
            }
        }
    }
}
