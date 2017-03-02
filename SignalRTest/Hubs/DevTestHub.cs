using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRTest.Models;

namespace SignalRTest.Hubs
{
    [HubName("devTestHub")]
    public class DevTestHub : Hub
    {
        private readonly DevTestUpdater _devTestUpdater;

        public DevTestHub() : this(DevTestUpdater.Instance)
        {
        }

        public DevTestHub(DevTestUpdater devTestUpdater)
        {
            _devTestUpdater = devTestUpdater;
        }

        public IEnumerable<DevTestVM> GetAllDevTests()
        {
            return _devTestUpdater.GetAllDevTests();
        }

        public void StartUpdatingClients()
        {
            _devTestUpdater.StartUpdatingClients();
        }

        public void StopUpdatingClients()
        {
            _devTestUpdater.StopUpdatingClients();
        }
    }
}