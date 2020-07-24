using TrafficLights.Code;

namespace TrafficLights.States
{
    public class RerequestState : PelicanStateBase
    {
        public RerequestState(Pelican pelican)
            : base(pelican)
        {
            Pelican[PelicanLights.Amber].State = LightState.Flashing;
            Pelican[PelicanLights.GreenFigure].State = LightState.Flashing;
            Pelican[PelicanLights.Wait].State = LightState.On;
        }

        public override void Timeout()
        {
            Pelican.State = new GoWaitingState(Pelican);
        }
    }
}
