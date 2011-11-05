﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GorgonLibrary;
using GorgonLibrary.Graphics;
using GorgonLibrary.InputDevices;
using GorgonLibrary.GUI;
using SS3D.UserInterface;
using Lidgren.Network;
using SS3D_shared;
using ClientResourceManager;

namespace SS3D.UserInterface
{
    class Checkbox : GuiComponent
    {
        Sprite checkbox;
        Sprite checkboxCheck;

        private Boolean value = false;
        public Boolean Value
        {
            get
            {
                return value;
            }
            set
            {
                if (ValueChanged != null) ValueChanged(value);
                this.value = value;
            }
        }

        public delegate void CheckboxChangedHandler(Boolean newValue);
        public event CheckboxChangedHandler ValueChanged;

        public Checkbox() 
            : base()
        {
            checkbox = ResMgr.Singleton.GetSprite("nosprite");
            checkboxCheck = ResMgr.Singleton.GetSprite("nosprite");
            Update();
        }

        public override void Update()
        {
            clientArea = new Rectangle(this.position, new Size((int)checkbox.Width, (int)checkbox.Height));
        }

        public override void Render()
        {
            checkbox.Draw(clientArea);
            if (Value) checkboxCheck.Draw(clientArea);
        }

        public override void Dispose()
        {
            checkbox = null;
            checkboxCheck = null;
            ValueChanged = null;
            base.Dispose();
            GC.SuppressFinalize(this);
        }

        public override bool MouseDown(MouseInputEventArgs e)
        {
            if (clientArea.Contains(new Point((int)e.Position.X, (int)e.Position.Y)))
            {
                Value = !Value;
                return true;
            }
            return false;
        }

        public override bool MouseUp(MouseInputEventArgs e)
        {
            return false;
        }
    }
}