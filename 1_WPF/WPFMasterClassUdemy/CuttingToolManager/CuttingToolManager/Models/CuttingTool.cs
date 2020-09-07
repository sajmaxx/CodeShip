using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CuttingToolManager.Models
{
    public class CuttingTool
    {
        [PrimaryKey, AutoIncrement] 
        public int Toolid { get; set; }

        public string ToolName { get; set; }

        public double ToolDiameter { get; set;}
        
        public string ToolType { get; set; }

        public override string ToString()
        {
            return Toolid + " " + ToolName +  " " + ToolType;
        }

    }
}
