using UnityEngine;
using CodeMonkey.Utils;

namespace Grid_System.Scripts
{
    public class GridBgSetting : MonoBehaviour
    {
        public SpriteRenderer gridBG;
    
        public void SetBG(int value,int x ,int y)
        {
            switch (value)
            {
                case 1:
                    gridBG.color = Color.cyan;
                    break;
                case 2:
                    gridBG.color=Color.magenta;
                    break;
                default:
                    gridBG.color = Color.gray;
                    break;
            }
        }
    }
}

