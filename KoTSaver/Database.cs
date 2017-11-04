using System.Collections.Generic;
using System.Linq;

namespace KoTSaver
{
    public class Database
    {
        public int Id { get; private set; }
        public string BaseId { get; set; }
        public string Layout { get; private set; }
        public string Timers { get; set; }

        public Database(int id, string baseId, string layout, string timers)
        {
            Timers = timers;
            Id = id;
            BaseId = baseId;
            Layout=layout;
        }

        public List<int> GetTimersList()
        {
            return Timers.Split(';').Select(int.Parse).ToList();
        }
    }
}
