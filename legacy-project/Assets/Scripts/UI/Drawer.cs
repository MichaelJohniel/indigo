using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RDG;

public class Drawer : MonoBehaviour
{
    [SerializeField] private bool open = false;
    [SerializeField] private Transform drawer;
    [SerializeField] private float targetY = 1.1f;
    [SerializeField] private AudioSource drawerNotification;
    [SerializeField] private AudioSource requestAccepted;
    [SerializeField] private AudioSource requestDenied;
    [SerializeField] private Drawer opponent;
    [SerializeField] public UndoRequest undoRequest;
    [SerializeField] private PassButton passButton;
    [SerializeField] private UndoButton undoButton;
    [SerializeField] private GameManager gm;
    [SerializeField] private bool black;
    [SerializeField] public int historyTurn;

    void OnMouseDown()
    {
        if (!open) {
            if (!undoRequest.gameObject.activeSelf) {
                Vibration.Vibrate(30);  
                open = true;
            }
        } else {
            Vibration.Vibrate(30);
            open = false;        
        }
    }

    void Update(){

        if (open) {
            targetY = 2.75f;
        } else {
            targetY = 0f;
        }

        drawer.localPosition = Vector3.Lerp(drawer.localPosition, new Vector3(drawer.localPosition.x, targetY, drawer.localPosition.z), .2f);

        if (undoButton.pressed) {
            if (!opponent.undoRequest.gameObject.activeSelf) {
                if (gm.historyTurn > 1) {
                    if ((!gm.black && black) || (gm.black && !black)) {
                        drawerNotification.Play();
                        opponent.open = false;
                        opponent.undoRequest.gameObject.SetActive(true);
                        opponent.historyTurn = gm.historyTurn;
                    }
                }
            }
            undoButton.pressed = false;
            targetY = 1.1f;
            open = false;
        }

        if (passButton.pressed) {
            if (gm.black == black) {
                gm.PassTurn();
            }
            passButton.pressed = false;
            targetY = 1.1f;
            open = false;
        }

        if (undoRequest.gameObject.activeSelf) {
            if (undoRequest.accept.pressed) {
                requestAccepted.Play();
                undoRequest.gameObject.SetActive(false);
                undoRequest.accept.pressed = false;

                if (historyTurn == gm.historyTurn) {
                    var stone = gm.grid[gm.historyX[historyTurn-1], gm.historyY[historyTurn-1]].GetComponent<GridAsset>().occupant.GetComponent<StoneAsset>();
                    Destroy(stone.gameObject);
                    
                    gm.lpMarker.transform.position = new Vector3 (gm.prevLastPlayedLocation.x, gm.prevLastPlayedLocation.y, gm.lpMarker.transform.position.z);
                    gm.historyTurn--;
                    if (historyTurn%2 == 0) {
                        gm.black = true;
                    } else {
                        gm.black = false;
                    }
                    historyTurn = -1;

                    
                }
            }
            if (undoRequest.deny.pressed) {
                requestDenied.Play();
                undoRequest.gameObject.SetActive(false);
                undoRequest.deny.pressed = false;
            }
        }
    }
}
