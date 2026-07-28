# Skills Change Report — v26.1 Patch 1

**Generated**: 2026-05-20  
**Source**: `skills/feedback.md` (colleague review feedback)  
**Commit**: `160d58280` (branch `with-skills`)  
**Previous report**: `CHANGE-REPORT-v26.1.md`

---

## Summary

| Skill | Scope | Files Changed |
|-------|-------|---------------|
| `devexpress-office-file-api-presentation` | **Breaking change fix + wrong package name** | 6 files |
| `devexpress-office-file-api-word-processing` | SkiaRenderer cleanup | 4 files |
| `devexpress-office-file-api-spreadsheet` | SkiaRenderer cleanup | 5 files |

---

## Detailed Changes

### devexpress-office-file-api-presentation — Major Fix

**Root causes from feedback:**

1. **Wrong NuGet package** — skill used `DevExpress.Document.Processor` instead of `DevExpress.Docs.Presentation`
2. **Unnecessary dependency** — `DevExpress.Pdf.SkiaRenderer` was listed as required but is not needed for presentations
3. **Breaking change not applied** — v26.1 moved ~50 types from `DevExpress.Docs.Presentation` to `DevExpress.Docs.Office`. Code examples were missing `using DevExpress.Docs.Office;` and used the renamed type `ParagraphProperties` (now `TextParagraphProperties`)

**`SKILL.md`:**
- NuGet table: `DevExpress.Document.Processor` → `DevExpress.Docs.Presentation`; removed `DevExpress.Pdf.SkiaRenderer` row
- `dotnet add` command: updated to `DevExpress.Docs.Presentation`; removed SkiaRenderer line
- Quick Start code block: added `using DevExpress.Docs.Office;`
- Troubleshooting table: removed "PDF export produces no output / Missing SkiaRenderer" row
- Constraints rule 2: `DevExpress.Document.Processor` → `DevExpress.Docs.Presentation`; removed SkiaRenderer mention
- Constraints rule 3: added `using DevExpress.Docs.Office;` to required namespaces

**`references/getting-started.md`:**
- Installation section: `DevExpress.Document.Processor` → `DevExpress.Docs.Presentation` (CLI and Package Manager Console); removed SkiaRenderer install lines
- Complete example code block: added `using DevExpress.Docs.Office;`

**`references/slides-and-shapes.md`:**
- API types table: `ParagraphProperties` → `TextParagraphProperties` (with namespace note)
- Shapes code block (`// Shape(ShapeType...)`): added `using DevExpress.Docs.Office;`
- Tables code block (`// Table(rowCount...)`): added `using DevExpress.Docs.Office;`
- Paragraph formatting section: `new ParagraphProperties` → `new TextParagraphProperties` (2 occurrences)
- Bullet lists section: `new ParagraphProperties` → `new TextParagraphProperties` (2 occurrences)

**`references/advanced-features.md`:**
- "Search Text Across the Entire Presentation" code block: added `using DevExpress.Docs.Office;`
- Footer styling fragment: `new ParagraphProperties` → `new TextParagraphProperties`

**`references/export.md`:**
- Printing note: removed sentence "The `DevExpress.Pdf.SkiaRenderer` NuGet package is required for cross-platform print rendering"
- Troubleshooting: removed "PDF export is blank or missing content / Verify SkiaRenderer is installed" bullet

**`examples/quickstart.cs`:**
- Header comment: `DevExpress.Document.Processor` → `DevExpress.Docs.Presentation`; removed SkiaRenderer line
- Added `using DevExpress.Docs.Office;` to imports
- `new ParagraphProperties` → `new TextParagraphProperties`
- Display text string: `"DevExpress.Document.Processor"` → `"DevExpress.Docs.Presentation"`
- PDF export comment: removed SkiaRenderer mention

---

### devexpress-office-file-api-word-processing — SkiaRenderer Cleanup

Removed all references to `DevExpress.Pdf.SkiaRenderer` — it is not required for PDF export.

**`SKILL.md`:**
- NuGet table: removed `DevExpress.Pdf.SkiaRenderer` row
- `dotnet add` commands: removed SkiaRenderer line
- Troubleshooting: removed "`FileNotFoundException` for SkiaSharp" row
- Constraints rule 3: removed SkiaRenderer mention

