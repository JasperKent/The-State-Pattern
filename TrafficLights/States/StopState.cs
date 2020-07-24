using TrafficLights.Code;

namespace TrafficLights.States
{
    public class StopState : PelicanStateBase
    {
        public StopState(Pelican pelican)
            : base(pelican)
        {
            Pelican[PelicanLights.Red].State = LightState.On;
            Pelican[PelicanLights.GreenFigure].State = LightState.On;

            Pelican.SetTimeout(Pelican.StoppingTime);
        }

        public override void Timeout()
        {
            Pelican.State = new PrepareToStartState(Pelican);
        }
    }
}
