using System.Collections.Generic;
using UnityEngine.Analytics;

namespace Profile.Analytic
{
    internal class UnityAnalyticTools : IAnalyticTools
    {
        public void SendMessage(string alias)
        {
            Analytics.CustomEvent(alias);
        }

        public void SendMessage(string alias, (string, object) data)
        {
            var eventData = new Dictionary<string, object> { [data.Item1] = data.Item2};
            Analytics.CustomEvent(alias, eventData);
        }
    }
}