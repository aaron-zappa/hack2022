using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlErForBool : TriggEr // , ITriggEr, IStartEr
{
    public bool b;
    public string boolString = "active";
    

    //public void SetGO(GameObject go) { this.go = go; }

    public override void StartIt()
    {
        if (boolString.Equals("active"))
        {
            b = go.activeInHierarchy;
        }
    }
    void setBool(bool b)
    {
        
    }

    void getBool()
    {
        
    }
    public void React()
    {
        if (boolString.Equals("active"))
        {
            go.SetActive(b); // .activeInHierarchy
        }
    }
    public override void TriggerIt()
    {
        Debug.Log("1trigger bool!" + b);
        b = !b;
        Debug.Log("2trigger bool!" + b);
        React();
    }
}
