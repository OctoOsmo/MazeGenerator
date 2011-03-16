using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;

namespace MazeGenerator
{
    interface MazeAlgorithm
    {
        TimeSpan Generate(Network network/*, ref BackgroundWorker baw*/);
    }
}
