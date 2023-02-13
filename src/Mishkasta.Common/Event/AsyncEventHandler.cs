﻿using System;
using System.Threading.Tasks;

namespace Mishkasta.Common.Event
{
    public delegate Task AsyncEventHandler<in TEventArgs>(object sender, TEventArgs eventArgs) where TEventArgs : EventArgs;
}