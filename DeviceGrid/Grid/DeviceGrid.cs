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
        //public ObservableCollection<IWidget> Widgets { get; private set; }
        public Dictionary<string, ObservableCollection<IWidget>> Rooms { get; private set; }

        private readonly IControlService _controlService;

        public DeviceGrid(IControlService controlService)
        {
            _controlService = controlService;
            //Widgets = [];
            Rooms = new Dictionary<string, ObservableCollection<IWidget>>();

            var controller = new AutoController();

            var deviceFactory = new DeviceFactory(controller);
            AddDeviceToRoom("Room1", deviceFactory.CreateLEDLight());
            AddDeviceToRoom("Room1", deviceFactory.CreateThermostat());
            AddDeviceToRoom("Room1", deviceFactory.CreateVideoCamera());
            AddDeviceToRoom("Room1", deviceFactory.CreateClock());

            AddDeviceToRoom("Room2", deviceFactory.CreateLEDLight());
            AddDeviceToRoom("Room2", deviceFactory.CreateThermostat());
            AddDeviceToRoom("Room2", deviceFactory.CreateVideoCamera());
            AddDeviceToRoom("Room2", deviceFactory.CreateClock());
        }

        public void AddDeviceToRoom(string roomName, IDevice device)
        {
            var widget = new DeviceWidget(device);
            widget.OnClickEvent += OnWidgetSelected;

            if (!Rooms.ContainsKey(roomName))
            {
                Rooms[roomName] = new ObservableCollection<IWidget>();
            }

            Rooms[roomName].Add(widget);
        }

        public void OnWidgetSelected(IWidget widget)
        {
            // TODO handle disabled state
            foreach (var room in Rooms)
            {
                foreach (var w in room.Value)
                {
                    if (w != widget)
                        w.Deselect();
                };
            }

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
