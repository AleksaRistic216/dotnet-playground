using Common.Contracts.Entities;
using Common.Contracts.Interfaces.IRepositories;
using DevExpress.AIIntegration;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;

namespace Ai.ExpressionEditors {
    public partial class Form1 : RibbonForm {
        readonly IUserRepository _userRepository;
        readonly IConfigurationRoot _configuration;
        public Form1(IUserRepository userRepository, IConfigurationRoot configuration) {
            _userRepository = userRepository;
            _configuration = configuration;
            InitializeComponent();
            gridControl.DataSource = _userRepository.GetMultiple().Take(10_000).ToList();
            repositoryItemComboBox2.Items.AddRange(Enum.GetValues<AiProvider>());
            gridView.OptionsMenu.ShowConditionalFormattingItem = true;
            gridView.OptionsMenu.ShowConditionalFormatFiltersItem = true;
            UpdateColumns();
        }

        void UpdateColumns() {
            var textRule = new FormatConditionRuleExpression() {
                Appearance = { BackColor = Color.Bisque },
                Expression = string.Join(
                    " or ",
                    Enumerable
                        .Range(100, 300)
                        .Select(x => $"Contains([{nameof(UserEntity.Phone)}], '+{x}')")
                        .ToList()
                ),
            };
            var formatTextRule = new GridFormatRule {
                Rule = textRule,
                Column = gridView.Columns[nameof(UserEntity.Phone)],
            };
            gridView.FormatRules.Add(formatTextRule);

        }

        private void gridControl_Click(object sender, EventArgs e) {
        }

        private void barEditItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e) {
            var item = sender as DevExpress.XtraBars.BarEditItem;
            if(item == null)
                return;
            var model = item.EditValue as string;
            if(string.IsNullOrWhiteSpace(model))
                return;
            ApplyNewModel(model);
        }

        void SelectFirstAvailableModel() {
            var aiProvider = (AiProvider)barEditItem2.EditValue;
            var models = AiConstants.MODELS[aiProvider];
            barEditItem1.EditValue = models[0];
        }

        void ApplyNewModel(string model) {
            var provider = (AiProvider)barEditItem2.EditValue;
            AIExtensionsContainerDesktop.Default.UnregisterChatClient();
            IChatClient client = null!;
            switch(provider) {
                case AiProvider.OpenAi:
                    client = new OpenAI.OpenAIClient(_configuration["OPEN_AI_KEY"]).GetChatClient(model).AsIChatClient();
                    break;
                default:
                    throw new NotSupportedException($"The provider {provider} is not supported.");
            }
            AIExtensionsContainerDesktop.Default.RegisterChatClient(client);
        }

        private void barEditItem2_EditValueChanged(object sender, EventArgs e) {
            var item = sender as DevExpress.XtraBars.BarEditItem;
            if(item == null)
                return;
            var value = (AiProvider)item.EditValue;
            repositoryItemComboBox1.Items.Clear();
            repositoryItemComboBox1.Items.AddRange(AiConstants.MODELS[value]);
            SelectFirstAvailableModel();
        }
    }
}
