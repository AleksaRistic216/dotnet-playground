using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.Handler;
using DevExpress.XtraGrid.Views.Base.ViewInfo;

namespace Templates.WinForms {
    [ToolboxItem(true)]
    public class : GridControl㋡ {
        protected override BaseView CreateDefaultView() {
return CreateView("㋡");        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection) {
base.RegisterAvailableViewsCore(collection);
collection.Add(new ㋡InfoRegistrator());
        }
    }

    public class ㋡InfoRegistrator {
    }
}
