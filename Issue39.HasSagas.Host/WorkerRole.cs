﻿using System.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using NServiceBus.Hosting.Azure;

namespace Issue39.HasSagas.Host
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly NServiceBusRoleEntrypoint _nsb = new NServiceBusRoleEntrypoint();

        public override bool OnStart()
        {
            Trace.TraceInformation("Issue39.HasSagas.Host OnStart called");

            _nsb.Start();

            return base.OnStart();
        }

        public override void OnStop()
        {
            _nsb.Stop();

            base.OnStop();
        }
    }
}
