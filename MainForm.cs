using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlobalLowLevelHooks;
using System.Collections.Generic;

namespace VirtualKKB
{
    public partial class MainForm : Form
    {

        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        private Drawer drawer = new Drawer();

        private KeyboardHook keyboardHook;

        IDictionary<KeyboardHook.VKeys, Rectangle> _pile;

        System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.AntiqueWhite);
        System.Drawing.Graphics formGraphics;
        System.Drawing.Drawing2D.GraphicsState og_state;





        public MainForm()
        {
            InitializeComponent();

            // Global keyboard hook

            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDown += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
            keyboardHook.KeyUp += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyUp);
            keyboardHook.Install();

            

            this.Width = Properties.Resources.koreanlayout.Width;
            this.Height = Properties.Resources.koreanlayout.Height+50;
            this.FormBorderStyle = FormBorderStyle.None;

            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            this.Opacity = .30;

            this.TopMost = true;

            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - this.Width,  workingArea.Bottom - this.Height);

            this.DoubleBuffered = true;
            this.BackgroundImage  = (Properties.Resources.koreanlayout);
           

            // Dragging

            this.MouseDown += MainForm_MouseDown;
            this.MouseMove += MainForm_MouseMove;
            this.MouseUp   += MainForm_MouseUp;

            // Pile de touches

            _pile = new Dictionary<KeyboardHook.VKeys, Rectangle>();

            //

            formGraphics = this.CreateGraphics();
            og_state = formGraphics.Save();


        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }


        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location); // Get the point to the location
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }


        private void keyboardHook_KeyUp(KeyboardHook.VKeys key)
        {
            _pile.Remove(key);

            formGraphics.Restore(og_state);
            og_state = formGraphics.Save();

            formGraphics.Clear(Color.White);
            formGraphics.DrawImage(Properties.Resources.koreanlayout, 0, 0);

            foreach (Rectangle rect in _pile.Values)
            {
                formGraphics.FillRectangle(myBrush, rect);
            }

            drawer.drawn.Remove(key);


            Console.WriteLine("release");
            Console.WriteLine(_pile.Count);
            Console.WriteLine(drawer.drawn.Count);
        }

        private void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
            if (!_pile.ContainsKey(key))
            {
                Console.WriteLine("press");
                Console.WriteLine("Code :" + key.GetHashCode());
                
                try
                {
                Rectangle rect = drawer.toDraw[key];
                    drawer.drawn.Add(key, rect);

                    formGraphics.FillRectangle(myBrush, rect);
                    _pile.Add(key, rect);

                } catch (Exception e)
                {
                    Console.WriteLine("pas dans la liste");
                }

            }
        }

        private void clearKeyInput(KeyboardHook.VKeys key)
        {

        }

    }
}
