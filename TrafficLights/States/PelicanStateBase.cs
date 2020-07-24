using System;
using TrafficLights.Code;

namespace TrafficLights.States
{
    public abstract class PelicanStateBase
    {
        protected Pelican Pelican { get; }

        public PelicanStateBase(Pelican pelican)
        {
            Pelican = pelican;

            Pelican.AllOff();
        }

        public virtual void Press() { }
        public virtual void Timeout() => throw new InvalidOperationException("Pelican is in wrong state");
    }
}
