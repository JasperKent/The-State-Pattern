using TrafficLights.Code;

namespace TrafficLights.States
{
    public class PrepareToStartState : PelicanStateBase
    {
        public PrepareToStartState(Pelican pelican)
            : base(pelican)
        {
            Pelican[PelicanLights.Amber].State = LightState.Flashing;
            Pelican[PelicanLights.GreenFigure].State = LightState.Flashing;

            Pelican.SetTimeout(Pelican.StartingTime);
        }

        public override void Timeout()
        {
            Pelican.State = new GoIdleState(Pelican);
        }

        public override void Press()
        {
            Pelican.State = new RerequestState(Pelican);
        }
    }
}
