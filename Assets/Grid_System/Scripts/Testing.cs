using System;
using System.Collections.Generic;
using CodeMonkey.Utils;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

namespace Grid_System.Scripts
{
  public class Testing : MonoBehaviour
  {
      
      [SerializeField]private Grid grid;
      [SerializeField] public Grid managerGrid;
      [SerializeField]private MoveManager moveManager;
      public SpriteRenderer sr;
      public GridBgSetting BgSetting;

      [SerializeField] private int row;
      [SerializeField] private int col;

      [SerializeField] private SpriteRenderer[,] srArray;
      void Start()
      {
          moveManager = GetComponent<MoveManager>();
          
          srArray = new SpriteRenderer[row, col];
          //新增格子陣列
          grid = new Grid(3, 3,10f,new Vector3(0,0));
          grid.SetValue(0,2,1);
          grid.SetValue(0,1,1);
          grid.SetValue(1,1,1);
          grid.SetValue(2,2,1);
          grid.SetValue(2,1,1);

          sr.color=Color.gray;
          for (int i = 0; i < row; i++)
          {
              for (int j = 0; j < col; j++)
              {
                  srArray[i,j]=Instantiate(sr, new Vector3((i*10)+5, (j*10)+5), Quaternion.identity);
              }
          }
          //可新增別的陣列
          // new Grid(4, 3,5f,new Vector3(20,25));
          SetBG();
          managerGrid = grid;
      }
  
      private void Update()
      {
          //滑鼠左鍵變更參數
          if (Input.GetMouseButtonDown(0))
          {
              grid.SetValue(UtilsClass.GetMouseWorldPosition(),2);
          }
          
          //滑鼠右鍵讀取格子參數
          if (Input.GetMouseButtonDown(1))
          {
              Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
          }
          
          //讀取現在陣列內數值
          if (Input.GetKeyDown(KeyCode.Q))
          {
              grid.CheckValue();
          }
          
          if (Input.GetKeyDown(KeyCode.DownArrow))
          {
              moveManager.MoveDown();
              SetBG();
              // RendomSpawnNumber();
          }
          else if (Input.GetKeyDown(KeyCode.UpArrow))
          {
              moveManager.MoveUp();
              SetBG();
              // RendomSpawnNumber();
          }
          else if (Input.GetKeyDown(KeyCode.RightArrow))
          {
              moveManager.MoveRight();
              SetBG();
              // RendomSpawnNumber();
          }
          else if (Input.GetKeyDown(KeyCode.LeftArrow))
          {
              moveManager.MoveLeft();
              SetBG();
              // RendomSpawnNumber();
          }
      }
      
      public void SetBG()
      {
          for (int i = 0; i < grid.gridArray.GetLength(0); i++)
          {
              for (int j = 0; j < grid.gridArray.GetLength(1); j++)
              {
                  var value = grid.gridArray[i, j];
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

      public void RendomSpawnNumber()
      {
          int tempValue = 0;
          List<TextMesh> tempArray = new List<TextMesh>();
          
          for (int i = 0; i < grid.debugTextMeshes.GetLength(0); i++)
          {
              for (int j = 0; j < grid.debugTextMeshes.GetLength(1); j++)
              {
                  var value = grid.debugTextMeshes[i, j].text;
                  if (value == "0")
                  {
                      
                      tempArray.Add(grid.debugTextMeshes[i, j]);
                  }
              }
          }
          int index = Random.Range(0, tempArray.Count);
          grid.SetValue((int)tempArray[index].transform.position.x,(int)tempArray[index].transform.position.y,1);
          

      }

      public void Setcolor()
      {
          srArray[0,0].color=Color.red;
      }
  }  
}

