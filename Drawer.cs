using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GlobalLowLevelHooks;

namespace VirtualKKB
{
    class Drawer
    {
        private const int WIDTH = 792;
        private const int HEIGHT = 217;

        public Dictionary<KeyboardHook.VKeys, Rectangle> toDraw;
        public Dictionary<KeyboardHook.VKeys, Rectangle> drawn;
        public List<Rectangle> rectPos = new List<Rectangle>();
        public Drawer()
        {
            // First row 

            for (int i = 0; i < 5; i++)
            {
            rectPos.Add(new Rectangle(23 + (57 + 11)*i, 17, 57, 57)); // A key

            }

            for (int i = 0; i < 5; i++)
            {
                rectPos.Add(new Rectangle(430 + (57 + 11) * i, 17, 57, 57)); // A key

            }

            // Second row

            for (int i = 0; i < 5; i++)
            {
                rectPos.Add(new Rectangle(37 + (57 + 11) * i, 81, 57, 57)); // A key

            }

            for (int i = 0; i < 5; i++)
            {
                rectPos.Add(new Rectangle(446 + (57 + 11) * i, 81, 57, 57)); // A key

            }

            // Third row

            for (int i = 0; i < 5; i++)
            {
                rectPos.Add(new Rectangle(9 + (57 + 11) * i, 145, 57, 57)); // A key

            }

            for (int i = 0; i < 5; i++)
            {
                rectPos.Add(new Rectangle(417 + (57 + 11) * i, 145, 57, 57)); // A key

            }

            drawn = new Dictionary<KeyboardHook.VKeys, Rectangle>();
            toDraw = new Dictionary<KeyboardHook.VKeys, Rectangle>();

            toDraw.Add(KeyboardHook.VKeys.KEY_A, rectPos[0]);
            toDraw.Add(KeyboardHook.VKeys.KEY_Z, rectPos[1]);
            toDraw.Add(KeyboardHook.VKeys.KEY_E, rectPos[2]);
            toDraw.Add(KeyboardHook.VKeys.KEY_R, rectPos[3]);
            toDraw.Add(KeyboardHook.VKeys.KEY_T, rectPos[4]);
            toDraw.Add(KeyboardHook.VKeys.KEY_Y, rectPos[5]);
            toDraw.Add(KeyboardHook.VKeys.KEY_U, rectPos[6]);
            toDraw.Add(KeyboardHook.VKeys.KEY_I, rectPos[7]);
            toDraw.Add(KeyboardHook.VKeys.KEY_O, rectPos[8]);
            toDraw.Add(KeyboardHook.VKeys.KEY_P, rectPos[9]);


            toDraw.Add(KeyboardHook.VKeys.KEY_Q, rectPos[10]);
            toDraw.Add(KeyboardHook.VKeys.KEY_S, rectPos[11]);
            toDraw.Add(KeyboardHook.VKeys.KEY_D, rectPos[12]);
            toDraw.Add(KeyboardHook.VKeys.KEY_F, rectPos[13]);
            toDraw.Add(KeyboardHook.VKeys.KEY_G, rectPos[14]);
            toDraw.Add(KeyboardHook.VKeys.KEY_H, rectPos[15]);
            toDraw.Add(KeyboardHook.VKeys.KEY_J, rectPos[16]);
            toDraw.Add(KeyboardHook.VKeys.KEY_K, rectPos[17]);
            toDraw.Add(KeyboardHook.VKeys.KEY_L, rectPos[18]);
            toDraw.Add(KeyboardHook.VKeys.KEY_M, rectPos[19]);


            toDraw.Add(KeyboardHook.VKeys.OEM_102, rectPos[20]);
            toDraw.Add(KeyboardHook.VKeys.KEY_W, rectPos[21]);
            toDraw.Add(KeyboardHook.VKeys.KEY_X, rectPos[22]);
            toDraw.Add(KeyboardHook.VKeys.KEY_C, rectPos[23]);
            toDraw.Add(KeyboardHook.VKeys.KEY_V, rectPos[24]);
            toDraw.Add(KeyboardHook.VKeys.KEY_B, rectPos[25]);
            toDraw.Add(KeyboardHook.VKeys.KEY_N, rectPos[26]);
            toDraw.Add(KeyboardHook.VKeys.OEM_COMMA, rectPos[27]);
            toDraw.Add(KeyboardHook.VKeys.OEM_PERIOD, rectPos[28]);
            toDraw.Add(KeyboardHook.VKeys.OEM_2, rectPos[29]);




        }


        
      





    }
}
