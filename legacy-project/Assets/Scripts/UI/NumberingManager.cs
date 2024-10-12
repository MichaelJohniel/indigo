using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberingManager : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private bool black;
    [SerializeField] private GameObject[] numberIndex;
    
    // Update is called once per frame
    void Update()
    {
        if ((gm.black && black) || (!gm.black && !black))
        for (int i = 0; i < 14; i++) {
            if (gm.selectedPoint != null) {
                if (gm.selectedPoint.yID == i) {
                    numberIndex[i].SetActive(true);
                } else {
                    numberIndex[i].SetActive(false);
                }
            } else {
                numberIndex[i].SetActive(false);
            }
        } else {
            for (int i = 0; i < 14; i++) {
                numberIndex[i].SetActive(false);
            }
        }
    }
}
