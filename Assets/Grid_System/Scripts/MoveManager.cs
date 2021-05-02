using System;
using UnityEngine;
using CodeMonkey.Utils;

namespace Grid_System.Scripts
{
    public class MoveManager : MonoBehaviour
    {
  
        [SerializeField]private Testing grid;
        private Testing localgrid;
        private int[,] gridArray;

        private void Start()
        {
            grid = GetComponent<Testing>();
            gridArray = grid.managerGrid.gridArray;
        }

        public void MoveDown()
                {
                    for (int i = 0; i < gridArray.GetLength(0); i++)
                    {
                        for (int j = 0; j < gridArray.GetLength(1); j++)
                        {
                            if ((j+1) < gridArray.GetLength(1))
                            {
                                if (grid.managerGrid.GetValue(i,j+1)==grid.managerGrid.GetValue(i,j))
                                {
                                    grid.managerGrid.SetValue(i,j,grid.managerGrid.GetValue(i,j+1)+grid.managerGrid.GetValue(i,j));
                                    grid.managerGrid.SetValue(i,j+1,0);
                                }
                                else if(grid.managerGrid.GetValue(i,j+1)!=grid.managerGrid.GetValue(i,j))
                                {
                                    if(grid.managerGrid.GetValue(i,j)==0)
                                    {
                                        grid.managerGrid.SetValue(i,j,grid.managerGrid.GetValue(i,j+1));
                                        grid.managerGrid.SetValue(i,j+1,0);
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            
            
                public void MoveUp()
                {
                    for (int i = 0; i < grid.managerGrid.gridArray.GetLength(0); i++)
                    {
                        for (int j = grid.managerGrid.gridArray.GetLength(1); j > 0; j--)
                        {
                            if ((j-1) >= 0)
                            {
                                if (grid.managerGrid.GetValue(i,j)==grid.managerGrid.GetValue(i,j-1))
                                {
                                    grid.managerGrid.SetValue(i,j,grid.managerGrid.GetValue(i,j)+grid.managerGrid.GetValue(i,j-1));
                                    grid.managerGrid.SetValue(i,j-1,0);
                                }
                                else if(grid.managerGrid.GetValue(i,j)!=grid.managerGrid.GetValue(i,j-1))
                                {
                                    if(grid.managerGrid.GetValue(i,j)==0 && j != grid.managerGrid.gridArray.GetLength(1))
                                    {
                                        grid.managerGrid.SetValue(i,j,grid.managerGrid.GetValue(i,j-1));
                                        grid.managerGrid.SetValue(i,j-1,0);
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
        
        
                public void MoveRight()
                {
                    for (int i = grid.managerGrid.gridArray.GetLength(0); i > 0; i--)
                    {
                        for (int j = 0; j < grid.managerGrid.gridArray.GetLength(1); j++)
                        {
                            if ((i-1)>=0)
                            {
                                if (grid.managerGrid.GetValue(i,j) == grid.managerGrid.GetValue(i-1,j))
                                {
                                    grid.managerGrid.SetValue(i,j,grid.managerGrid.GetValue(i,j) + grid.managerGrid.GetValue(i-1,j));
                                    grid.managerGrid.SetValue(i-1,j,0);
                                }
                                else if(grid.managerGrid.GetValue(i,j) != grid.managerGrid.GetValue(i-1,j))
                                {
                                    if (grid.managerGrid.GetValue(i,j) == 0 && i != grid.managerGrid.gridArray.GetLength(0))
                                    {
                                        grid.managerGrid.SetValue(i,j,grid.managerGrid.GetValue(i-1,j));
                                        grid.managerGrid.SetValue(i-1,j,0);
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
        
                public void MoveLeft()
                {
                    for (int i = 0; i < grid.managerGrid.gridArray.GetLength(0); i++)
                    {
                        for (int j = 0; j < grid.managerGrid.gridArray.GetLength(1); j++)
                        {
                            if (i+1 < grid.managerGrid.gridArray.GetLength(0))
                            {
                                if (grid.managerGrid.GetValue(i,j) == grid.managerGrid.GetValue(i+1,j))
                                {
                                    grid.managerGrid.SetValue(i,j,grid.managerGrid.GetValue(i,j)+grid.managerGrid.GetValue(i+1,j));
                                    grid.managerGrid.SetValue(i+1,j,0);
                                    // BG.SetBG(GetValue(i,j),i,j);
                                }
                                else if (grid.managerGrid.GetValue(i,j) != grid.managerGrid.GetValue(i+1,j))
                                {
                                    if (grid.managerGrid.GetValue(i,j) == 0)
                                    {
                                        grid.managerGrid.SetValue(i,j,grid.managerGrid.GetValue(i+1,j));
                                        grid.managerGrid.SetValue(i+1,j,0);
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
        
    }
}
