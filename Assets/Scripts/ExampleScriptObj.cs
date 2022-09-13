// does scale a object by factor 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Scriptable", menuName = "Scriptable Objects/New SO", order = 51)]
public class ExampleScriptObj : ScriptableObject
{
    [SerializeField] private string _Name;
    [SerializeField] public GameObject GO_of_SRC;
    [SerializeField] public int factor;

    public void scale(int factor2)
    {
        Vector3 objectScale = GO_of_SRC.gameObject.transform.localScale;
        // the object identified by hit.transform was clicked
        GO_of_SRC.transform.localScale = new Vector3(objectScale.x * factor2, objectScale.y * factor2, objectScale.z * factor2);
    }
    public void scale() {
        scale(factor);
    }
    public void demo(){
    Debug.Log("ExampleScriptObj;demo;triggered");
        }
    
}
