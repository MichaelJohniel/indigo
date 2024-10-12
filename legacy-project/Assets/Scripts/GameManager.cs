using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int gWidth, gHeight;
    [SerializeField] private GridAsset gAsset;
    [SerializeField] private FamilyAsset fAsset;
    [SerializeField] private AudioSource placeStoneAudio;
    [SerializeField] private AudioSource passTurnAudio;
    [HideInInspector] public bool black;
    [HideInInspector] public GameObject[,] grid;
    [HideInInspector] public GridAsset lastCapLoc;
    [HideInInspector] public GridAsset selectedPoint;
    [HideInInspector] private int bc = 0;
    [HideInInspector] private int wc = 0;
    [HideInInspector] public Vector3 prevLastPlayedLocation;
    [HideInInspector] public GridAsset lastPlayedLocation;
    [SerializeField] public GameObject lpMarker;
    [SerializeField] private Sprite playerIndicatorOn;
    [SerializeField] private Sprite playerIndicatorOff;
    [SerializeField] private SpriteRenderer blackTeam;
    [SerializeField] private SpriteRenderer whiteTeam;
    [SerializeField] private Timer blackTimer;
    [SerializeField] private Timer whiteTimer;
    [SerializeField] private TextMesh bct;
    [SerializeField] private TextMesh wct;
    [SerializeField] private FollowCursor cursor;
    

    [SerializeField] public int historyTurn = 1;
    [SerializeField] public int[] historyX;
    [SerializeField] public int[] historyY;
     
     void Start() {
         grid = new GameObject[gWidth+2,gHeight+2];
         GenerateGrid13x13();
         black = true;
     }

    #region
    void GenerateGrid19x19() {
         for (int x = 0; x < gWidth; x++) {
             for (int y = 0; y < gHeight; y++) {
                 var spawnGAsset = Instantiate(gAsset, new Vector3(x*.67f, y*.67f), Quaternion.identity).GetComponent<GridAsset>();
                 var gridView = spawnGAsset.transform.GetChild(0);
                 
                 spawnGAsset.transform.name = (x+1) + "." + (y+1);
                 spawnGAsset.transform.parent = gameObject.transform;
                 spawnGAsset.gameManager = gameObject;
                 spawnGAsset.transform.localScale = new Vector3(.67f,.67f,spawnGAsset.transform.localScale.z);
                 spawnGAsset.xID = x+1;
                 spawnGAsset.yID = y+1;
                 spawnGAsset.cursor = cursor;
                 grid[x+1,y+1] = spawnGAsset.gameObject;

                 if (spawnGAsset.xID == 1) {
                     gridView.GetChild(3).gameObject.SetActive(false);
                 }
                 if (spawnGAsset.xID == 19) {
                     gridView.GetChild(2).gameObject.SetActive(false);
                 }
                 if (spawnGAsset.yID == 1) {
                     gridView.GetChild(1).gameObject.SetActive(false);
                 }
                 if (spawnGAsset.yID == 19) {
                     gridView.GetChild(0).gameObject.SetActive(false);
                 }

                 if ((spawnGAsset.xID == 4 && spawnGAsset.yID == 4) || (spawnGAsset.xID == 4 && spawnGAsset.yID == 16) || 
                    (spawnGAsset.xID == 4 && spawnGAsset.yID == 10) || (spawnGAsset.xID == 16 && spawnGAsset.yID == 10) ||
                    (spawnGAsset.xID == 10 && spawnGAsset.yID == 4) || (spawnGAsset.xID == 10 && spawnGAsset.yID == 16) || 
                    (spawnGAsset.xID == 16 && spawnGAsset.yID == 16) || (spawnGAsset.xID == 16 && spawnGAsset.yID == 4) ||
                    (spawnGAsset.xID == 10 && spawnGAsset.yID == 10)) {
                     gridView.GetChild(4).gameObject.SetActive(true);
                 }
             }
         }
     }

     void GenerateGrid13x13() {
         for (int x = 0; x < gWidth; x++) {
             for (int y = 0; y < gHeight; y++) {
                 var spawnGAsset = Instantiate(gAsset, new Vector3(x, y), Quaternion.identity).GetComponent<GridAsset>();
                 var gridView = spawnGAsset.transform.GetChild(0);
                 
                 spawnGAsset.transform.name = (x+1) + "." + (y+1);
                 spawnGAsset.transform.parent = gameObject.transform;
                 spawnGAsset.gameManager = gameObject;
                 spawnGAsset.xID = x+1;
                 spawnGAsset.yID = y+1;
                 spawnGAsset.cursor = cursor;
                 grid[x+1,y+1] = spawnGAsset.gameObject;

                 if (spawnGAsset.xID == 1) {
                     gridView.GetChild(3).gameObject.SetActive(false);
                 }
                 if (spawnGAsset.xID == 13) {
                     gridView.GetChild(2).gameObject.SetActive(false);
                 }
                 if (spawnGAsset.yID == 1) {
                     gridView.GetChild(1).gameObject.SetActive(false);
                 }
                 if (spawnGAsset.yID == 13) {
                     gridView.GetChild(0).gameObject.SetActive(false);
                 }

                 if ((spawnGAsset.xID == 4 && spawnGAsset.yID == 4) || (spawnGAsset.xID == 4 && spawnGAsset.yID == 10) || 
                    (spawnGAsset.xID == 10 && spawnGAsset.yID == 10) || (spawnGAsset.xID == 10 && spawnGAsset.yID == 4) ||
                    (spawnGAsset.xID == 7 && spawnGAsset.yID == 7)) {
                     gridView.GetChild(4).gameObject.SetActive(true);
                 }
             }
         }
     }

     void GenerateGrid9x9() {
         for (int x = 0; x < gWidth; x++) {
             for (int y = 0; y < gHeight; y++) {
                 var spawnGAsset = Instantiate(gAsset, new Vector3(x*1.5f, y*1.5f), Quaternion.identity).GetComponent<GridAsset>();
                 var gridView = spawnGAsset.transform.GetChild(0);
                 
                 spawnGAsset.transform.name = (x+1) + "." + (y+1);
                 spawnGAsset.transform.parent = gameObject.transform;
                 spawnGAsset.gameManager = gameObject;
                 spawnGAsset.transform.localScale = new Vector3(1.5f,1.5f,spawnGAsset.transform.localScale.z);
                 spawnGAsset.xID = x+1;
                 spawnGAsset.yID = y+1;
                 spawnGAsset.cursor = cursor;
                 grid[x+1,y+1] = spawnGAsset.gameObject;

                 if (spawnGAsset.xID == 1) {
                     gridView.GetChild(3).gameObject.SetActive(false);
                 }
                 if (spawnGAsset.xID == 9) {
                     gridView.GetChild(2).gameObject.SetActive(false);
                 }
                 if (spawnGAsset.yID == 1) {
                     gridView.GetChild(1).gameObject.SetActive(false);
                 }
                 if (spawnGAsset.yID == 9) {
                     gridView.GetChild(0).gameObject.SetActive(false);
                 }

                 if ((spawnGAsset.xID == 3 && spawnGAsset.yID == 3) || (spawnGAsset.xID == 3 && spawnGAsset.yID == 7) || 
                    (spawnGAsset.xID == 7 && spawnGAsset.yID == 7) || (spawnGAsset.xID == 7 && spawnGAsset.yID == 3) ||
                    (spawnGAsset.xID == 5 && spawnGAsset.yID == 5)) {
                     gridView.GetChild(4).gameObject.SetActive(true);
                 }
             }
         }
     }
     #endregion
     
     void Update() {
         if (Input.GetKey("escape")) {
             Application.Quit();
         }
         if (Input.GetKey("r")) {
             Debug.Log(".");
             SceneManager.LoadScene( SceneManager.GetActiveScene().name);
         }

         if (black) {
             blackTeam.sprite = playerIndicatorOn;
             whiteTeam.sprite = playerIndicatorOff;
         } else {
             blackTeam.sprite = playerIndicatorOff;
             whiteTeam.sprite = playerIndicatorOn;
         }
     }

     public void PassTurn() {
        passTurnAudio.Play();
        lastPlayedLocation = null;
        lpMarker.transform.position = new Vector3 (-10, -10, lpMarker.transform.position.z);
        if (black) {
                blackTimer.isOn = false;
                whiteTimer.isOn = true;
        } else {
            blackTimer.isOn = true;
            whiteTimer.isOn = false;  
        }
        black = !black;

        historyTurn++;
     }

     public void AssimilateStones(int x, int y) {
         var stone = grid[x,y].GetComponent<GridAsset>().occupant.GetComponent<StoneAsset>();

         //Left Adjacent Stone
         if (grid[x-1,y] != null) {
             if (grid[x-1,y].GetComponent<GridAsset>().occupant) {
                 var leftStone = grid[x-1,y].GetComponent<GridAsset>().occupant.GetComponent<StoneAsset>();
                 //Check if adjacent stone is the same color
                 if (leftStone.black == stone.black) {
                     //Create or Join Family Cluster
                     if (!stone.family) {
                         if (leftStone.family) {
                             var family = leftStone.family;
                             stone.family = family;
                             stone.transform.parent = family.transform;
                         } else {
                             var family = Instantiate(fAsset, new Vector3(x,y), Quaternion.identity);
                            family.transform.parent = gameObject.transform.GetChild(0);
                            family.transform.name = "Cluster";

                            stone.family = family.gameObject;
                            stone.transform.parent = family.transform;
                            leftStone.family = family.gameObject;
                            leftStone.transform.parent = family.transform;
                         }
                     }
                 } else {
                     //Update Liberties
                     if (leftStone.family) {
                        int familyLiberties = 0;
                        int stonesCaptured = 0;
                        foreach (Transform xStone in leftStone.family.transform) {
                            familyLiberties += xStone.GetComponent<StoneAsset>().CheckLiberties();
                            stonesCaptured++;
                        }
                        if (familyLiberties <= 0) {
                            leftStone.gridAsset.occupant = null;
                            if (black) {
                                wc += stonesCaptured;
                                wct.text = wc.ToString();
                            } else {
                                bc += stonesCaptured;
                                bct.text = bc.ToString();
                            }
                            Destroy(leftStone.family);
                        }
                    } else {
                        if (leftStone.CheckLiberties() == 0) {
                            lastCapLoc = leftStone.gridAsset;
                            leftStone.gridAsset.occupant = null;
                            if (black) {
                                wc++;
                                wct.text = wc.ToString();
                            } else {
                                bc++;
                                bct.text = bc.ToString();
                            }
                            Destroy(leftStone.gameObject);
                        }
                    }
                 }
             }
         }


         //Right Adjacent Stone
         if (grid[x+1,y] != null) {
             if (grid[x+1,y].GetComponent<GridAsset>().occupant) {
                 var rightStone = grid[x+1,y].GetComponent<GridAsset>().occupant.GetComponent<StoneAsset>();
                 //Check if adjacent stone is the same color
                 if (rightStone.black == stone.black) {
                     //Create or Join Family Cluster
                     if (!stone.family) {
                         if (rightStone.family) {
                             var family = rightStone.family;
                             stone.family = family;
                             stone.transform.parent = family.transform;
                         } else {
                             var family = Instantiate(fAsset, new Vector3(x,y), Quaternion.identity);
                            family.transform.parent = gameObject.transform.GetChild(0);
                            family.transform.name = "Cluster";

                            stone.family = family.gameObject;
                            stone.transform.parent = family.transform;
                            rightStone.family = family.gameObject;
                            rightStone.transform.parent = family.transform;
                         }
                     } else {
                         if (rightStone.family) {
                             //Combine families
                             if (rightStone.family != stone.family) {
                                int stones = rightStone.family.transform.childCount;
                                GameObject oldFamily = rightStone.family;

                                for (int i = 0; i < stones; i++) {
                                    var stranger = oldFamily.transform.GetChild(0);
                                    stranger.GetComponent<StoneAsset>().family = stone.family;
                                    stranger.transform.parent = stone.family.transform;
                                }
                                Destroy(oldFamily);
                             }
                         } else {
                             var family = stone.family;
                             rightStone.family = family;
                             rightStone.transform.parent = family.transform;
                         }
                     } 
                 } else {
                     //Update Liberties
                     if (rightStone.family) {
                        int familyLiberties = 0;
                        int stonesCaptured = 0;
                        foreach (Transform xStone in rightStone.family.transform) {
                            familyLiberties += xStone.GetComponent<StoneAsset>().CheckLiberties();
                            stonesCaptured++;
                        }
                        if (familyLiberties <= 0) {
                            rightStone.gridAsset.occupant = null;
                            if (black) {
                                wc += stonesCaptured;
                                wct.text = wc.ToString();
                            } else {
                                bc += stonesCaptured;
                                bct.text = bc.ToString();
                            }
                            Destroy(rightStone.family);
                        }
                    } else {
                        if (rightStone.CheckLiberties() == 0) {
                            lastCapLoc = rightStone.gridAsset;
                            rightStone.gridAsset.occupant = null;
                            if (black) {
                                wc++;
                                wct.text = wc.ToString();
                            } else {
                                bc++;
                                bct.text = bc.ToString();
                            }
                            Destroy(rightStone.gameObject);
                        }
                    }
                 }
             }
         }

        //Top Adjacent Stone
         if (grid[x,y+1] != null) {
             if (grid[x,y+1].GetComponent<GridAsset>().occupant) {
                 var topStone = grid[x,y+1].GetComponent<GridAsset>().occupant.GetComponent<StoneAsset>();
                 //Check if adjacent stone is the same color
                 if (topStone.black == stone.black) {
                     //Create or Join Family Cluster
                     if (!stone.family) {
                         if (topStone.family) {
                             var family = topStone.family;
                             stone.family = family;
                             stone.transform.parent = family.transform;
                         } else {
                             var family = Instantiate(fAsset, new Vector3(x,y), Quaternion.identity);
                            family.transform.parent = gameObject.transform.GetChild(0);
                            family.transform.name = "Cluster";

                            stone.family = family.gameObject;
                            stone.transform.parent = family.transform;
                            topStone.family = family.gameObject;
                            topStone.transform.parent = family.transform;
                         }
                     } else {
                         if (topStone.family) {
                             //Combine families
                             if (topStone.family != stone.family) {
                                int stones = topStone.family.transform.childCount;
                                GameObject oldFamily = topStone.family;

                                for (int i = 0; i < stones; i++) {
                                    var stranger = oldFamily.transform.GetChild(0);
                                    stranger.GetComponent<StoneAsset>().family = stone.family;
                                    stranger.transform.parent = stone.family.transform;
                                }
                                Destroy(oldFamily);
                             }
                         } else {
                             var family = stone.family;
                             topStone.family = family;
                             topStone.transform.parent = family.transform;
                         }
                     }
                 } else {
                     //Update Liberties
                     if (topStone.family) {
                        int familyLiberties = 0;
                        int stonesCaptured = 0;
                        foreach (Transform xStone in topStone.family.transform) {
                            familyLiberties += xStone.GetComponent<StoneAsset>().CheckLiberties();
                            stonesCaptured++;
                        }
                        if (familyLiberties <= 0) {
                            topStone.gridAsset.occupant = null;
                            if (black) {
                                wc += stonesCaptured;
                                wct.text = wc.ToString();
                            } else {
                                bc += stonesCaptured;
                                bct.text = bc.ToString();
                            }
                            Destroy(topStone.family);
                        }
                    } else {
                        if (topStone.CheckLiberties() == 0) {
                            lastCapLoc = topStone.gridAsset;
                            topStone.gridAsset.occupant = null;
                            if (black) {
                                wc++;
                                wct.text = wc.ToString();
                            } else {
                                bc++;
                                bct.text = bc.ToString();
                            }
                            Destroy(topStone.gameObject);
                        }
                    }
                 }
             }
         }

         //Bottom Adjacent Stone
         if (grid[x,y-1] != null) {
             if (grid[x,y-1].GetComponent<GridAsset>().occupant) {
                 var bottomStone = grid[x,y-1].GetComponent<GridAsset>().occupant.GetComponent<StoneAsset>();
                 //Check if adjacent stone is the same color
                 if (bottomStone.black == stone.black) {
                     //Create or Join Family Cluster
                     if (!stone.family) {
                         if (bottomStone.family) {
                             var family = bottomStone.family;
                             stone.family = family;
                             stone.transform.parent = family.transform;
                         } else {
                             var family = Instantiate(fAsset, new Vector3(x,y), Quaternion.identity);
                            family.transform.parent = gameObject.transform.GetChild(0);
                            family.transform.name = "Cluster";

                            stone.family = family.gameObject;
                            stone.transform.parent = family.transform;
                            bottomStone.family = family.gameObject;
                            bottomStone.transform.parent = family.transform;
                         }
                     } else {
                         if (bottomStone.family) {
                             //Combine families
                             if (bottomStone.family != stone.family) {
                                int stones = bottomStone.family.transform.childCount;
                                GameObject oldFamily = bottomStone.family;

                                for (int i = 0; i < stones; i++) {
                                    var stranger = oldFamily.transform.GetChild(0);
                                    stranger.GetComponent<StoneAsset>().family = stone.family;
                                    stranger.transform.parent = stone.family.transform;
                                }
                                Destroy(oldFamily);
                             }
                         } else {
                             var family = stone.family;
                             bottomStone.family = family;
                             bottomStone.transform.parent = family.transform;
                         }
                     }
                 } else {
                     //Update Liberties
                     if (bottomStone.family) {
                        int familyLiberties = 0;
                        int stonesCaptured = 0;
                        foreach (Transform xStone in bottomStone.family.transform) {
                            familyLiberties += xStone.GetComponent<StoneAsset>().CheckLiberties();
                            stonesCaptured++;
                        }
                        if (familyLiberties <= 0) {
                            bottomStone.gridAsset.occupant = null;
                            if (black) {
                                wc += stonesCaptured;
                                wct.text = wc.ToString();
                            } else {
                                bc += stonesCaptured;
                                bct.text = bc.ToString();
                            }
                            Destroy(bottomStone.family);
                        }
                    } else {
                        if (bottomStone.CheckLiberties() == 0) {
                            lastCapLoc = bottomStone.gridAsset;
                            bottomStone.gridAsset.occupant = null;
                            if (black) {
                                wc++;
                                wct.text = wc.ToString();
                            } else {
                                bc++;
                                bct.text = bc.ToString();
                            }
                            Destroy(bottomStone.gameObject);
                        }
                    }
                 }
             }
         }

         //Check if valid and change turns
        if (!stone.family) {
            if (stone.GetComponent<StoneAsset>().CheckLiberties() <= 0) {
                Destroy(stone.gameObject);
            } else {
                placeStoneAudio.Play();
                prevLastPlayedLocation = lpMarker.transform.position;
                lastPlayedLocation = stone.gridAsset;
                lpMarker.transform.position = new Vector3 (lastPlayedLocation.transform.position.x, lastPlayedLocation.transform.position.y, lpMarker.transform.position.z);
                if (black) {
                    blackTimer.isOn = false;
                    whiteTimer.isOn = true;
                } else {
                    blackTimer.isOn = true;
                    whiteTimer.isOn = false;  
                }
                black = !black;
                historyX[historyTurn] = x;
                historyY[historyTurn] = y;
                historyTurn++;
            }
        } else if (stone.family) {
            int familyLiberties = 0;
            foreach (Transform xStone in stone.family.transform) {
                familyLiberties += xStone.GetComponent<StoneAsset>().CheckLiberties();
            }
            if (familyLiberties <= 0) {
                Destroy(stone.gameObject);
            } else {
            placeStoneAudio.Play();
            prevLastPlayedLocation = lpMarker.transform.position;
            lastPlayedLocation = stone.gridAsset;
            lpMarker.transform.position = new Vector3 (lastPlayedLocation.transform.position.x, lastPlayedLocation.transform.position.y, lpMarker.transform.position.z);
            if (black) {
                    blackTimer.isOn = false;
                    whiteTimer.isOn = true;
                } else {
                    blackTimer.isOn = true;
                    whiteTimer.isOn = false;  
                }
            }
            black = !black;
            historyX[historyTurn] = x;
            historyY[historyTurn] = y;
            historyTurn++;
        }
    }
}