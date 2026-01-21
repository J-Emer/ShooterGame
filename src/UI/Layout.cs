using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ShooterGame.UI
{
    public abstract class Layout
    {
        public abstract void DoLayout(Rectangle sourceRect, IReadOnlyList<Control> controls, int padding);
    }

    public class HorizontalLayout : Layout
    {
        public override void DoLayout(Rectangle sourceRect, IReadOnlyList<Control> controls, int padding)
        {
            float xPos = padding + sourceRect.X;
            float yPos = padding + sourceRect.Y;

            foreach (var item in controls)
            {
                item.Position = new Vector2(xPos,yPos);

                yPos += padding + item.Size.Y;
            }
        }
    }

    public class VerticalLayout : Layout
    {
        public override void DoLayout(Rectangle sourceRect, IReadOnlyList<Control> controls, int padding)
        {
            float xPos = padding + sourceRect.X;
            float yPos = padding + sourceRect.Y;

            foreach (var item in controls)
            {
                item.Position = new Vector2(xPos,yPos);

                yPos += padding + item.Size.X;
            }              
        } 
    }

    public class RowLayout : Layout
    {
        public override void DoLayout(Rectangle sourceRect, IReadOnlyList<Control> controls, int padding)
        {
            float xPos = padding + sourceRect.X;
            float yPos = padding + sourceRect.Y;

            float width = sourceRect.Width - (padding + padding);

            foreach (var item in controls)
            {
                item.Position = new Vector2(xPos,yPos);

                item.Size = new Vector2(width, item.Size.Y);
                yPos += padding + item.Size.Y;
            }
        }
    }    

    public class ColumnLayout : Layout
    {
        public override void DoLayout(Rectangle sourceRect, IReadOnlyList<Control> controls, int padding)
        {
            float xPos = padding + sourceRect.X;
            float yPos = padding + sourceRect.Y;

            float Height = sourceRect.Height - (padding + padding);

            foreach (var item in controls)
            {
                item.Position = new Vector2(xPos,yPos);

                item.Size = new Vector2(item.Size.X, Height);

                xPos += padding + item.Size.Y;
            }
        }
    }   

    public class GridLayout : Layout
    {
        public int Columns{get;set;} = 1;
        public int Rows{get;set;} = 1;

        public GridLayout(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
        }

        public override void DoLayout(Rectangle sourceRect, IReadOnlyList<Control> controls, int padding)
        {
            int paddingTotal = (Columns + 1) * padding;
            int size = (sourceRect.Width - paddingTotal) / Columns;

            int xPos = sourceRect.X + padding;
            int yPos = sourceRect.Y + padding;

            int index = 0;

            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    if(index >= controls.Count){return;}

                    Control item = controls[index];

                    item.Position = new Vector2(xPos, yPos);
                    item.Size = new Vector2(size);

                    xPos += size + padding;

                    index += 1;
                }
                
                xPos = sourceRect.X + padding;
                yPos += size + padding;
            }
        }
    }

    //---only lay's out the 1st control
    public class StretchLayout : Layout
    {
        public override void DoLayout(Rectangle sourceRect, IReadOnlyList<Control> controls, int padding)
        {
            if(controls.Count <= 0){return;}

            Control item = controls[0];

            item.Position = new Vector2(sourceRect.X + padding, sourceRect.Y + padding);
            item.Size = new Vector2(sourceRect.Width - (padding * 2), sourceRect.Height - (padding * 2));

            return;
        }
    }



}