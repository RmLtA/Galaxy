﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication3
{
    class aHexMap : FrameworkElement
    {
        private VisualCollection _children;
        private BitmapImage aBackground;
        private TextBlock aText;
        private ScrollViewer myScroller;
        const int scroll_by = 1;
        static Point mouse_start = new Point(0, 0);
        private Boolean hasHexes = false;
        private Boolean isDragging = false;

        int hexCols = 20;
        int hexRows = 20;
        const int HEX_WIDTH = 100;
        const int HEX_HEIGHT = 100;
        const int HEX_GAP = 5;

        public aHexMap(TextBlock tb, ScrollViewer scroller)
        {
            aText = tb;
            myScroller = scroller;
            _children = new VisualCollection(this);
            aBackground = TryFindResource("ttni") as BitmapImage;
            drawBackground();

            this.PreviewMouseUp += mouseClicked;
            this.PreviewMouseDown += mouseDown;
            this.PreviewMouseUp += mouseUp;
            this.PreviewMouseMove += mouseMoved;
        }

        private void drawBackground()
        {
            // Make Sure that height/width is set to external image dimensions.
            double width = 1000;
            double height = 1000;
            DrawingVisual mapBitmap = new DrawingVisual();
            using (DrawingContext dc = mapBitmap.RenderOpen())
            {
                Rect aRec = new Rect(0, 0, width, height);
                dc.DrawImage(aBackground, aRec);
            }
            _children.Add(mapBitmap);
        }
        public void configureMap(int rows, int cols)
        {
            hexCols = cols;
            hexRows = rows;
            hasHexes = false;
        }
        public void drawHexes()
        {   
            aHex tmpHex;
            if (hasHexes)
                return;
            _children.Clear();
            drawBackground();
            for (int col = 0; col < hexCols; col++)
            {
                for (int row = 0; row < hexRows; row++)
                {
                    string hexName = string.Format("hex [{0},{1}]", col, row);
                    int x_off, y_off;
                    computeHexOffsets(col, row, out x_off, out y_off);
                    switch (row)
                    {
                        case 0:
                            {
                                tmpHex = new aHex(x_off, y_off,
                                 HEX_WIDTH, HEX_HEIGHT, Brushes.Green, hexName);
                                tmpHex.addUnitHex(5);
                                _children.Add(tmpHex);
                                break;
                            }
                        case 1:
                            {
                                tmpHex = new aHex(x_off, y_off,
                                HEX_WIDTH, HEX_HEIGHT, Brushes.Yellow, hexName);
                                _children.Add(tmpHex);
                                break;
                            }
                        default:
                            {
                                tmpHex = new aHex(x_off, y_off,
                                HEX_WIDTH, HEX_HEIGHT, Brushes.Blue, hexName);
                                _children.Add(tmpHex);
                                break;
                            }
                            
                    }


                }
            }
            hasHexes = true;
        }
        private void computeHexOffsets(int col, int row, out int x_off, out int y_off)
        {
            float fCol = (float)col;
            float fRow = (float)row;
            float fWidth = (float)HEX_WIDTH;
            float fHeight = (float)HEX_HEIGHT;
            float fGap = (float)HEX_GAP;

            x_off = (int)((fCol * (fWidth + fGap)) * 0.75f);
            float y_adjust = (fHeight * 0.5f) * (col % 2);
            y_off = (int)(fRow * (fHeight + fGap) + y_adjust);
        }
        private void mouseClicked(object sender, MouseButtonEventArgs e)
        {
            if (aText == null)
                MessageBox.Show("forgot to set the text control");
            else
            {
                Point pt = e.GetPosition((UIElement)sender);
                string Res = string.Format("mouse coords, relative to background = {0}", pt);
                aText.Text = Res;
                VisualTreeHelper.HitTest(this, null,
                    new HitTestResultCallback(someHexClicked),
                    new PointHitTestParameters(pt));
            }
        }
        void mouseDown(object sender, MouseEventArgs e)
        {
            mouse_start = e.GetPosition(myScroller);
            e.Handled = true;
        }
        void mouseMoved(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                isDragging = true;
                scroll_map(e);
                mouse_start = e.GetPosition(myScroller);
            }
            e.Handled = true;
        }
        void mouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            e.Handled = true;
        }
        void scroll_map(MouseEventArgs e)
        {
            Point mouse_cur = e.GetPosition(myScroller);
            double x_diff = mouse_start.X - mouse_cur.X;
            double y_diff = mouse_start.Y - mouse_cur.Y;
            myScroller.ScrollToHorizontalOffset(myScroller.HorizontalOffset + x_diff);
            myScroller.ScrollToVerticalOffset(myScroller.VerticalOffset + y_diff);
        }
        public HitTestResultBehavior someHexClicked(HitTestResult ht)
        {
            // ignore clicking on a hex if map is being dragged.
            if (isDragging)
                return HitTestResultBehavior.Stop;
            // use casting to determine if click was on hex or map.
            aHex hex = ht.VisualHit as aHex;
            if (hex != null)
                updateMap(hex);
            return HitTestResultBehavior.Stop;
        }
        private void updateMap(aHex hex)
        {
            string hexData = string.Format("hex clicked = {0}", hex.myName);
            aText.Text = hexData;
            hex.Opacity = (hex.Opacity < 0.9f) ? 1.0f : 0.5f;
        }

        // Required overrides for FrameworkElement class.
        protected override int VisualChildrenCount
        {
            get { return _children.Count; }
        }
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return _children[index];
        }

    }
}
