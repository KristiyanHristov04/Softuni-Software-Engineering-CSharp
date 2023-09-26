using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousChronometer
{
    internal class Chronometer : IChronometer
    {

        private Stopwatch _stopwatch;
        private List<string> _laps;

        public Chronometer()
        {
            this._stopwatch = new Stopwatch();
            this._laps = new List<string>();
        }
        public string GetTime => this._stopwatch.Elapsed.ToString(@"mm\:ss\.ffff");

        public List<string> Laps => this._laps;

        public string Lap()
        {
            string result = this.GetTime;
            this._laps.Add(result);
            return result;
        }

        public void Reset()
        {
            this._stopwatch.Reset();
            this._laps.Clear();
        }

        public void Start()
        {
            this._stopwatch.Start();
        }

        public void Stop()
        {
            this._stopwatch.Stop();
        }
    }
}
