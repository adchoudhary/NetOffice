﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetOffice
{   
    /// <summary>
    /// Provides access to instance management 
    /// </summary>
    public interface ICOMObjectManagement
    {
        /// <summary>
        /// Notify info the count of proxies there open are changed
        /// in case of notify comes from event trigger created proxy the call comes from other thread
        /// </summary>
        event NetOffice.COMObjectManagement.CountChangedHandler CountChanged;

        /// <summary>
        /// Occurs when a proxy has been added
        /// </summary>
        event NetOffice.COMObjectManagement.AddedHandler Added;

        /// <summary>
        ///  Occurs when a proxy has been removed
        /// </summary>
        event NetOffice.COMObjectManagement.RemovedHandler Removed;

        /// <summary>
        /// Occurs when all proxies has been removed
        /// </summary>
        event NetOffice.COMObjectManagement.ClearHandler Cleared;

        /// <summary>
        /// Affected NetOffice Core
        /// </summary>
        Core Parent { get; }

        /// <summary>
        /// Returns current count of open proxies
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Returns root instances from its core
        /// </summary>
        /// <returns>root instance sequence</returns>
        IEnumerable<ICOMObject> GetRootInstances();

        /// <summary>
        /// Dispose all open instances from its core
        /// </summary>
        void DisposeAllInstances();
    }
}
