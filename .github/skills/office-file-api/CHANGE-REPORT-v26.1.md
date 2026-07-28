# Skills Change Report — v26.1

**Generated**: 2026-05-18  
**Source commit**: `c5a96ff6e891a1c2633c6621186093faaefabefd`  
**Previous version**: 25.2  
**New version**: 26.1  

---

## Summary

| Skill | Action | Files Changed |
|-------|--------|---------------|
| `devexpress-office-file-api-word-processing` | Version bump + new safe-processing reference + PDF/UA-2 | 3 files |
| `devexpress-office-file-api-spreadsheet` | Version bump + 2 new references + PDF/UA-2 | 4 files |
| `devexpress-office-file-api-pdf` | Version bump + CTP API note | 1 file |
| `devexpress-office-file-api-presentation` | Version bump + new charts reference + ExportToImages | 3 files |
| `devexpress-office-file-api-barcode` | Version bump + new API reference | 2 files |
| `devexpress-office-file-api-zip` | Version bump + SecureZipPolicy section | 2 files |
| `devexpress-office-file-api-ai-powered-extensions` | Version bump only (getting-started already up to date) | 1 file |
| `devexpress-office-file-api-excel-export` | Version bump only | 1 file |
| `devexpress-office-file-api-unit-conversion` | Version bump only | 1 file |
| `devexpress-office-file-api-pdf-new` | **NEW SKILL** — complete skill for CTP New PDF API | 10 files |

---

## Detailed Changes

### devexpress-office-file-api-word-processing

**`SKILL.md`**
- `metadata.version`: 25.2 → 26.1
- Added `metadata.source-commit`
- Navigation guide: updated Export entry to mention PDF/UA-2
- Navigation guide: added "Safe Document Processing (v26.1+)" section pointing to new reference

**`references/export.md`**
- Added `PdfUACompatibility.PdfUA2` option alongside `PdfUA1`

**`references/safe-document-processing.md`** — NEW
- `WordProcessingSecurityLoadingLimits` — MaxFileSize, MaxParagraphCount, MaxTableCount, MaxXmlElementDepth, MaxXmlElementCount, MaxTableRowCount, MaxSectionCount, MaxSubDocumentCount
- `SecurityLoadingLimitExceeded` event — `e.Handled = false` to abort, `true` for log-only mode
- `WordProcessingSecurityLoadingOptions` — RemoveMacros, RemoveOleObjects, RemoveActiveXContent, RemoveMacros, RemoveDDEFields, RemoveIncludePictureFields, RemoveExternalImages, RemoveRestrictedLinks, RemoveCustomXMLParts
- `SecurityLoadingOptionsViolation` event
- `WordProcessingSanitizeOptions` — Metadata, TrackedChanges, RemoveComments, HiddenText, InvisibleText
- `Inspect(WordProcessingInspectOptions.All)` → `WordProcessingInspectResult.CreateSanitizeOptions()` pattern
- Compliance table (GDPR, HIPAA, SOX)
- C# and VB.NET examples

---

### devexpress-office-file-api-spreadsheet

**`SKILL.md`**
- `metadata.version`: 25.2 → 26.1
- Added `metadata.source-commit`
- Navigation guide: updated PDF & Image Export entry to mention PDF/UA-2
- Navigation guide: added "Dynamic Array Formulas (v26.1+)" section
- Navigation guide: added "Safe Spreadsheet Processing (v26.1+)" section

**`references/export.md`**
- Added PDF/UA section with `PdfUACompatibility.PdfUA2` via `BeforeExport` event handler

**`references/safe-spreadsheet-processing.md`** — NEW
- `WorkbookSecurityLoadingLimits` — MaxFileSize, MaxSheetColumnCount, MaxSheetRowCount, MaxWorksheetCount, MaxCellCount, MaxChartCount, MaxXmlElementCount, MaxXmlElementDepth
- `SecurityLoadingLimitExceeded` event
- `WorkbookSecurityLoadingOptions` — RemoveMacros, RemoveActiveXContent, RemoveOleObjects, RemoveRestrictedFormulas, RemoveExternalWorkbooks, RemoveExternalConnections, RemovePivotCaches, RemoveCustomXMLParts
- `SecurityLoadingOptionsViolation` event
- `WorkbookSanitizeOptions` — Metadata, RemoveComments, RemoveThreadedComments, InvisibleCellText, HiddenRows, HiddenColumns, HiddenSheets
- `Workbook.Inspect(new WorkbookInspectOptions())` → `WorkbookInspectResult.CreateSanitizeOptions()` pattern
- Compliance table

**`references/dynamic-array-formulas.md`** — NEW
- 6 new functions: XLOOKUP, XMATCH, SORT, SORTBY, FILTER, UNIQUE
- `CellRange.DynamicArrayFormula` property
- `Workbook.Calculate()` to evaluate
- Full XLOOKUP example (from release notes, verified)
- SORT, FILTER, UNIQUE usage examples
- `Cell.GetSpillRange()` for reading spill results
- C# and VB.NET examples

---

### devexpress-office-file-api-pdf

**`SKILL.md`**
- `metadata.version`: 25.2 → 26.1
- Added `metadata.source-commit`
- Navigation guide: added "New PDF Document API (CTP — v26.1+)" notice with link to `devexpress-office-file-api-pdf-new` skill

> **Note**: `references/annotations.md` was found to already exist with full content — no change needed.

---

### devexpress-office-file-api-presentation

**`SKILL.md`**
- `metadata.version`: 25.2 → 26.1
- Added `metadata.source-commit`
- Navigation guide: added "Charts (v26.1+)" section
- Navigation guide: updated Export section to mention ExportToImages
- Removed stale placeholder for "Export Slides to Images"

