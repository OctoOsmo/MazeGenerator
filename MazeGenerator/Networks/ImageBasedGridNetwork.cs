using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace MazeGenerator
{

    /// <summary>
    /// A grid of squares based on a specified image.
    /// Grid cells representing darker parts of the image are subdivided.
    /// </summary>
    class ImageBasedGridNetwork : GridNetwork
    {
        public void Initialize(string filename, int subdivisions)
        {
            Bitmap image = new Bitmap(filename);

            gridSize.Width = image.Width;
            gridSize.Height = image.Height;

            grid = new List<Node>[gridSize.Width, gridSize.Height];

            for (int x = 0; x < gridSize.Width; x++)
            {
                for (int y = 0; y < gridSize.Height; y++)
                {
                    Color col = image.GetPixel(x, y);
                    PointF offset = new PointF(x * subdivisions, y * subdivisions);

                    grid[x, y] = new List<Node>();

                    if (col.R == 255 && col.G == 255 && col.B == 255)
                    {
                        AddGridCell(offset, 1, subdivisions, ref grid[x, y]);
                    }
                    else
                    {
                        // Subdivide non-white areas
                        AddGridCell(offset, subdivisions, 1, ref grid[x, y]);
                    }
                }
            }

            ConnectGrid();
            CalculateWeightsByArea();

            System.Diagnostics.Trace.WriteLine("\n\n");
            System.Diagnostics.Trace.WriteLine("ImageBasedGridMaze : Nodes = " + nodeDict.Count);
            System.Diagnostics.Trace.WriteLine("ImageBasedGridMaze : NodeLinks = " + NodeLink.Count);
            System.Diagnostics.Trace.WriteLine("\n\n");
        }
    }
}