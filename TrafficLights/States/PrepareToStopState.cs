using TrafficLights.Code;

namespace TrafficLights.States
{
    public class PrepareToStopState : PelicanStateBase
    {
        public PrepareToStopState(Pelican pelican)
            : base(pelican)
        {
            Pelican[PelicanLights.Wait].State = LightState.On;
            Pelican[PelicanLights.Amber].State = LightState.On;
            Pelican[PelicanLights.RedFigure].State = LightState.On;

            Pelican.SetTimeout(Pelican.StoppingTime);
        }

        public override void Timeout()
        {
            Pelican.State = new StopState(Pelican);
        }
    }
}
