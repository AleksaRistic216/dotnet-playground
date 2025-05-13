using Common.Contracts.Entities;
using Common.Contracts.Interfaces.IRepositories;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;

namespace CFFP.WinForms
{
	public partial class Form1 : Form
	{
		public Form1(IUserRepository userRepository)
		{
			InitializeComponent();
			var data = userRepository.GetMultiple().Take(1000);
			gridControl1.DataSource = data.ToList();
			gridView1.OptionsMenu.ShowConditionalFormattingItem = true;
			gridView1.OptionsMenu.ShowConditionalFormatFiltersItem = true;
			//gridView1.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.ShowAlways;
			ApplyFilters();
		}

		private void Form1_Load(object sender, EventArgs e) { }

		private void ApplyFilters()
		{
			var textRule = new FormatConditionRuleExpression()
			{
				Appearance = { BackColor = Color.Bisque },
				Expression = string.Join(
					" or ",
					Enumerable
						.Range(100, 300)
						.Select(x => $"Contains([{nameof(UserEntity.Phone)}], '+{x}')")
						.ToList()
				),
			};
			var formatTextRule = new GridFormatRule
			{
				Rule = textRule,
				Column = gridView1.Columns[nameof(UserEntity.Phone)],
			};
			gridView1.FormatRules.Add(formatTextRule);

			var ageRuleLess = new FormatConditionRuleValue()
			{
				Appearance = { BackColor = Color.LightGreen },
				Condition = FormatCondition.LessOrEqual,
				Value1 = 20,
			};
			var formatAgeRuleLess = new GridFormatRule
			{
				Rule = ageRuleLess,
				Column = gridView1.Columns[nameof(UserEntity.Age)],
			};
			gridView1.FormatRules.Add(formatAgeRuleLess);

			var ageRuleGreater = new FormatConditionRuleValue()
			{
				Appearance = { BackColor = Color.LightPink },
				Condition = FormatCondition.Greater,
				Value1 = 50,
			};
			var formatAgeRuleGreater = new GridFormatRule
			{
				Rule = ageRuleGreater,
				Column = gridView1.Columns[nameof(UserEntity.Age)],
			};
			gridView1.FormatRules.Add(formatAgeRuleGreater);
		}
	}
}
