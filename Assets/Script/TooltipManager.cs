using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{

    public GameObject TooltipThunder;
    public GameObject TooltipFriend;


    // Start is called before the first frame update
    void Start()
    {
        TooltipThunder.SetActive(false);
        TooltipFriend.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePosition = Input.mousePosition;
            //Debug.Log(mousePosition);
            
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out var info, 1000))
            {
                if (info.collider.gameObject.name == "Test")
                {
                    //yo code
                    TooltipThunder.SetActive(true);
                }
            }
        }

    }
}
