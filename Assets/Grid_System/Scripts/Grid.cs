using System;
using CodeMonkey.Utils;
using Unity.Collections;
using UnityEngine;

namespace Grid_System.Scripts
{
    public class Grid 
    {

        public const int HEAT_MAP_MAX_VALUE = 100;
        public const int HEAT_MAP_MIN_VALUE = 0;
    
    
        private int width;
        private int height;
        private float cellSize;
        private Vector3 originPosition;
        [ReadOnly]public int[,] gridArray;
        public TextMesh[,] debugTextMeshes;



        /*
     * 畫格線
     */
        public Grid(int width, int height,float cellSize,Vector3 originPosition)
        {
            this.width = width;     //格子X座標
            this.height = height;   //格子Y座標
            this.cellSize = cellSize;   //格子寬度
            this.originPosition = originPosition;   //這個陣列的原點

            gridArray = new int[width, height];     //new一個存放格子座標的陣列
            debugTextMeshes = new TextMesh[width, height];  //格子內的數字

            //歷遍陣列
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    //生成TextMesh，透過UtilsClass.CreateWorldText設定Mesh內容、位置、大小、顏色等
                    debugTextMeshes[x,y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y)+new Vector3(cellSize,cellSize)*.5f, 20, Color.yellow,
                        TextAnchor.MiddleCenter);   
                    //畫出格線
                    Debug.DrawLine(GetWorldPosition(x,y),GetWorldPosition(x,y+1),Color.white,100f);
                    Debug.DrawLine(GetWorldPosition(x,y),GetWorldPosition(x+1,y),Color.white,100f);
                }                                                                               
            }
            //畫出剩下兩條格線
            Debug.DrawLine(GetWorldPosition(0,height),GetWorldPosition(width,height),Color.white,100f);
            Debug.DrawLine(GetWorldPosition(width,0),GetWorldPosition(width,height),Color.white,100f);

        }                                                                                          

    
        private Vector3 GetWorldPosition(int x, int y)
        {
            //這裡算出單一格子的大小，回傳每隔的大小跟原點座標
            return new Vector3(x, y) * cellSize + originPosition;
        }

        //取每個格子的範圍
        //函數只會回傳一個值，所以利用out取址方式更改內容
        private void GetXY(Vector3 worldPosition, out int x, out int y)
        {
            //Mathf.FloorToInt : 回傳最大的整數，小於等於參數(無條件捨去)
            //計算每個格子的範圍，超過下個整數才會算到下一格
            x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
            y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
        }

        //設定Mesh值
        public void SetValue(int x, int y, int value)
        {
            //檢查是否在格子內以及有無超出範圍
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                gridArray[x, y] = value;    //將參數丟給grid陣列
                debugTextMeshes[x, y].text = gridArray[x, y].ToString();    //將grid陣列的參數轉成字串給Mesh
            }
        }

        public void SetValue(Vector3 worldPosition, int value)
        {
            int x, y;   //宣告兩個變數丟到GetXY作為暫存變數存取結果
            GetXY(worldPosition,out x,out y);
            SetValue(x,y,value);
        }

        //取格子內的參數
        public int GetValue(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                return gridArray[x, y];
            }
            else
            {
                return 0;
            }
        }

        public int GetValue(Vector3 worldPosition)
        {
            int x, y;
            GetXY(worldPosition,out x,out y);
            return GetValue(x, y);
        }

        
    
        public void CheckValue()
        {
            for (int i = 0; i < gridArray.GetLength(0); i++)
            {
                for (int j = 0; j < gridArray.GetLength(1); j++)
                {
                    Debug.Log("["+i+","+j+"] : "+GetValue(i,j));
                }
            }
        }


        public void ArrayCalculation(int i)
        {
            switch (i)
            {
                case 1: //Down
                    for (int x = 0; x < gridArray.GetLength(0); x++)
                    {
                        for (int y = gridArray.GetLength(1); y < 0; y--)
                        {
                            if (gridArray[x,y]==gridArray[x,y-1])
                            {
                                gridArray[x, y - 1] += gridArray[x, y];
                                gridArray[x, y] = 0;
                            }
                        }
                    }
                    break;
            }
        }
    }
}
