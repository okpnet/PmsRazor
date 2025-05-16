﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Buttons
{
    public class ButtonParameter
    {
        public 

        public EventCallback<MouseEventArgs> Click { get; }

        public ButtonParameter(EventCallback<MouseEventArgs> click)
        {
            Click = click;
        }
    }
}
