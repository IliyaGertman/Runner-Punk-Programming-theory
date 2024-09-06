using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SirenScript : MonoBehaviour

{

    public static SirenScript instance;
    // Start is called before the first frame update
    private void Awake() 
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance!=this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
