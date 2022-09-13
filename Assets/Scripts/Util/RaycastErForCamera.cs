using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//using VerifiErForTrigger;
// change scale
// https://clay-atlas.com/us/blog/2021/11/03/unity-change-obtain-game-object-scale/
// child objects
// https://gamedevplanet.com/various-ways-to-get-child-objects-in-unity/

public class RaycastErForCamera : MonoBehaviour
{
    public ExampleScriptObj exampleScriptObj;
    private string colliderTag;
    // Start is called before the first frame update
    void Start()
    {
        exampleScriptObj = ScriptableObject.CreateInstance<ExampleScriptObj>();
    }

 void Update(){
   if (Input.GetMouseButtonDown(0)){ // if left button pressed...
     Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
     RaycastHit hit;
     if (Physics.Raycast(ray, out hit)){
     GameObject hitObject = hit.transform.gameObject;
     colliderTag = hit.collider.tag;
     Debug.Log(colliderTag);

    exampleScriptObj.demo();
    exampleScriptObj.GO_of_SRC = hitObject;
    if ((colliderTag .Equals( "panable"))) {; }
    else
                {
                    exampleScriptObj.scale();
                }
                /*
                Vector3 objectScale = hitObject.gameObject.transform.localScale;
                  // the object identified by hit.transform was clicked
                hitObject.gameObject.transform.localScale = new Vector3(objectScale.x*2,  objectScale.y*2, objectScale.z*2);
                  //    scriptableObject.Awake();
                */
     }
   }
 }
}
/*
// Gets the local scale of game object
vector3 objectScale = transform.localScale;


// Sets the local scale of game object
transform.localScale = new Vector3(objectScale.x*2,  objectScale.y*2, objectScale.z*2);
*/