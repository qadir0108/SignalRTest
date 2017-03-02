using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoMapper;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.Practices.Unity;
using SignalRTest.Data;
using SignalRTest.Data.UnitOfWork;
using SignalRTest.Models;

namespace SignalRTest.Hubs
{
    public class DevTestUpdater
    {
        // Singleton instance
        private readonly static Lazy<DevTestUpdater> _instance = 
            new Lazy<DevTestUpdater>(
                () => new DevTestUpdater(
                    GlobalHost.ConnectionManager.GetHubContext<DevTestHub>().Clients));

        
        private DevTestUnitOfWork _unitOfWork;

        private DevTestUnitOfWork UnitOfWork
        {
            get
            {
                UnityContainer container = new UnityContainer();
                _unitOfWork = container.Resolve<DevTestUnitOfWork>();
                return _unitOfWork;
            }
        }
        

        private readonly object _lock = new object();
        private readonly TimeSpan _updateInterval = TimeSpan.FromSeconds(30);
        private Timer _timer;
        private volatile bool _isUpdating;

        private DevTestUpdater(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
        }

        public static DevTestUpdater Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        public IEnumerable<DevTestVM> GetAllDevTests()
        {
            return UnitOfWork.DevTestRepository.All().ToList()
                .Select(x => Mapper.Map<DevTest, DevTestVM>(x));
        }

        public void StartUpdatingClients()
        {
            lock (_lock)
            {
                _timer = new Timer(UpdateClients, null, _updateInterval, _updateInterval);
            }
        }

        private void UpdateClients(object state)
        {
            lock (_lock)
            {
                if (!_isUpdating)
                {
                    _isUpdating = true;

                    Clients.All.refresh(GetAllDevTests());

                    _isUpdating = false;
                }
            }
        }

        public void StopUpdatingClients()
        {
            lock (_lock)
            {
                if (_timer != null)
                {
                    _timer.Dispose();
                }
            }
        }
    }
}