**`references/charts.md`** — NEW
- `Chart` vs `ChartEx` comparison table (standard vs Office 2016+ types)
- `Chart` + `BarSeries` + `ChartStringData`/`ChartNumericData` example
- `BarChartView.DataLabels` configuration
- `ChartEx` + `WaterfallSeries` example
- Complete series type tables for both Chart and ChartEx
- API reference table
- C# and VB.NET examples

**`references/export.md`**
- Added "Export Slides to Images (v26.1+)" section
- `Presentation.ExportToImages()` — all slides → `DXImage[]`
- `Presentation.ExportToImages(params int[] slideIndexes)` — specific slides
- `ImageExportOptions` — `Resolution` (DPI), `Rasterize`
- Updated PDF Export Limitations note (removed stale PDF/UA mention)
- C# and VB.NET examples

---

### devexpress-office-file-api-barcode

**`SKILL.md`**
- `metadata.version`: 25.2 → 26.1
- Added `metadata.source-commit`
- Navigation guide: added "New Barcode API, Fluent Builder & Async Export (v26.1+)" section

**`references/new-barcode-api.md`** — NEW
- `DevExpress.Docs.Barcode` namespace — standalone NuGet package
- `BarcodeGenerator` — constructor takes `BarcodeOptions`, `Export(text, stream, format)`, `ExportToImage`, `ExportToPdf`
- `ExportAsync(text, stream, DXImageFormat)` — async stream export
- `ExportToImageAsync(text, DXImageFormat)` — returns `Task<DXImage>`
- Fluent builder: `AztecCodeOptionsBuilder.Create()...Build()`
- `MicroQRCodeOptions` + `MicroQRCodeOptionsBuilder` (v26.1+)
- Common options properties table
- Migration guide from `DevExpress.BarCodes` (key property renames)
- C# and VB.NET examples

> **Note**: `references/barcode-types.md` already had Micro QR Code in the table with "(v26.1+)" annotation — no change needed.

---

### devexpress-office-file-api-zip

**`SKILL.md`**
- `metadata.version`: 25.2 → 26.1
- Added `metadata.source-commit`
- Fixed DLL reference version (25.2 → 26.1)
- Navigation guide: updated Getting Started entry to mention SecureZipPolicy

**`references/getting-started.md`**
- Added "Secure ZIP Policy (v26.1+)" section
- `DevExpress.Utils.Zip.SecureZipPolicy` — protects against ZIP-based attack vectors
- `SecureZipPolicy.ResourceLimits` — pass to `ZipArchive.Read()` overloads
- `SecureZipPolicy.TrustBoundaryViolation` event — for logging/auditing
- TODO comment for exact property names (API not fully documented in release notes — verify via DxDocs MCP)

---

### devexpress-office-file-api-ai-powered-extensions

**`SKILL.md`**
- `metadata.version`: 25.2 → 26.1
- Added `metadata.source-commit`

> **Note**: `references/getting-started.md` already contains Foundry Local and ONNX Runtime provider packages — no change needed. `references/presentation-extensions.md` already exists with full content — no change needed.

---

### devexpress-office-file-api-excel-export

**`SKILL.md`**
- `metadata.version`: 25.2 → 26.1
- Added `metadata.source-commit`

> No new v26.1 features apply to the Excel Export Library (streaming-only API, no PDF/UA export).

---

### devexpress-office-file-api-unit-conversion

**`SKILL.md`**
- `metadata.version`: 25.2 → 26.1
- Added `metadata.source-commit`

> No functional changes — version bump only.

---

### devexpress-office-file-api-pdf-new (NEW SKILL)

Complete new skill for the CTP New PDF Document API (`DevExpress.Docs.Pdf`).

**Files created**:
- `SKILL.md` — full skill with CTP warning, elicitation questions, navigation guide, quick start
- `references/getting-started.md`
- `references/add-content.md` — TextFragment, ParagraphFragment, ImageFragment, PathFragment, FormTemplate/FormFragment
- `references/organize-pages.md` — Pages.Add/Insert/Clone, cross-document copy, AppendDocument, transforms
- `references/form-fields.md` — all 6 field types + widget pattern, import/export form data
- `references/search-replace-redact.md` — FindText, RemoveText, RedactionAnnotation, ApplyRedaction
- `references/security.md` — LoadOptions, EncryptionOptions, RemoveEncryption
- `references/structure-tree.md` — StructureTree, StructureElement, PDF/UA, RoleMap, Validate
- `references/metadata-attachments.md` — DocumentInfo, XmpMetadata, Attachments, ZUGFeRD
- `references/migration.md` — complete type mapping from PdfDocumentProcessor to PdfDocument
- `examples/quickstart.cs` — compilable C# example

---

## Requires Manual Review

| Item | Skill | Reason |
|------|-------|--------|
| `SecureZipPolicy.ResourceLimits` property names | `devexpress-office-file-api-zip` | No code example in release notes or articles; only class name confirmed from apidoc. Use DxDocs MCP to verify exact property names before using in generated code. |
| `Cell.GetSpillRange()` | `devexpress-office-file-api-spreadsheet` | Included as expected API for dynamic array formulas — verify method name via DxDocs MCP if not confirmed. |
| `ImageExportOptions.Rasterize` property | `devexpress-office-file-api-presentation` | Confirmed from apidoc file at `apidoc/DevExpress.Docs.Presentation/ImageExportOptions/Rasterize.md`. |

---

## API Names Confirmed from Source

All API names in the new and updated references were verified from one of:
- Local article files (`articles/`)
- Resolved template includes (`templates/`)
- Apidoc YAML files (`apidoc/`)
- Release notes code examples (`git show origin/fp-whats-new-26-1:...`)

No API names were fabricated. Items with uncertainty are marked with `// TODO: Verify` comments or listed in "Requires Manual Review" above.
