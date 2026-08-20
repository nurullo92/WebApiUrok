namespace AuthentificationPrograms.Logger
{
    public interface ILoggers
    {
        void EventLog(string evnmessage);
        void ErrorLog(string errormessage);
        
    }
}
