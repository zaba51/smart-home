using SmartHome.ControlPanel.AutoController;
using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DeviceGrid
{
    class DeviceFactory
    {
        private readonly IMediator _mediator; 

        public DeviceFactory(IMediator mediator)
        {
            _mediator = mediator;
        }

        public LEDLight CreateLEDLight() {
            var ledLight = new LEDLight();
            ledLight.SetMediator(_mediator);
            return ledLight;
        }

        public Thermostat CreateThermostat()
        {
            var thermostat = new Thermostat();
            thermostat.SetMediator(_mediator);
            return thermostat;
        }

        public Camera CreateVideoCamera()
        {
            var camera = new Camera();
            camera.SetMediator(_mediator);
            return camera;
        }

        public Camera CreateAutoVideoCamera()
        {
            var camera = new Camera();
            camera.SetMediator(_mediator);
            return camera;
        }

        public Clock CreateClock()
        {
            var clock = new Clock();
            clock.SetMediator(_mediator);
            return clock;
        }
    }
}
