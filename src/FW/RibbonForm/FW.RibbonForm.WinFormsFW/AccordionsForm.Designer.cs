namespace FW.RibbonForm.WinFormsFW {
    partial class AccordionsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControl2 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControl3 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControl4 = new DevExpress.XtraBars.Navigation.AccordionControl();
            // Accordion1 elements - nested groups with items
            this.grpMailbox = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemInbox = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemSent = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemDrafts = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemTrash = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.grpContacts = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemAllContacts = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemFavorites = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.grpSettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.grpSettingsGeneral = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemLanguage = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemTheme = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.grpSettingsAdvanced = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemPlugins = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemDeveloper = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.separatorElement1 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.itemStandaloneAction = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            // Accordion2 elements - flat items with context buttons
            this.grpDashboard = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemOverview = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemAnalytics = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemReports = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.grpManagement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemUsers = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemRoles = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemPermissions = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.grpNotifications = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemAlerts = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemMessages = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            // Accordion3 elements - hamburger menu navigation
            this.grpNavHome = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemNavDashboard = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemNavFeed = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.grpNavExplore = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemNavTrending = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemNavCategories = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemNavBookmarks = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.grpNavAccount = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemNavProfile = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemNavSecurity = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemNavLogout = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            // Accordion4 elements - hamburger + footer with mixed content
            this.grpFiles = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemDocuments = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemImages = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemVideos = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.grpTools = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemCalculator = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemNotepad = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemTerminal = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.grpHelp = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemDocumentation = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemAbout = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl4)).BeginInit();
            this.SuspendLayout();
            // 
            // accordionControl1 - Nested groups, separator, standalone item
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.grpMailbox,
            this.grpContacts,
            this.grpSettings,
            this.separatorElement1,
            this.itemStandaloneAction});
            this.accordionControl1.Location = new System.Drawing.Point(0, 0);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Always;
            this.accordionControl1.Size = new System.Drawing.Size(262, 586);
            this.accordionControl1.TabIndex = 0;
            // 
            // grpMailbox
            // 
            this.grpMailbox.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.itemInbox,
            this.itemSent,
            this.itemDrafts,
            this.itemTrash});
            this.grpMailbox.Expanded = true;
            this.grpMailbox.Name = "grpMailbox";
            this.grpMailbox.Text = "Mailbox";
            // 
            // itemInbox
            // 
            this.itemInbox.Name = "itemInbox";
            this.itemInbox.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemInbox.Text = "Inbox";

            // 
            // itemSent
            // 
            this.itemSent.Name = "itemSent";
            this.itemSent.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemSent.Text = "Sent Items";
            // 
            // itemDrafts
            // 
            this.itemDrafts.Name = "itemDrafts";
            this.itemDrafts.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemDrafts.Text = "Drafts";

            // 
            // itemTrash
            // 
            this.itemTrash.Name = "itemTrash";
            this.itemTrash.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemTrash.Text = "Trash";
            // 
            // grpContacts
            // 
            this.grpContacts.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.itemAllContacts,
            this.itemFavorites});
            this.grpContacts.Name = "grpContacts";
            this.grpContacts.Text = "Contacts";
            // 
            // itemAllContacts
            // 
            this.itemAllContacts.Name = "itemAllContacts";
            this.itemAllContacts.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemAllContacts.Text = "All Contacts";
            // 
            // itemFavorites
            // 
            this.itemFavorites.Name = "itemFavorites";
            this.itemFavorites.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemFavorites.Text = "Favorites";
            // 
            // grpSettings - nested subgroups
            // 
            this.grpSettings.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.grpSettingsGeneral,
            this.grpSettingsAdvanced});
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Text = "Settings";
            // 
            // grpSettingsGeneral
            // 
            this.grpSettingsGeneral.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.itemLanguage,
            this.itemTheme});
            this.grpSettingsGeneral.Name = "grpSettingsGeneral";
            this.grpSettingsGeneral.Text = "General";
            // 
            // itemLanguage
            // 
            this.itemLanguage.Name = "itemLanguage";
            this.itemLanguage.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemLanguage.Text = "Language";
            // 
            // itemTheme
            // 
            this.itemTheme.Name = "itemTheme";
            this.itemTheme.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemTheme.Text = "Theme";
            // 
            // grpSettingsAdvanced
            // 
            this.grpSettingsAdvanced.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.itemPlugins,
            this.itemDeveloper});
            this.grpSettingsAdvanced.Name = "grpSettingsAdvanced";
            this.grpSettingsAdvanced.Text = "Advanced";
            // 
            // itemPlugins
            // 
            this.itemPlugins.Name = "itemPlugins";
            this.itemPlugins.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemPlugins.Text = "Plugins";
            // 
            // itemDeveloper
            // 
            this.itemDeveloper.Name = "itemDeveloper";
            this.itemDeveloper.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemDeveloper.Text = "Developer Options";
            // 
            // separatorElement1
            // 
            this.separatorElement1.Name = "separatorElement1";
            // 
            // itemStandaloneAction
            // 
            this.itemStandaloneAction.Name = "itemStandaloneAction";
            this.itemStandaloneAction.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemStandaloneAction.Text = "Compose New";
            // 
            // accordionControl2 - Footer display mode with context buttons
            // 
            this.accordionControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.accordionControl2.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.grpDashboard,
            this.grpManagement,
            this.grpNotifications});
            this.accordionControl2.Location = new System.Drawing.Point(822, 0);
            this.accordionControl2.Name = "accordionControl2";
            this.accordionControl2.RootDisplayMode = DevExpress.XtraBars.Navigation.AccordionControlRootDisplayMode.Footer;
            this.accordionControl2.Size = new System.Drawing.Size(260, 586);
            this.accordionControl2.TabIndex = 1;
            this.accordionControl2.ExpandElementMode = DevExpress.XtraBars.Navigation.ExpandElementMode.Multiple;
            // 
            // grpDashboard
            // 
            this.grpDashboard.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.itemOverview,
            this.itemAnalytics,
            this.itemReports});
            this.grpDashboard.Expanded = true;
            this.grpDashboard.Name = "grpDashboard";
            this.grpDashboard.Text = "Dashboard";
            // 
            // itemOverview
            // 
            this.itemOverview.Name = "itemOverview";
            this.itemOverview.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemOverview.Text = "Overview";
            // 
            // itemAnalytics
            // 
            this.itemAnalytics.Name = "itemAnalytics";
            this.itemAnalytics.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemAnalytics.Text = "Analytics";
            // 
            // itemReports
            // 
            this.itemReports.Name = "itemReports";
            this.itemReports.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemReports.Text = "Reports";
            // 
            // grpManagement
            // 
            this.grpManagement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.itemUsers,
            this.itemRoles,
            this.itemPermissions});
            this.grpManagement.Expanded = true;
            this.grpManagement.Name = "grpManagement";
            this.grpManagement.Text = "Management";
            // 
            // itemUsers
            // 
            this.itemUsers.Name = "itemUsers";
            this.itemUsers.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemUsers.Text = "Users";

            // 
            // itemRoles
            // 
            this.itemRoles.Name = "itemRoles";
            this.itemRoles.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemRoles.Text = "Roles";
            // 
            // itemPermissions
            // 
            this.itemPermissions.Name = "itemPermissions";
            this.itemPermissions.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemPermissions.Text = "Permissions";
            // 
            // grpNotifications
            // 
            this.grpNotifications.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.itemAlerts,
            this.itemMessages});
            this.grpNotifications.Name = "grpNotifications";
            this.grpNotifications.Text = "Notifications";
            // 
            // itemAlerts
            // 
            this.itemAlerts.Name = "itemAlerts";
            this.itemAlerts.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemAlerts.Text = "Alerts";

            // 
            // itemMessages
            // 
            this.itemMessages.Name = "itemMessages";
            this.itemMessages.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemMessages.Text = "Messages";

            // 
            // accordionControl3 - Hamburger menu navigation
            // 
            this.accordionControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.accordionControl3.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.grpNavHome,
            this.grpNavExplore,
            this.grpNavAccount});
            this.accordionControl3.Location = new System.Drawing.Point(562, 0);
            this.accordionControl3.Name = "accordionControl3";
            this.accordionControl3.Size = new System.Drawing.Size(260, 586);
            this.accordionControl3.TabIndex = 2;
            this.accordionControl3.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            this.accordionControl3.ExpandElementMode = DevExpress.XtraBars.Navigation.ExpandElementMode.Multiple;
            // 
            // grpNavHome
            // 
            this.grpNavHome.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.itemNavDashboard,
            this.itemNavFeed});
            this.grpNavHome.Expanded = true;
            this.grpNavHome.Name = "grpNavHome";
            this.grpNavHome.Text = "Home";
            // 
            // itemNavDashboard
            // 
            this.itemNavDashboard.Name = "itemNavDashboard";
            this.itemNavDashboard.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemNavDashboard.Text = "Dashboard";
            // 
            // itemNavFeed
            // 
            this.itemNavFeed.Name = "itemNavFeed";
            this.itemNavFeed.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemNavFeed.Text = "Activity Feed";
            // 
            // grpNavExplore
            // 
            this.grpNavExplore.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.itemNavTrending,
            this.itemNavCategories,
            this.itemNavBookmarks});
            this.grpNavExplore.Expanded = true;
            this.grpNavExplore.Name = "grpNavExplore";
            this.grpNavExplore.Text = "Explore";
            // 
            // itemNavTrending
            // 
            this.itemNavTrending.Name = "itemNavTrending";
            this.itemNavTrending.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemNavTrending.Text = "Trending";
            // 
            // itemNavCategories
            // 
            this.itemNavCategories.Name = "itemNavCategories";
            this.itemNavCategories.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemNavCategories.Text = "Categories";
            // 
            // itemNavBookmarks
            // 
            this.itemNavBookmarks.Name = "itemNavBookmarks";
            this.itemNavBookmarks.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemNavBookmarks.Text = "Bookmarks";
            // 
            // grpNavAccount
            // 
            this.grpNavAccount.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.itemNavProfile,
            this.itemNavSecurity,
            this.itemNavLogout});
            this.grpNavAccount.Name = "grpNavAccount";
            this.grpNavAccount.Text = "Account";
            // 
            // itemNavProfile
            // 
            this.itemNavProfile.Name = "itemNavProfile";
            this.itemNavProfile.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemNavProfile.Text = "Profile";
            // 
            // itemNavSecurity
            // 
            this.itemNavSecurity.Name = "itemNavSecurity";
            this.itemNavSecurity.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemNavSecurity.Text = "Security";
            // 
            // itemNavLogout
            // 
            this.itemNavLogout.Name = "itemNavLogout";
            this.itemNavLogout.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemNavLogout.Text = "Log Out";
            // 
            // accordionControl4 - Hamburger + Footer with file/tool groups
            // 
            this.accordionControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.accordionControl4.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.grpFiles,
            this.grpTools,
            this.grpHelp});
            this.accordionControl4.Location = new System.Drawing.Point(262, 0);
            this.accordionControl4.Name = "accordionControl4";
            this.accordionControl4.RootDisplayMode = DevExpress.XtraBars.Navigation.AccordionControlRootDisplayMode.Footer;
            this.accordionControl4.Size = new System.Drawing.Size(300, 300);
            this.accordionControl4.TabIndex = 3;
            this.accordionControl4.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            this.accordionControl4.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Always;
            // 
            // grpFiles
            // 
            this.grpFiles.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.itemDocuments,
            this.itemImages,
            this.itemVideos});
            this.grpFiles.Expanded = true;
            this.grpFiles.Name = "grpFiles";
            this.grpFiles.Text = "Files";
            // 
            // itemDocuments
            // 
            this.itemDocuments.Name = "itemDocuments";
            this.itemDocuments.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemDocuments.Text = "Documents";
            // 
            // itemImages
            // 
            this.itemImages.Name = "itemImages";
            this.itemImages.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemImages.Text = "Images";
            // 
            // itemVideos
            // 
            this.itemVideos.Name = "itemVideos";
            this.itemVideos.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemVideos.Text = "Videos";
            // 
            // grpTools
            // 
            this.grpTools.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.itemCalculator,
            this.itemNotepad,
            this.itemTerminal});
            this.grpTools.Expanded = true;
            this.grpTools.Name = "grpTools";
            this.grpTools.Text = "Tools";
            // 
            // itemCalculator
            // 
            this.itemCalculator.Name = "itemCalculator";
            this.itemCalculator.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemCalculator.Text = "Calculator";
            // 
            // itemNotepad
            // 
            this.itemNotepad.Name = "itemNotepad";
            this.itemNotepad.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemNotepad.Text = "Notepad";
            // 
            // itemTerminal
            // 
            this.itemTerminal.Name = "itemTerminal";
            this.itemTerminal.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemTerminal.Text = "Terminal";
            // 
            // grpHelp
            // 
            this.grpHelp.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.itemDocumentation,
            this.itemAbout});
            this.grpHelp.Name = "grpHelp";
            this.grpHelp.Text = "Help";
            // 
            // itemDocumentation
            // 
            this.itemDocumentation.Name = "itemDocumentation";
            this.itemDocumentation.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemDocumentation.Text = "Documentation";
            // 
            // itemAbout
            // 
            this.itemAbout.Name = "itemAbout";
            this.itemAbout.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemAbout.Text = "About";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1082, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Navigation";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 563);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1082, 23);
            // 
            // AccordionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 586);
            this.Controls.Add(this.accordionControl4);
            this.Controls.Add(this.accordionControl3);
            this.Controls.Add(this.accordionControl2);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "AccordionsForm";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "AccordionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl2;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl3;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl4;
        // Accordion1 - nested groups with filter
        private DevExpress.XtraBars.Navigation.AccordionControlElement grpMailbox;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemInbox;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemSent;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemDrafts;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemTrash;
        private DevExpress.XtraBars.Navigation.AccordionControlElement grpContacts;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemAllContacts;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemFavorites;
        private DevExpress.XtraBars.Navigation.AccordionControlElement grpSettings;
        private DevExpress.XtraBars.Navigation.AccordionControlElement grpSettingsGeneral;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemLanguage;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemTheme;
        private DevExpress.XtraBars.Navigation.AccordionControlElement grpSettingsAdvanced;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemPlugins;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemDeveloper;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator separatorElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemStandaloneAction;
        // Accordion2 - footer mode with multiple expand
        private DevExpress.XtraBars.Navigation.AccordionControlElement grpDashboard;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemOverview;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemAnalytics;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemReports;
        private DevExpress.XtraBars.Navigation.AccordionControlElement grpManagement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemUsers;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemRoles;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemPermissions;
        private DevExpress.XtraBars.Navigation.AccordionControlElement grpNotifications;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemAlerts;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemMessages;
        // Accordion3 - hamburger menu
        private DevExpress.XtraBars.Navigation.AccordionControlElement grpNavHome;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemNavDashboard;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemNavFeed;
        private DevExpress.XtraBars.Navigation.AccordionControlElement grpNavExplore;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemNavTrending;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemNavCategories;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemNavBookmarks;
        private DevExpress.XtraBars.Navigation.AccordionControlElement grpNavAccount;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemNavProfile;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemNavSecurity;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemNavLogout;
        // Accordion4 - hamburger + footer + filter
        private DevExpress.XtraBars.Navigation.AccordionControlElement grpFiles;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemDocuments;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemImages;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemVideos;
        private DevExpress.XtraBars.Navigation.AccordionControlElement grpTools;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemCalculator;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemNotepad;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemTerminal;
        private DevExpress.XtraBars.Navigation.AccordionControlElement grpHelp;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemDocumentation;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemAbout;
    }
}