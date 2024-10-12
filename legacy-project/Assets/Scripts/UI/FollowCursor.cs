using System.Collections;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;
    [SerializeField] private float handZoom;
    [SerializeField] private Sprite blackCursor;
    [SerializeField] private Sprite whiteCursor;
    [SerializeField] private SpriteRenderer cursor;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private RaycastHit gridHit;
    [SerializeField] private RaycastHit boardHit; 
    [SerializeField] private LayerMask gridLayerMask;
    [SerializeField] private LayerMask boardLayerMask;
    [SerializeField] private bool follow;
    [SerializeField] public AudioSource tick;
    public float soundCooldown;

    void Start() {
        Cursor.visible = true;
        follow = true;
    }

    void Update()
    {
        if (Input.GetKeyDown("o")) {
            Cursor.visible = !Cursor.visible;
        }

        if (Input.GetMouseButtonDown(1)) {
            follow = !follow;
        }

        //Get GridAsset
        //if (Physics.Linecast(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z+5f), out RaycastHit gridHit, gridLayerMask))
        //{
            //gameManager.selectedPoint = gridHit.transform.GetComponent<GridAsset>();

            //gameObject.transform.position = new Vector3 (gridHit.transform.position.x, gridHit.transform.position.y, gameObject.transform.position.z);
        //} else {
            //gameManager.selectedPoint = null;

            //gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        //}

        //Follow Cursor if within position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (follow) {
            if (Physics.Raycast(ray, out RaycastHit gridHit, 100f, gridLayerMask))
            {
                //Vector3 mousePos = Input.mousePosition;
                //mousePos.z = handZoom;
                //gameObject.transform.position = Vector3.Lerp( gameObject.transform.position, (mainCamera.ScreenToWorldPoint(mousePos)), .5f);
                gameManager.selectedPoint = gridHit.transform.GetComponent<GridAsset>();
                gameObject.transform.position = new Vector3 (gridHit.transform.position.x, gridHit.transform.position.y, gameObject.transform.position.z);
            }
        }

        //if (gameManager.black) {
        //    cursor.sprite = blackCursor;
        //} else {
        //    cursor.sprite = whiteCursor;
        //}

        soundCooldown -= Time.deltaTime;
        if (soundCooldown <= 0) {
            soundCooldown = 0;
        }
    }
}
