using System.Collections;
using UnityEngine;

public class StoneAsset : MonoBehaviour
{
    [SerializeField] public GridAsset gridAsset;
    [SerializeField] public bool black;
    [SerializeField] public GameObject family;
    [SerializeField] public int liberties;

    public int CheckLiberties() {
        liberties = 4;

        if (gridAsset.gameManager.GetComponent<GameManager>().grid[gridAsset.xID-1,gridAsset.yID] != null) {
            if (gridAsset.gameManager.GetComponent<GameManager>().grid[gridAsset.xID-1,gridAsset.yID].GetComponent<GridAsset>().occupant) {
                liberties--;
            }
        } else {
            liberties--;
        }
        if (gridAsset.gameManager.GetComponent<GameManager>().grid[gridAsset.xID+1,gridAsset.yID] != null) {
            if (gridAsset.gameManager.GetComponent<GameManager>().grid[gridAsset.xID+1,gridAsset.yID].GetComponent<GridAsset>().occupant) {
                liberties--;
            }
        } else {
            liberties--;
        }
        if (gridAsset.gameManager.GetComponent<GameManager>().grid[gridAsset.xID,gridAsset.yID+1] != null) {
            if (gridAsset.gameManager.GetComponent<GameManager>().grid[gridAsset.xID,gridAsset.yID+1].GetComponent<GridAsset>().occupant) {
                liberties--;
            }
        } else {
            liberties--;
        }
        if (gridAsset.gameManager.GetComponent<GameManager>().grid[gridAsset.xID,gridAsset.yID-1] != null) {
            if (gridAsset.gameManager.GetComponent<GameManager>().grid[gridAsset.xID,gridAsset.yID-1].GetComponent<GridAsset>().occupant) {
                liberties--;
            }
        } else {
            liberties--;
        }

        return(liberties);
    }

    void OnDestroy() {
        gridAsset.occupant = null;
    }
}
