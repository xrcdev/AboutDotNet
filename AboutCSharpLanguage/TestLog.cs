using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AboutCSharpLanguage
{
    public class TestLog
    {
        public static void WriteMsg(string msg)
        {
            System.Diagnostics.Debug.WriteLine("");
            var source = new TraceSource("Foobar", SourceLevels.All);
            var evtTypes = (TraceEventType[])Enum.GetValues(typeof(TraceEventType));
            var evtId = 1;
            Array.ForEach(evtTypes, et => source.TraceEvent(et, evtId++,msg));

            
        }
    }
}
