
using UnityEngine;
using System.Collections;
using RDG;

public class GridAsset : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    [SerializeField] public GameObject occupant;
    [SerializeField] public int xID;
    [SerializeField] public int yID;
    [SerializeField] private GameObject whiteStone;
    [SerializeField] private GameObject blackStone;
    [SerializeField] private bool hovered = false;
    [SerializeField] public FollowCursor cursor;

    void OnMouseOver() {
        if (!hovered) {
            hovered = true;
            Vibration.Vibrate(50);

            if (cursor.soundCooldown <= 0) {
                cursor.tick.Play();
                cursor.soundCooldown = .05f;
            }
        }
    }

    void OnMouseExit() {
        hovered = false;
    }

    public void PlaceStone() {
        //Place Stone
        if (gameManager.GetComponent<GameManager>().lastCapLoc) {
            if (gameManager.GetComponent<GameManager>().lastCapLoc.gameObject != gameObject) {
                if (gameManager.GetComponent<GameManager>().black) {
                    //Orient and Create Stone
                    Quaternion orientation = Quaternion.identity;
                    orientation.eulerAngles = new Vector3(-90, 0, 0);
                    var stone = Instantiate(blackStone, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y), orientation);
                    stone.GetComponent<StoneAsset>().gridAsset = gameObject.GetComponent<GridAsset>();

                    //Set Stone Identifiers
                    stone.transform.parent = gameManager.transform.GetChild(0);
                    occupant = stone.gameObject;
                    stone.transform.name = "BlackStone " + xID + "." + yID;
                    stone.GetComponent<StoneAsset>().black = true;

                    //Check surroundings
                    gameManager.GetComponent<GameManager>().AssimilateStones(xID, yID);
                } else {
                    //Orient and Create Stone
                    Quaternion orientation = Quaternion.identity;
                    orientation.eulerAngles = new Vector3(-90, 0, 0);
                    var stone = Instantiate(whiteStone, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y), orientation);
                    stone.GetComponent<StoneAsset>().gridAsset = gameObject.GetComponent<GridAsset>();

                    //Set Stone Identifiers
                    stone.transform.parent = gameManager.transform.GetChild(0);
                    occupant = stone.gameObject;
                    stone.transform.name = "WhiteStone " + xID + "." + yID;
                    stone.GetComponent<StoneAsset>().black = false;

                    //Check surroundings
                    gameManager.GetComponent<GameManager>().AssimilateStones(xID, yID);
                }
             gameManager.GetComponent<GameManager>().lastCapLoc = null;
            }
        } else {
            if (gameManager.GetComponent<GameManager>().black) {
                //Orient and Create Stone
                Quaternion orientation = Quaternion.identity;
                orientation.eulerAngles = new Vector3(-90, 0, 0);
                var stone = Instantiate(blackStone, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y), orientation);
                stone.GetComponent<StoneAsset>().gridAsset = gameObject.GetComponent<GridAsset>();

                //Set Stone Identifiers
                stone.transform.parent = gameManager.transform.GetChild(0);
                occupant = stone.gameObject;
                stone.transform.name = "BlackStone " + xID + "." + yID;
                stone.GetComponent<StoneAsset>().black = true;

                //Check surroundings
                gameManager.GetComponent<GameManager>().AssimilateStones(xID, yID);
            } else {
                //Orient and Create Stone
                Quaternion orientation = Quaternion.identity;
                orientation.eulerAngles = new Vector3(-90, 0, 0);
                var stone = Instantiate(whiteStone, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y), orientation);
                stone.GetComponent<StoneAsset>().gridAsset = gameObject.GetComponent<GridAsset>();

                //Set Stone Identifiers
                stone.transform.parent = gameManager.transform.GetChild(0);
                occupant = stone.gameObject;
                stone.transform.name = "WhiteStone " + xID + "." + yID;
                stone.GetComponent<StoneAsset>().black = false;

                //Check surroundings
                gameManager.GetComponent<GameManager>().AssimilateStones(xID, yID);
            }
        }
    }
}