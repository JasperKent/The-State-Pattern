using TrafficLights.Code;

namespace TrafficLights.States
{
    public class GoIdleState : PelicanStateBase
    {
        public GoIdleState(Pelican pelican)
            :base(pelican)
        {
            Pelican[PelicanLights.Green].State = LightState.On;
            Pelican[PelicanLights.RedFigure].State = LightState.On;
        }

        public override void Press()
        {
            Pelican.State = new GoWaitingState(Pelican);
        }
    }
}
