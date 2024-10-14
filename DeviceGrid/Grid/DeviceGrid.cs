using SmartHome.ControlPanel;
using SmartHome.ControlPanel.AutoController;
using SmartHome.ControlPanel.Service;
using SmartHome.DeviceGrid.Widget;
using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DeviceGrid.Grid
{
    public class DeviceGrid: ISubscriber, INotifyPropertyChanged
    {
        public ObservableCollection<Room> Rooms { get; private set; }

        private readonly IControlService _controlService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public DeviceGrid(IControlService controlService)
        {
            _controlService = controlService;
            _controlService.AddSubscriber(this);

            Rooms = new ObservableCollection<Room>();

            var controller = new AutoController();

            var deviceFactory = new DeviceFactory(controller);
            //AddDeviceToRoom("Room1", deviceFactory.CreateLEDLight());
            //AddDeviceToRoom("Room2", deviceFactory.CreateClock());
        }

        private void AddDeviceToRoom(string roomName, IDevice device)
        {
            var room = Rooms.FirstOrDefault(r => r.Name == roomName);
            if (room == null)
            {
                room = new Room(roomName);
                Rooms.Add(room);
            }

            var widget = new DeviceWidget(device);
            widget.OnClickEvent += OnWidgetSelected;

            var isDeviceIncluded = room.Widgets.Select(w => w.GetComponent()).Contains(device);
            if (!isDeviceIncluded)
            {
                room.Widgets.Add(widget);
            }

            OnPropertyChanged(nameof(Rooms));
        }

        public void OnWidgetSelected(IWidget widget)
        {
            // TODO handle disabled state
            foreach (var room in Rooms)
            {
                foreach (var w in room.Widgets)
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

        public void Update(IControlService service)
        {
            foreach (var (room, devices) in service.Rooms)
            {
                foreach (var device in devices)
                {
                    AddDeviceToRoom(room, device);
                }
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
