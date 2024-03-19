using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExAccessControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int publicVlaue;

    private int privateValue;

    protected int protrnadValue;

    internal int internalValue;

    // Update is called once per frame
    void Update()
    {
        
    }
}
