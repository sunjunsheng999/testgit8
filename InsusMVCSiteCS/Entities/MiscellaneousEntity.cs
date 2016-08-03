using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insus.NET.Models;

namespace Insus.NET.Entities
{
    public class MiscellaneousEntity
    {
        public List<DateFormat> RadioItemLists()
        {
            List<DateFormat> items = new List<DateFormat>();
            items.Add(new DateFormat { Format = "mm/dd/yy" });
            items.Add(new DateFormat { Format = "yy-mm-dd" });
            return items;
        }

        public List<EightDiagram> EightDiagramLists()
        {
            List<EightDiagram> ed = new List<EightDiagram>();
            ed.Add(new EightDiagram { ID = 1, EDName = "乾" });
            ed.Add(new EightDiagram { ID = 2, EDName = "坤" });
            ed.Add(new EightDiagram { ID = 3, EDName = "震" });
            ed.Add(new EightDiagram { ID = 4, EDName = "巽" });
            ed.Add(new EightDiagram { ID = 5, EDName = "坎" });
            ed.Add(new EightDiagram { ID = 6, EDName = "離" });
            ed.Add(new EightDiagram { ID = 7, EDName = "艮" });
            ed.Add(new EightDiagram { ID = 8, EDName = "兌" });
            return ed;
        }

        public List<Destiny> DestinyLists()
        {
            List<Destiny> destiny = new List<Destiny>();
            destiny.Add(new Destiny { ID = 1, Name = "命" });
            destiny.Add(new Destiny { ID = 2, Name = "运" });
            destiny.Add(new Destiny { ID = 3, Name = "风水" });
            destiny.Add(new Destiny { ID = 4, Name = "积德" });
            destiny.Add(new Destiny { ID = 5, Name = "读书" });

            return destiny;
        }
    }
}

