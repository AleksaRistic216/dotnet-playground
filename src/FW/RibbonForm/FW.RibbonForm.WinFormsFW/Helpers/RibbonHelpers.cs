using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Windows.Forms;

namespace FW.RibbonForm.WinFormsFW.Helpers {
    internal static class RibbonHelpers {
        internal static void InitializeQuickAccessToolbarSkinSelectors(RibbonControl ribbonControl) {
            var skinPaletteDropDownButtonItem = new SkinPaletteDropDownButtonItem();
            skinPaletteDropDownButtonItem.Name = "skinPaletteDropDownButtonItem";

            var skinDropDownButtonItem = new SkinDropDownButtonItem();
            skinDropDownButtonItem.Name = "skinDropDownButtonItem";

            ribbonControl.Items.AddRange(new BarItem[] {
                skinPaletteDropDownButtonItem,
                skinDropDownButtonItem
            });

            ribbonControl.QuickToolbarItemLinks.Add(skinPaletteDropDownButtonItem);
            ribbonControl.QuickToolbarItemLinks.Add(skinDropDownButtonItem);
        }

        internal static void InitializeCommonRibbonCommands(DevExpress.XtraBars.Ribbon.RibbonForm form, RibbonPage ribbonPage) {
            var ribbonControl = ribbonPage.Ribbon;

            // Create repository items
            var repositoryItemComboBox1 = new RepositoryItemComboBox();
            repositoryItemComboBox1.AutoHeight = false;
            repositoryItemComboBox1.Name = "repositoryItemComboBox1";

            var repositoryItemComboBox2 = new RepositoryItemComboBox();
            repositoryItemComboBox2.AutoHeight = false;
            repositoryItemComboBox2.Name = "repositoryItemComboBox2";

            var repositoryItemComboBox3 = new RepositoryItemComboBox();
            repositoryItemComboBox3.AutoHeight = false;
            repositoryItemComboBox3.Name = "repositoryItemComboBox3";

            // Create cmb_RibbonStyle
            var cmb_RibbonStyle = new BarEditItem();
            cmb_RibbonStyle.Caption = "Ribbon Style";
            cmb_RibbonStyle.Edit = repositoryItemComboBox1;
            cmb_RibbonStyle.EditWidth = 150;
            cmb_RibbonStyle.Id = 20;
            cmb_RibbonStyle.Name = "cmb_RibbonStyle";
            cmb_RibbonStyle.EditValueChanged += (s, e) => {
                var style = (RibbonControlStyle)cmb_RibbonStyle.EditValue;
                ribbonControl.RibbonStyle = style;
            };

            // Create ribbonHeaderMode_cmb
            var ribbonHeaderMode_cmb = new BarEditItem();
            ribbonHeaderMode_cmb.Caption = "Ribbon Show Page Header Mode";
            ribbonHeaderMode_cmb.Edit = repositoryItemComboBox2;
            ribbonHeaderMode_cmb.EditWidth = 150;
            ribbonHeaderMode_cmb.Id = 21;
            ribbonHeaderMode_cmb.Name = "ribbonHeaderMode_cmb";
            ribbonHeaderMode_cmb.EditValueChanged += (s, e) => {
                var mode = (ShowPageHeadersMode)ribbonHeaderMode_cmb.EditValue;
                ribbonControl.ShowPageHeadersMode = mode;
            };

            // Create ribbonToolbarLocation_cmb
            var ribbonToolbarLocation_cmb = new BarEditItem();
            ribbonToolbarLocation_cmb.Caption = "Ribbon QAT Location";
            ribbonToolbarLocation_cmb.Edit = repositoryItemComboBox3;
            ribbonToolbarLocation_cmb.EditWidth = 150;
            ribbonToolbarLocation_cmb.Id = 30;
            ribbonToolbarLocation_cmb.Name = "ribbonToolbarLocation_cmb";
            ribbonToolbarLocation_cmb.EditValueChanged += (s, e) => {
                var location = (RibbonQuickAccessToolbarLocation)ribbonToolbarLocation_cmb.EditValue;
                ribbonControl.ToolbarLocation = location;
            };

            // Add repository items to ribbon control
            ribbonControl.RepositoryItems.AddRange(new RepositoryItem[] {
                repositoryItemComboBox1,
                repositoryItemComboBox2,
                repositoryItemComboBox3
            });

            // Create and configure ribbonPageGroup
            var ribbonPageGroup = new RibbonPageGroup();
            ribbonPageGroup.Name = "ribbonPageGroup3";
            ribbonPageGroup.Text = "ribbonPageGroup3";

            // RibbonForm-specific items (only when form is provided)
            if (form != null) {
                // Create barButtonItem2 (RTL)
                var barButtonItem2 = new BarButtonItem();
                barButtonItem2.Caption = "RTL";
                barButtonItem2.Id = 4;
                barButtonItem2.Name = "barButtonItem2";
                barButtonItem2.ItemClick += (s, e) => {
                    form.RightToLeft = form.RightToLeft != RightToLeft.Yes ? RightToLeft.Yes : RightToLeft.No;
                    form.RightToLeftLayout = !form.RightToLeftLayout;
                };

                // Create barButtonItem3 (Change Navigation Mode)
                var barButtonItem3 = new BarButtonItem();
                barButtonItem3.Caption = "Change Navigation Mode";
                barButtonItem3.Id = 10;
                barButtonItem3.Name = "barButtonItem3";
                barButtonItem3.ItemClick += (s, e) => {
                    form.NavigationControlLayoutMode = form.NavigationControlLayoutMode == RibbonFormNavigationControlLayoutMode.StretchToFormTitle
                        ? RibbonFormNavigationControlLayoutMode.StretchToTop
                        : RibbonFormNavigationControlLayoutMode.StretchToFormTitle;
                };

                // Create barButtonItem4 (Toggle SidePane)
                var barButtonItem4 = new BarButtonItem();
                barButtonItem4.Id = 6;
                barButtonItem4.Name = "barButtonItem4";
                barButtonItem4.ItemClick += (s, e) => {
                    form.SidePane.Visible = !form.SidePane.Visible;
                };

                ribbonControl.Items.AddRange(new BarItem[] {
                    barButtonItem2,
                    barButtonItem3,
                    barButtonItem4
                });

                ribbonPageGroup.ItemLinks.Add(barButtonItem2);
                ribbonPageGroup.ItemLinks.Add(barButtonItem3);
                ribbonPageGroup.ItemLinks.Add(barButtonItem4);
            }

            // Add ribbon control items (always added)
            ribbonControl.Items.AddRange(new BarItem[] {
                cmb_RibbonStyle,
                ribbonHeaderMode_cmb,
                ribbonToolbarLocation_cmb
            });

            ribbonPageGroup.ItemLinks.Add(cmb_RibbonStyle);
            ribbonPageGroup.ItemLinks.Add(ribbonHeaderMode_cmb);
            ribbonPageGroup.ItemLinks.Add(ribbonToolbarLocation_cmb);
            ribbonPage.Groups.Add(ribbonPageGroup);

            // Populate combo boxes
            foreach (var style in Enum.GetValues(typeof(RibbonControlStyle)))
                repositoryItemComboBox1.Items.Add(style);
            cmb_RibbonStyle.EditValue = ribbonControl.RibbonStyle;

            foreach (var mode in Enum.GetValues(typeof(ShowPageHeadersMode)))
                repositoryItemComboBox2.Items.Add(mode);
            ribbonHeaderMode_cmb.EditValue = ribbonControl.ShowPageHeadersMode;

            foreach (var location in Enum.GetValues(typeof(RibbonQuickAccessToolbarLocation)))
                repositoryItemComboBox3.Items.Add(location);
            ribbonToolbarLocation_cmb.EditValue = ribbonControl.ToolbarLocation;
        }
    }
}
