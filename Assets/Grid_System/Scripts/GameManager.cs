using System;
using System.Collections.Generic;
using CodeMonkey.Utils;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

namespace Grid_System.Scripts
{
  public class GameManager : MonoBehaviour
  {
      
      public Grid grid;
      [SerializeField] private MoveManager moveManager;
      [SerializeField] private GridBgImage gridBgImage;
      [SerializeField] private RendomSpawnNumber rendomSpawnNumber;

      [SerializeField] private int row = 3;
      [SerializeField] private int col = 3;
      [SerializeField] private float cellSize = 10f;



      //用來讓別的class存取參數
      public int Getrow() {return row;}
      public int Getcol() {return col;}
      public float GetcellSize() {return cellSize;}

      void Start()
      {
          moveManager = GetComponent<MoveManager>();
          gridBgImage = GetComponent<GridBgImage>();
          rendomSpawnNumber = GetComponent<RendomSpawnNumber>();

          //新增格子陣列
          grid = new Grid(row, col,cellSize,new Vector3(0,0));
          //添加預設值
          grid.SetValue(0,2,1);
          grid.SetValue(0,1,1);
          grid.SetValue(1,1,1);
          grid.SetValue(2,2,1);


          //可新增別的陣列
          // new Grid(4, 3,5f,new Vector3(20,25));
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
              moveManager.MoveDown();           //移動
              gridBgImage.SetBG();              //設定格子顏色
              rendomSpawnNumber.RendomSpawn();  //隨機添加基礎值在空位置
          }
          else if (Input.GetKeyDown(KeyCode.UpArrow))
          {
              moveManager.MoveUp();
              gridBgImage.SetBG();
              rendomSpawnNumber.RendomSpawn();
          }
          else if (Input.GetKeyDown(KeyCode.RightArrow))
          {
              moveManager.MoveRight();
              gridBgImage.SetBG();
              rendomSpawnNumber.RendomSpawn();
          }
          else if (Input.GetKeyDown(KeyCode.LeftArrow))
          {
              moveManager.MoveLeft();
              gridBgImage.SetBG();
              rendomSpawnNumber.RendomSpawn();
          }
      }

  }  
}