**`references/getting-started.md`:**
- Installation section: removed SkiaRenderer from CLI and Package Manager Console install commands

**`references/getting-started-dotnet-fw.md`:**
- .NET Framework vs .NET comparison table: "Also requires `DevExpress.Pdf.SkiaRenderer`" → "Included in `DevExpress.Document.Processor`"

**`references/export.md`:**
- Troubleshooting: removed "`FileNotFoundException` for SkiaSharp on .NET 6+" row

**`examples/quickstart.cs`:**
- Header comment: removed SkiaRenderer install instruction

---

### devexpress-office-file-api-spreadsheet — SkiaRenderer Cleanup

Removed all references to `DevExpress.Pdf.SkiaRenderer` — it is not required for PDF export.

**`SKILL.md`:**
- NuGet table: removed `DevExpress.Pdf.SkiaRenderer` row
- `dotnet add` commands: removed SkiaRenderer line
- .NET Framework note: removed "SkiaRenderer is not required" mention (implied by removal)
- Getting Started nav entry: "no SkiaRenderer" wording removed
- Quick Start example: removed `// Export to PDF ... requires DevExpress.Pdf.SkiaRenderer` comment
- Troubleshooting: removed "`FileNotFoundException` for SkiaSharp" row
- Constraints rule 2: removed SkiaRenderer mention
- Constraints rule 7: removed "SkiaRenderer only for .NET" clause

**`references/getting-started.md`:**
- Installation section: removed SkiaRenderer from CLI and Package Manager Console commands

**`references/getting-started-dotnet-fw.md`:**
- "When to Use" bullet: updated wording (removed "without SkiaRenderer")
- .NET Framework note: updated wording
- Code comment: removed "no SkiaRenderer needed" comment
- Key Differences table: removed SkiaRenderer row; updated NuGet package column; updated PDF rendering column

**`references/export.md`:**
- Platform Notes table: "Requires `DevExpress.Pdf.SkiaRenderer`" → "Supported" for both `ExportToPdf` and `ExportToImage`
- Troubleshooting: removed "Skia not found" bullet

**`examples/quickstart.cs`:**
- Header comment: removed SkiaRenderer NuGet and install lines
- PDF export section: removed "Requires SkiaRenderer" comment
- `catch` block: removed SkiaRenderer suggestion message

---

## Breaking Change Reference

The following v26.1 types moved from `DevExpress.Docs.Presentation` to `DevExpress.Docs.Office`. Any code using these types must add `using DevExpress.Docs.Office;`.

**Renames** (old name no longer exists):

| Old name | New name |
|----------|----------|
| `ParagraphCollection` | `TextParagraphCollection` |
| `ParagraphProperties` | `TextParagraphProperties` |
| `TextAreaBase` | `OfficeTextArea` |
| `TextRunBase` | `OfficeTextRun` |
| `TextRunStringBase` | `OfficeTextRunString` |

**Moved without rename** (representative list — full list in `skills/feedback.md`):

`TextArea`, `TextParagraph`, `TextRun`, `TextProperties`, `TextFont`, `TextRange`, `TextSearchOptions`, `TextSearchInfo`, `SolidFill`, `GradientFill`, `NoFill`, `Fill`, `OutlineStyle`, `EffectProperties`, `GlowEffect`, `OuterShadowEffect`, and ~40 more.

**Fix**: Add `using DevExpress.Docs.Office;` alongside `using DevExpress.Docs.Presentation;` in any file that references these types.

---

## No Changes Required

| Skill | Reason |
|-------|--------|
| `devexpress-office-file-api-pdf` | No presentation types; SkiaRenderer not mentioned |
| `devexpress-office-file-api-pdf-new` | Uses `DevExpress.Docs.Pdf` types only |
| `devexpress-office-file-api-barcode` | No affected types |
| `devexpress-office-file-api-zip` | No affected types |
| `devexpress-office-file-api-ai-powered-extensions` | No affected types |
| `devexpress-office-file-api-excel-export` | No affected types |
| `devexpress-office-file-api-unit-conversion` | No affected types |
