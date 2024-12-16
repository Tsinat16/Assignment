using System;
using System.Threading;

namespace StopwatchApp
{
    public delegate void StopwatchEventHandler(string message);

    public class Watch
    {
        private TimeSpan _timeElapsed;
        private bool _isRunning;
        private Timer _timer;

        public event StopwatchEventHandler OnStarted;
        public event StopwatchEventHandler OnStopped;
        public event StopwatchEventHandler OnReset;

        public Watch()
        {
            _timeElapsed = TimeSpan.Zero;
            _isRunning = false;
        }

        public void Start()
        {
            if (_isRunning)
            {
                OnStarted?.Invoke("Stopwatch is already running.");
                return;
            }

            _isRunning = true;
            _timer = new Timer(Tick, null, 0, 1000);
            OnStarted?.Invoke("Stopwatch Started!");
        }

        public void Stop()
        {
            if (!_isRunning)
            {
                OnStopped?.Invoke("Stopwatch is already stopped.");
                return;
            }

            _isRunning = false;
            _timer?.Dispose();
            OnStopped?.Invoke($"Stopwatch Stopped at {_timeElapsed.TotalSeconds:F2} seconds.");
        }

        public void Reset()
        {
            Stop();
            _timeElapsed = TimeSpan.Zero;
            OnReset?.Invoke("Stopwatch Reset!");
        }

        private void Tick(object state)
        {
            _timeElapsed = _timeElapsed.Add(TimeSpan.FromSeconds(1));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine($"Time Elapsed: {_timeElapsed}   | Press S to Start, T to Stop, R to Reset, or Q to Quit.");
        }
    }
}
