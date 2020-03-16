using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackendlessAPI;

public class backend : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var x = Backendless.Data.Of("Users").Find();
        foreach (Dictionary<string, dynamic> item in x)
        {
            foreach (KeyValuePair<string, dynamic> items in item)
            {
                if (items.Value != null)
                {
                    print(items.Value);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
