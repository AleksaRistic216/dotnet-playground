namespace FW.RTL.WinForms.TestForms.Misc {
    [TestForm("Misc", "HTML Content Control")]
    public partial class FormWithHtmlContentControl : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithHtmlContentControl() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            SetupHtmlContent();
        }

        private void SetupHtmlContent() {
            htmlContentControl1.HtmlTemplate.Template = @"
<div style='padding: 20px; font-family: Segoe UI, Tahoma, sans-serif;'>
    <h1 style='color: #2196F3; margin-bottom: 10px;'>Welcome to DevExpress</h1>
    <p style='font-size: 14px; line-height: 1.6;'>
        This is an <b>HtmlContentControl</b> that renders HTML content with CSS styling.
    </p>
    <hr style='border: 1px solid #e0e0e0; margin: 20px 0;'/>
    <h2 style='color: #4CAF50;'>Features</h2>
    <ul style='font-size: 13px; line-height: 1.8;'>
        <li>Rich HTML rendering</li>
        <li>CSS styling support</li>
        <li>Data binding capabilities</li>
        <li>Interactive elements</li>
    </ul>
    <h2 style='color: #FF9800;'>Sample Table</h2>
    <table style='border-collapse: collapse; width: 100%;'>
        <tr style='background-color: #f5f5f5;'>
            <th style='border: 1px solid #ddd; padding: 10px; text-align: left;'>Product</th>
            <th style='border: 1px solid #ddd; padding: 10px; text-align: left;'>Price</th>
            <th style='border: 1px solid #ddd; padding: 10px; text-align: left;'>Stock</th>
        </tr>
        <tr>
            <td style='border: 1px solid #ddd; padding: 10px;'>Widget A</td>
            <td style='border: 1px solid #ddd; padding: 10px;'>$29.99</td>
            <td style='border: 1px solid #ddd; padding: 10px;'>150</td>
        </tr>
        <tr style='background-color: #fafafa;'>
            <td style='border: 1px solid #ddd; padding: 10px;'>Widget B</td>
            <td style='border: 1px solid #ddd; padding: 10px;'>$49.99</td>
            <td style='border: 1px solid #ddd; padding: 10px;'>85</td>
        </tr>
        <tr>
            <td style='border: 1px solid #ddd; padding: 10px;'>Widget C</td>
            <td style='border: 1px solid #ddd; padding: 10px;'>$19.99</td>
            <td style='border: 1px solid #ddd; padding: 10px;'>320</td>
        </tr>
    </table>
    <p style='margin-top: 20px; color: #757575; font-size: 12px;'>
        Note: This control supports RTL layout when RightToLeft is enabled.
    </p>
</div>";
        }
    }
}
