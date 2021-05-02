using System;
using System.Collections;
using System.Collections.Generic;
using Grid_System.Scripts;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;


public class RendomSpawnNumber : MonoBehaviour
{
    [SerializeField]private GameManager GMgrid;
    [SerializeField] private GridBgImage gridBgImage;

    [SerializeField]private int[,] gridArray;
    [SerializeField]private List<int> tempZeroArray;
    private List<int> tempxArray;
    private List<int> tempyArray;

    private void Start()
    {
        GMgrid = GetComponent<GameManager>();
        gridBgImage = GetComponent<GridBgImage>();
        tempZeroArray = new List<int>();
        tempxArray = new List<int>();
        tempyArray = new List<int>();
    }

    public void RendomSpawn()
    {
        if (GMgrid.grid.gridArray!=null)
        {
            for (int i = 0; i < GMgrid.grid.gridArray.GetLength(0); i++)
            {
                for (int j = 0; j < GMgrid.grid.gridArray.GetLength(1); j++)
                {
                    if (GMgrid.grid.gridArray[i,j]==0)
                    {

                        tempxArray.Add(i);
                        tempyArray.Add(j);
                    }
                }
            }
        }

        if (tempxArray.Count==0)
        {
            return;
        }

        Debug.Log("list count:"+tempZeroArray.Count);
        var temp = Random.Range(0, tempxArray.Count);
        GMgrid.grid.SetValue(tempxArray[temp],tempyArray[temp],2);
        Debug.Log("x:"+tempxArray[temp]+"y:"+tempyArray[temp]);
        tempxArray.Clear();
        tempyArray.Clear();
        gridBgImage.SetBG();

    }
}
