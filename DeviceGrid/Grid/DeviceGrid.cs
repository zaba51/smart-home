using SmartHome.ControlPanel.AutoController;
using SmartHome.ControlPanel.Service;
using SmartHome.DeviceGrid.Widget;
using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DeviceGrid.Grid
{
    public class DeviceGrid
    {
        //public List<IWidget> widgets = [];
        public ObservableCollection<IWidget> Widgets { get; private set; }

        private readonly IControlService _controlService;

        public DeviceGrid(IControlService controlService)
        {
            _controlService = controlService;
            Widgets = [];

            var controller = new AutoController();

            var deviceFactory = new DeviceFactory(controller);
            AddDevice(deviceFactory.CreateLEDLight());
            AddDevice(deviceFactory.CreateThermostat());
            AddDevice(deviceFactory.CreateVideoCamera());
            AddDevice(deviceFactory.CreateClock());
        }

        public void AddDevice(IDevice device)
        {
            var widget = new DeviceWidget(device);
            widget.OnClickEvent += OnWidgetSelected;
            Widgets.Add(widget);
        }

        public void OnWidgetSelected(IWidget widget)
        {
            // TODO handle disabled state
            foreach (var w in Widgets)
            {
                if (w != widget)
                    w.Deselect();
            };

            if (widget.IsSelected)
            {
                _controlService.SelectDevice(widget.GetComponent());
            }
            else
            {
                _controlService.SelectDevice(null);
            }
        }
    }
}
