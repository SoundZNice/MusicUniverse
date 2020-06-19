using System;

namespace HelpersTool.ConsoleApp.Tools
{
    abstract class ToolBase
    {
        protected Action<string> _log;

        protected string ToolName { get; private set; }
        protected abstract void RunInternal();

        public ToolBase(Action<string> log, string toolName)
        {
            _log = log;

            ToolName = toolName;
        }

        public void Run()
        {
            _log($"{ToolName} [{DateTime.Now}] Started...");

            try
            {
                RunInternal();

                _log($"{ToolName} [{DateTime.Now}] Finished...");
            }
            catch(Exception e)
            {
                _log($"{ToolName} [{DateTime.Now}] Failed! Message: {e.Message}, StackTrace: {e.StackTrace}");
            }

        }
    }
}
