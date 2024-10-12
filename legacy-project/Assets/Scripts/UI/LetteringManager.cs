using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetteringManager : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private bool black;
    [SerializeField] private GameObject[] letterIndex;
    
    // Update is called once per frame
    void Update()
    {
        if ((gm.black && black) || (!gm.black && !black))
        for (int i = 0; i < 14; i++) {
            if (gm.selectedPoint != null) {
                if (gm.selectedPoint.xID == i) {
                    letterIndex[i].SetActive(true);
                } else {
                    letterIndex[i].SetActive(false);
                }
            } else {
                letterIndex[i].SetActive(false);
            }
        } else {
            for (int i = 0; i < 14; i++) {
                letterIndex[i].SetActive(false);
            }
        }
    }
}
