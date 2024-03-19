using UnityEngine;

public static class LogHeader
{
    public static string Path
    {
        get
        {
#if UNITY_EDITOR || USE_DEBUGGING
            string callStack = StackTraceUtility.ExtractStackTrace();
            callStack = callStack.Substring(callStack.IndexOf("\n") + 1);
            callStack = callStack.Substring(0, callStack.IndexOf("\n") + 1);
            return callStack;
#else
            return "";
#endif
        }
    }

    public static string Function
    {
        get
        {
#if UNITY_EDITOR || USE_DEBUGGING
            string callStack = StackTraceUtility.ExtractStackTrace();
            callStack = callStack.Substring(callStack.IndexOf("\n") + 1);
            callStack = callStack.Substring(0, callStack.IndexOf("("));
            return "[" + callStack + "] ";
#else
            return "";
#endif        
        }
    }
}