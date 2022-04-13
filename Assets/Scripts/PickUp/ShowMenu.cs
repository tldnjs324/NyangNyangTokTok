using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{
    public GameObject[] Menu;
    public GameObject[] SelectedMenu;


    // Start is called before the first frame update
    void Start()
    {
        SelectedMenu[0].transform.position = new Vector3(-6, 0, 0);
        SelectedMenu[1].transform.position = new Vector3(-2, 0, 0);
        SelectedMenu[3].transform.position = new Vector3(2, 0, 0);
        SelectedMenu[4].transform.position = new Vector3(6, 0, 0);
        for (int i = 0; i<4; i++)
        {
            for(int j = 0; j<20; j++)
            {
                if(SpecifyNumber.MakingMenu[i] == j)
                {
                    SelectedMenu[i] = Menu[j];
                    SelectedMenu[i].SetActive(true);
                }
                
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
