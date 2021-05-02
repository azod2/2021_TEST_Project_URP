using System;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.Serialization;

namespace Grid_System.Scripts
{
    public class MoveManager : MonoBehaviour
    {
  
        [SerializeField]private GameManager GMgrid;
        private int[,] gridArray;

        private void Start()
        {
            GMgrid = GetComponent<GameManager>();
            gridArray = GMgrid.grid.gridArray;  //縮短要打的字&&方便日後修改

        }


        public void MoveDown()
                {
                    for (int i = 0; i < gridArray.GetLength(0); i++)
                    {
                        for (int j = 0; j < gridArray.GetLength(1); j++)
                        {
                            if ((j+1) < gridArray.GetLength(1))
                            {
                                //判斷要過去的方向的數字是否跟當前格子的數字一樣，如果一樣就相加，不一樣就不動
                                if (GMgrid.grid.GetValue(i,j+1)==GMgrid.grid.GetValue(i,j))
                                {
                                    GMgrid.grid.SetValue(i,j,GMgrid.grid.GetValue(i,j+1)+GMgrid.grid.GetValue(i,j));
                                    GMgrid.grid.SetValue(i,j+1,0);
                                }
                                else if(GMgrid.grid.GetValue(i,j+1)!=GMgrid.grid.GetValue(i,j))
                                {
                                    if(GMgrid.grid.GetValue(i,j)==0)
                                    {
                                        GMgrid.grid.SetValue(i,j,GMgrid.grid.GetValue(i,j+1));
                                        GMgrid.grid.SetValue(i,j+1,0);
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
                    for (int i = 0; i < GMgrid.grid.gridArray.GetLength(0); i++)
                    {
                        for (int j = GMgrid.grid.gridArray.GetLength(1); j > 0; j--)
                        {
                            if ((j-1) >= 0)
                            {
                                if (GMgrid.grid.GetValue(i,j)==GMgrid.grid.GetValue(i,j-1))
                                {
                                    GMgrid.grid.SetValue(i,j,GMgrid.grid.GetValue(i,j)+GMgrid.grid.GetValue(i,j-1));
                                    GMgrid.grid.SetValue(i,j-1,0);
                                }
                                else if(GMgrid.grid.GetValue(i,j)!=GMgrid.grid.GetValue(i,j-1))
                                {
                                    if(GMgrid.grid.GetValue(i,j)==0 && j != GMgrid.grid.gridArray.GetLength(1))
                                    {
                                        GMgrid.grid.SetValue(i,j,GMgrid.grid.GetValue(i,j-1));
                                        GMgrid.grid.SetValue(i,j-1,0);
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
                    for (int i = GMgrid.grid.gridArray.GetLength(0); i > 0; i--)
                    {
                        for (int j = 0; j < GMgrid.grid.gridArray.GetLength(1); j++)
                        {
                            if ((i-1)>=0)
                            {
                                if (GMgrid.grid.GetValue(i,j) == GMgrid.grid.GetValue(i-1,j))
                                {
                                    GMgrid.grid.SetValue(i,j,GMgrid.grid.GetValue(i,j) + GMgrid.grid.GetValue(i-1,j));
                                    GMgrid.grid.SetValue(i-1,j,0);
                                }
                                else if(GMgrid.grid.GetValue(i,j) != GMgrid.grid.GetValue(i-1,j))
                                {
                                    if (GMgrid.grid.GetValue(i,j) == 0 && i != GMgrid.grid.gridArray.GetLength(0))
                                    {
                                        GMgrid.grid.SetValue(i,j,GMgrid.grid.GetValue(i-1,j));
                                        GMgrid.grid.SetValue(i-1,j,0);
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
                    for (int i = 0; i < GMgrid.grid.gridArray.GetLength(0); i++)
                    {
                        for (int j = 0; j < GMgrid.grid.gridArray.GetLength(1); j++)
                        {
                            if (i+1 < GMgrid.grid.gridArray.GetLength(0))
                            {
                                if (GMgrid.grid.GetValue(i,j) == GMgrid.grid.GetValue(i+1,j))
                                {
                                    GMgrid.grid.SetValue(i,j,GMgrid.grid.GetValue(i,j)+GMgrid.grid.GetValue(i+1,j));
                                    GMgrid.grid.SetValue(i+1,j,0);
                                    // BG.SetBG(GetValue(i,j),i,j);
                                }
                                else if (GMgrid.grid.GetValue(i,j) != GMgrid.grid.GetValue(i+1,j))
                                {
                                    if (GMgrid.grid.GetValue(i,j) == 0)
                                    {
                                        GMgrid.grid.SetValue(i,j,GMgrid.grid.GetValue(i+1,j));
                                        GMgrid.grid.SetValue(i+1,j,0);
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
