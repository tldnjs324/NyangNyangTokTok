using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{
    public GameObject[] Menu;
    public GameObject[] SelectedMenu;

    public List<Vector3> points = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        if (SpecifyNumber.MakingMenu[2] == 20)//메뉴가 2개일 때
        {
            points.Add(new Vector3(-2, 0, 0));
            points.Add(new Vector3(2, 0, 0));
        }else if(SpecifyNumber.MakingMenu[2]<20 && SpecifyNumber.MakingMenu[3] == 20)//메뉴가 3개일 때
        {
            points.Add(new Vector3(-4, 0, 0));
            points.Add(new Vector3(0, 0, 0));
            points.Add(new Vector3(4, 0, 0));
        }
        else//메뉴가 4개일 때
        {
            points.Add(new Vector3(-6, 0, 0));
            points.Add(new Vector3(-2, 0, 0));
            points.Add(new Vector3(2, 0, 0));
            points.Add(new Vector3(6, 0, 0));
        }

        

        for (int i = 0; i<4; i++)
        {
            for(int j = 0; j<20; j++)
            {
                if(SpecifyNumber.MakingMenu[i] == j)
                {
                    Menu[j].transform.position = points[i];
                    Menu[j].SetActive(true);
                }
                
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
