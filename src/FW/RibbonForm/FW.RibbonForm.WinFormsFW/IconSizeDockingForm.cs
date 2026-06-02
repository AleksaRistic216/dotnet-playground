using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Ribbon;

namespace FW.RibbonForm.WinFormsFW {
    public partial class IconSizeDockingForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public IconSizeDockingForm() {
            InitializeComponent();
            SetupDocking();
            SetupDocuments();
        }

        void SetupDocking() {
            // DockPanel with ImageUri - these don't yet implement IDXImageUriClient
            dockPanel1.Text = "Properties";
            dockPanel1.ImageOptions.ImageUri.Uri = "New";

            dockPanel2.Text = "Toolbox";
            dockPanel2.ImageOptions.ImageUri.Uri = "Open";

            dockPanel3.Text = "Output";
            dockPanel3.ImageOptions.ImageUri.Uri = "Save";
        }

        void SetupDocuments() {
            // BaseDocument tabs with ImageUri - needs both IDXImageUriClient + IDXImageUriIconSizeProvider
            var doc1 = documentManager1.View.AddDocument(CreateDocPanel("Document 1 content"));
            doc1.Caption = "MainForm.cs";
            doc1.ImageOptions.ImageUri.Uri = "New";

            var doc2 = documentManager1.View.AddDocument(CreateDocPanel("Document 2 content"));
            doc2.Caption = "Program.cs";
            doc2.ImageOptions.ImageUri.Uri = "Open";

            var doc3 = documentManager1.View.AddDocument(CreateDocPanel("Document 3 content"));
            doc3.Caption = "Settings.xml";
            doc3.ImageOptions.ImageUri.Uri = "Save";

            var doc4 = documentManager1.View.AddDocument(CreateDocPanel("Document 4 content"));
            doc4.Caption = "Report.rdlc";
            doc4.ImageOptions.ImageUri.Uri = "Print";

            var doc5 = documentManager1.View.AddDocument(CreateDocPanel("Document 5 content"));
            doc5.Caption = "Dashboard";
            doc5.ImageOptions.ImageUri.Uri = "New";
        }

        Panel CreateDocPanel(string text) {
            var panel = new Panel();
            var label = new Label {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            panel.Controls.Add(label);
            return panel;
        }
    }
}
