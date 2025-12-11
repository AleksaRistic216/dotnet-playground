using System.ComponentModel;
using Common.Contracts.Entities;
using Common.Contracts.Interfaces.IRepositories;
using Common.Repository;
using DevExpress.Data.Linq;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;

namespace LDSSM.WinForms
{
	public partial class DXGridForm : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		private readonly CommonDbContext dbContext;
		private readonly IUserRepository userRepository;

		public DXGridForm(CommonDbContext dbContext, IUserRepository userRepository)
		{
			this.dbContext = dbContext;
			this.userRepository = userRepository;
			InitializeComponent();
			this.gridView1.OptionsMenu.ShowConditionalFormattingItem = true;
			//this.gridView1.OptionsNavigation.AllowHeaderNavigation = DevExpress.Utils.DefaultBoolean.True;
		}

		private void DXGridForm_Load(object sender, EventArgs e) { }

		private void ApplyFilters()
		{
			ApplyPhoneNumberConditionalFilters();
		}

		private void ApplyPhoneNumberConditionalFilters()
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
		}

		#region Helpers
		GridFormatRule CreateFormatRuleDate(GridColumn column, FilterDateType dateType)
		{
			var dateRule = new FormatConditionRuleDateOccuring
			{
				Appearance = { BackColor = Color.LightGreen },
				DateType = dateType,
			};
			var formatDateRule = new GridFormatRule { Rule = dateRule, Column = column };
			return formatDateRule;
		}

		GridFormatRule CreateFormatRuleIntGreater(GridColumn column, int value)
		{
			var intRule = new FormatConditionRuleValue
			{
				Appearance = { ForeColor = Color.LightGreen, FontStyleDelta = FontStyle.Bold },
				Value1 = value,
				Condition = FormatCondition.Greater,
			};
			var formatIntRule = new GridFormatRule { Rule = intRule, Column = column };
			return formatIntRule;
		}

		GridFormatRule CreateFormatRuleIntLess(GridColumn column, int value)
		{
			var intRule = new FormatConditionRuleValue
			{
				Appearance = { ForeColor = Color.Red, FontStyleDelta = FontStyle.Bold },
				Value1 = value,
				Condition = FormatCondition.Less,
			};
			var formatIntRule = new GridFormatRule { Rule = intRule, Column = column };
			return formatIntRule;
		}

		GridFormatRule CreateFormatRuleTextEquals(GridColumn column, string text)
		{
			var textRule = new FormatConditionRuleValue
			{
				Appearance = { BackColor = Color.Red },
				Value1 = text,
				Condition = FormatCondition.Equal,
			};
			var formatTextRule = new GridFormatRule { Rule = textRule, Column = column };
			return formatTextRule;
		}
		#endregion


		static IListSource CreateServerModeSource(CommonDbContext dbContext)
		{
			var source = new EntityServerModeSource();
			source.ElementType = typeof(UserEntity);
			source.QueryableSource = dbContext.Users;
			source.KeyExpression = nameof(UserEntity.Id);
			return source;
		}

		static IListSource CreateInstantFeedbackSource(CommonDbContext dbContext)
		{
			var source = new EntityInstantFeedbackSource();
			source.DesignTimeElementType = typeof(UserEntity);
			source.GetQueryable += (s, e) => e.QueryableSource = dbContext.Users;
			source.KeyExpression = nameof(UserEntity.Id);
			return source;
		}

		static IListSource CreateServerModeSource(IUserRepository repo)
		{
			var source = new EntityServerModeSource();
			source.ElementType = typeof(UserEntity);
			source.QueryableSource = repo.GetMultiple();
			source.KeyExpression = nameof(UserEntity.Id);
			return source;
		}

		static IListSource CreateInstantFeedbackSource(IUserRepository repo)
		{
			var source = new EntityInstantFeedbackSource();
			source.DesignTimeElementType = typeof(UserEntity);
			source.GetQueryable += (s, e) => e.QueryableSource = repo.GetMultiple();
			source.KeyExpression = nameof(UserEntity.Id);
			return source;
		}

		private void barToggleSwitchItem_CheckedChanged(
			object sender,
			DevExpress.XtraBars.ItemClickEventArgs e
		)
		{
			var checkItem = sender as DevExpress.XtraBars.BarToggleSwitchItem;
			if (!checkItem.Checked)
			{
				gridControl1.DataSource = null;
				return;
			}

			foreach (var link in ribbonPageGroup1.ItemLinks.OfType<BarToggleSwitchItemLink>())
			{
				var ci = link.Item as BarToggleSwitchItem;
				if (ci == checkItem)
					continue;
				ci.Checked = false;
			}
			//gridControl1.DataSource = dbContext.Users; // error, requires load
			//gridControl1.DataSource = userRepository.GetMultiple().Take(1_000).ToList(); // Too much GB if I load all data

			if (sender == barToggleSwitchItem1)
			{
				gridControl1.DataSource = CreateServerModeSource(dbContext);
			}
			else if (sender == barToggleSwitchItem2)
			{
				gridControl1.DataSource = CreateInstantFeedbackSource(dbContext);
			}
			else if (sender == barToggleSwitchItem3)
			{
				gridControl1.DataSource = CreateServerModeSource(userRepository);
			}
			else if (sender == barToggleSwitchItem4)
			{
				gridControl1.DataSource = CreateInstantFeedbackSource(userRepository);
			}

			ApplyFilters();
		}
	}
}
