using System.Diagnostics;

namespace MealPlanner.MVVM.Helpers
{
    /// <summary>
    /// Stop execution when a data binding error occured
    /// </summary>
    /// Author: Mike Woelmer
    /// https://spin.atomicobject.com/2013/12/11/wpf-data-binding-debug/
    public class DebugTraceListener : TraceListener
    {
        public override void Write(string message) { }

        public override void WriteLine(string message)
        {
                Debugger.Break();
        }
    }
}
