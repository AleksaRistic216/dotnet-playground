# DevExpress WPF Skills

AI agent skills for [DevExpress WPF](https://www.devexpress.com/products/net/controls/wpf/) — Windows Presentation Foundation controls and frameworks for .NET 6/7/8+ and .NET Framework 4.6.2+.

All skills target DevExpress v26.1.

---

## Skills

### Data-aware controls

| Skill | Covers |
|---|---|
| [wpf-devexpress-data-grid](data-grid/wpf-devexpress-data-grid/) | `GridControl` — TableView / CardView / TreeListView, data binding (EF Core, XPO, server mode), columns, sorting, filtering, grouping, summaries, master-detail, conditional formatting, printing & export |
| [wpf-devexpress-tree-list](data-grid/wpf-devexpress-tree-list/) | `TreeListControl` — self-referential / hierarchical / unbound modes, drag-and-drop, multi-selection, edit forms, validation |
| [wpf-devexpress-pivot-grid](pivot-grid/wpf-devexpress-pivot-grid/) | `PivotGridControl` — Row / Column / Data / Filter areas, OLAP, server mode, aggregation, drill-down, KPI, conditional formatting |
| [wpf-devexpress-property-grid](property-grid/wpf-devexpress-property-grid/) | `PropertyGridControl` — `SelectedObject(s)`, `PropertyDefinition`, `CollectionDefinition`, `CategoryDefinition`, expandable nested types |

### Editors & input

| Skill | Covers |
|---|---|
| [wpf-devexpress-data-editors](data-editors/wpf-devexpress-data-editors/) | 30+ editors — `TextEdit`, `ButtonEdit`, `ComboBoxEdit`, `DateEdit`, `SpinEdit`, `LookUpEdit`, `PasswordBoxEdit`, `ColorEdit`, `RatingEdit`, `BarCodeEdit`, and more — plus simple controls (`SimpleButton`, `DropDownButton`, `FlyoutControl`, `RangeControl`, `Calculator`) |

### Layout & navigation

| Skill | Covers |
|---|---|
| [wpf-devexpress-layout-management](layout-management/wpf-devexpress-layout-management/) | Six layout containers — `DockLayoutManager`, `LayoutControl`, `DataLayoutControl`, `TileLayoutControl`, `FlowLayoutControl`, `DockLayoutControl`; layout persistence |
| [wpf-devexpress-ribbon-and-bars](ribbon-and-bars/wpf-devexpress-ribbon-and-bars/) | `RibbonControl`, toolbars, menus — Office-style ribbon, `ToolBarControl` / `MainMenuControl` / `StatusBarControl`, `BarManager`, Quick Access Toolbar, BackstageView, MDI merging |
| [wpf-devexpress-accordion](accordion/wpf-devexpress-accordion/) | `AccordionControl` — hierarchical sidebar, Navigation Pane mode, built-in search, collapsed glyph-only strip |
| [wpf-devexpress-tab-control](tab-control/wpf-devexpress-tab-control/) | `DXTabControl` — MultiLine / Scroll / Stretch views, drag-drop reordering, accent colors, close / pin |

### Visualization & specialized

| Skill | Covers |
|---|---|
| [wpf-devexpress-charts](charts/wpf-devexpress-charts/) | `ChartControl` (2D) — XY / Polar / Radar / Simple diagrams, 15+ series types, primary/secondary axes, legend, tooltip, crosshair, aggregation |
| [wpf-devexpress-scheduler](scheduler/wpf-devexpress-scheduler/) | `SchedulerControl` — seven view types (Day / Work Week / Week / Month / Timeline / Agenda / List), appointments, resources, labels, statuses, time regions, recurrence, reminders, time zones |
| [wpf-devexpress-loading-indicators](loading-indicators/wpf-devexpress-loading-indicators/) | `SplashScreenManager`, `LoadingDecorator`, `WaitIndicator` — decision guide for picking the right indicator; migration from legacy `DXSplashScreen` |
| [wpf-devexpress-ai-chat-control](ai-chat-control/wpf-devexpress-ai-chat-control/) | `AIChatControl` — Copilot-style chat UI; Azure OpenAI / OpenAI / Ollama / Semantic Kernel via `IChatClient`; streaming, Markdown, file upload, prompt suggestions, history |

### Cross-cutting

| Skill | Covers |
|---|---|
| [wpf-devexpress-mvvm](mvvm/wpf-devexpress-mvvm/) | View-model strategies (`[GenerateViewModel]` source generator, `ViewModelSource`, `ViewModelBase`, `BindableBase`); `DelegateCommand` / `AsyncCommand`; 25+ predefined services (`IMessageBoxService`, `IDialogService`, `IDocumentManagerService`, `INotificationService`, …); behaviors (`EventToCommand`, `KeyToCommand`, `FocusBehavior`, …); `Messenger` |

---

## Skill layout

Each skill is self-contained and follows the same structure:

```
<group>/wpf-devexpress-<name>/
├── SKILL.md       — YAML frontmatter (activators, prerequisites), navigation guide
├── references/    — topic-focused deep dives (data binding, editing, export, …)
└── examples/      — runnable quickstart (XAML + C# + App startup)
```

`SKILL.md` is loaded by the AI agent; `references/` is consulted on demand for deeper topics; `examples/` provides drop-in code for a minimal working sample.

## Prerequisites

- **.NET 6 / 7 / 8+** (`net6.0-windows`, `net7.0-windows`, or `net8.0-windows`) or **.NET Framework 4.6.2+**
  - Exception: `wpf-devexpress-ai-chat-control` requires .NET 8+
- **DevExpress NuGet packages** — published on `nuget.org`
- A valid **DevExpress license**
- For `wpf-devexpress-ai-chat-control` — project SDK `Microsoft.NET.Sdk.Razor` and the WebView2 runtime
- For Ribbon, Tab Control, and AI Chat Control — the host window must be `dx:ThemedWindow` (not plain `System.Windows.Window`)

## Installation

Copy individual skill folders (the `wpf-devexpress-*` directories) into `~/.claude/skills/`, or reference them from a project-level `.claude/settings.json`. Each skill is independent — install only the ones you need.

## Versioning

Each `SKILL.md` pins the docs commit it was built against via `metadata.source-commit` in YAML frontmatter, so the content is reproducible against a known state of the DevExpress WPF docs repository.
