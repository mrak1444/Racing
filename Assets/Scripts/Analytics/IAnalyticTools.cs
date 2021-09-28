namespace Profile.Analytic
{
    internal interface IAnalyticTools
    {
        void SendMessage(string alias);
        void SendMessage(string alias, (string, object) data);
    }
}