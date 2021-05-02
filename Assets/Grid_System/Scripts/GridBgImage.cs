using System;
using UnityEngine;
using CodeMonkey.Utils;

namespace Grid_System.Scripts
{
    public class GridBgImage : MonoBehaviour
    {
        //格子背景圖片，一張方形白色圖片
        [SerializeField] private SpriteRenderer BGimage;
        //儲存圖片陣列
        [SerializeField] private SpriteRenderer[,] srArray;

        [SerializeField] private GameManager GMgrid;
        private int[,] gridArray;

        //儲存盤面大小參數
        [SerializeField] private int row;
        [SerializeField] private int col;

        public void Start()
        {
            GMgrid = GetComponent<GameManager>();
            row = GMgrid.Getrow();
            col = GMgrid.Getcol();
            srArray = new SpriteRenderer[row, col];
            // gridArray = GMgrid.managerGrid.gridArray;

            for (int i = 0; i <row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    //將圖片布置到盤面
                    srArray[i,j]=Instantiate(BGimage, new Vector3((i*10)+5, (j*10)+5), Quaternion.identity);
                }
            }

            gridArray = GMgrid.grid.gridArray;
            SetBG();
        }

        /// <summary>
        /// 設定圖片顏色
        /// 掃描全部盤面根據數值給予相對應顏色
        /// </summary>
        public void SetBG()
      {
          for (int i = 0; i < gridArray.GetLength(0); i++)
          {
              for (int j = 0; j < gridArray.GetLength(1); j++)
              {
                  //儲存該格的數字
                  var value = gridArray[i, j];
                  switch (value)
                  {
                    case 1:
                        srArray[i,j].color = new Color32(79,154,247,250);
                        break;
                    case 2:
                        srArray[i,j].color = new Color32(68,188,212,230);
                        break;
                    case 4:
                        srArray[i,j].color = new Color32(87,235,198,250);
                        break;
                    case 8:
                        srArray[i,j].color = new Color32(68,212,115,225);
                        break;
                    case 16:
                        srArray[i,j].color = new Color32(107,240,88,253);
                        break;
                    case 32:
                        srArray[i,j].color = new Color32(174,125,250,254);
                        break;
                    case 64:
                        srArray[i,j].color = new Color32(184,111,222,241);
                        break;
                    case 128:
                        srArray[i,j].color = new Color32(238,134,245,250);
                        break;
                    case 256:
                        srArray[i,j].color = new Color32(222,111,180,243);
                        break;
                    case 512:
                        srArray[i,j].color = new Color32(250,125,141,254);
                        break;
                    case 1024:
                        srArray[i,j].color = new Color32(250,121,108,251);
                        break;
                    case 2048:
                        srArray[i,j].color = new Color32(222,125,95,248);
                        break;
                    case 4096:
                        srArray[i,j].color = new Color32(245,166,117,248);
                        break;
                    default:
                        srArray[i,j].color = Color.gray;
                        break;
                  }
              }
          }
      }
    }
}

