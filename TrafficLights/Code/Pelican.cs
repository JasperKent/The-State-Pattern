using System;
using System.Windows.Threading;
using TrafficLights.States;

namespace TrafficLights.Code
{
    public enum PelicanLights { Red, Amber, Green, RedFigure, GreenFigure, Wait }

    public class Pelican
    {
        public const int WaitTime = 2000;
        public const int StoppingTime = 2000;
        public const int StoppedTime = 4000;
        public const int StartingTime = 4000;

        private readonly Light[] _lights;

        public Light this[PelicanLights li] => _lights[(int)li];

        public PelicanStateBase State { get; set; }

        private readonly DispatcherTimer _timer;

        public Pelican()
        {
            _lights = new Light[] { new Light(), new Light(), new Light(), new Light(), new Light(), new Light() };

            State = new GoIdleState(this);

            _timer = new DispatcherTimer();
            _timer.Tick += (s, e) =>
            {
                _timer.Stop();
                Timeout();
            };
        }

        public void AllOff()
        {
            foreach (Light l in _lights)
                l.State = LightState.Off;
        }

        public void Press() => State.Press();
        public void Timeout() => State.Timeout();

        public void SetTimeout(int waitTime)
        {
            _timer.Interval = new TimeSpan(0, 0, 0, 0, waitTime);
            _timer.Start();
        }
    }
}
