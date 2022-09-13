using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// click handling
//https://answers.unity.com/questions/332085/how-do-you-make-an-object-respond-to-a-click-in-c.html // initial
//https://gamedevbeginner.com/raycasts-in-unity-made-easy/#raycast_hit // solid

public class MovErBackForth : MonoBehaviour
{
    
    public float speed    = 2;
    public int   switchAt = 32;
    public float factor   = 0.5f;
    public int cyclesMax; // = 0;
    private int step=0;
    private int cycle =0;
    public  string directionURF ="R";
    private Vector3 myTransform ;
    private bool cont=true;
    // Start is called before the first frame update
    void Start()
    {
    step=switchAt/2;
    myTransform = transform.right;
    
    if (directionURF.Equals("F")) { myTransform = transform.forward; };
    if (directionURF.Equals("R")) { myTransform = transform.right;};
    if (directionURF.Equals("U")) { myTransform = transform.up ; };
    // first step triggers first cycle ?
    
    }

    // Update is called once per frame
    void Update()
    {
        step = (step+1) % switchAt;
        if (step== switchAt-1) { 
            speed=-speed;
            cycle++;
        }
      cont = cont && (cycle <= cyclesMax);
      if (cont) {
            // Moves an object, relative to its own rotation.
            //Debug.Log("upd step:" + step + " cycle:" + cycle);
            transform.position += myTransform * (speed*factor) * Time.deltaTime;
    } // cont
   
    }
}
