using TrafficLights.Code;

namespace TrafficLights.States
{
    public class GoWaitingState : PelicanStateBase
    {
        public GoWaitingState(Pelican pelican)
            : base(pelican)
        {
            Pelican[PelicanLights.Wait].State = LightState.On;
            Pelican[PelicanLights.Green].State = LightState.On;
            Pelican[PelicanLights.RedFigure].State = LightState.On;

            Pelican.SetTimeout(Pelican.WaitTime);
        }

        public override void Timeout()
        {
            Pelican.State = new PrepareToStopState(Pelican);
        }
    }
}
