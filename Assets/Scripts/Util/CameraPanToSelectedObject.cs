using UnityEngine;
using System.Collections.Generic;
// pan camera
// https://stackoverflow.com/questions/69556558/how-to-pan-camera-to-the-clicked-3d-object-in-unity
public class CameraPanToSelectedObject : MonoBehaviour
{
    Vector3 groundCamOffset;
    Vector3 camTarget;
    Vector3 camSmoothDampV;

    private List<Vector3> camStartPositions = new List<Vector3>();
    // list1 https://zetcode.com/lang/csharp/collections/
    // list2 https://www.c-sharpcorner.com/article/c-sharp-list/
    //GameObject cam;
    public Camera cam;
    public GameObject[] hotspots;
    Ray ray;
    RaycastHit hit;
    public float panspeed;
    public string colliderTag;
    public bool clicked = false;
    public Vector3 tempCamTarget;
    public Vector3 tempCamPosition;

    private Vector3 GetWorldPosAtViewportPoint(float vx, float vy)
    {
        Ray worldRay = cam.ViewportPointToRay(new Vector3(vx, vy, 0));
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float distanceToGround;
        groundPlane.Raycast(worldRay, out distanceToGround);
        Debug.Log("distance to ground:" + distanceToGround);
        return worldRay.GetPoint(distanceToGround);
    }

    void Start()
    {
        Vector3 groundPos = GetWorldPosAtViewportPoint(0.5f, 0.5f);
        Debug.Log("groundPos: " + groundPos);
        groundCamOffset = cam.transform.position - groundPos;
        camTarget = cam.transform.position;

    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        /*
        if (Input.GetMouseButtonDown(1))
        {
            if (camStartPositions.Count > 0)
            {
                cam.transform.position = camStartPositions[camStartPositions.Count - 1];
                camStartPositions.RemoveAt(camStartPositions.Count - 1);
            }
            else
            {
                Debug.Log("no zoom out?");
            }
        }
        */
            if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                colliderTag = hit.collider.tag;
            }
        }


        if (Input.GetMouseButtonDown(0) && (( colliderTag == "Player") || (colliderTag== "panable"))  && clicked == false)
        {
            Debug.Log("pan!");
            // camStartPositions.Add(cam.transform.position);
            // Center whatever position is clicked
            float mouseX = Input.mousePosition.x / cam.pixelWidth;
            float mouseY = Input.mousePosition.y / cam.pixelHeight;
            Vector3 clickPt = GetWorldPosAtViewportPoint(mouseX, mouseY);
            camTarget = clickPt + groundCamOffset;
            clicked = true;

            tempCamTarget.x = float.Parse(camTarget.x.ToString("0.##"));
            tempCamTarget.y = float.Parse(camTarget.y.ToString("0.##"));
            tempCamTarget.z = float.Parse(camTarget.z.ToString("0.##"));

        }

        // Move the camera smoothly to the target position
        if (tempCamPosition != tempCamTarget && clicked == true)
        {
            cam.transform.position = Vector3.SmoothDamp(cam.transform.position, camTarget, ref camSmoothDampV, panspeed);
            tempCamPosition.x = float.Parse(cam.transform.position.x.ToString("0.##"));
            tempCamPosition.y = float.Parse(cam.transform.position.y.ToString("0.##"));
            tempCamPosition.z = float.Parse(cam.transform.position.z.ToString("0.##"));
        }
        else if (tempCamPosition == tempCamTarget)
        {
            clicked = false;
            colliderTag = "";
        }

    }
    void camSmoothDamp()
    {

    }
}