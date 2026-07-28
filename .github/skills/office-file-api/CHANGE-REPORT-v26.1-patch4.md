# Skill Change Report — v26.1 Patch 4

**Date**: 2026-06-03  
**Baseline commit**: `ed145afcf2b6422fb9b2dd475324ed80ed62ee4d` (patch 2)  
**New source-commit**: `4996a6d4ed2ebb3e13fa6c4d6c1bd5c7257cc358`  
**Skills updated**: 3 (`devexpress-office-file-api-word-processing`, `devexpress-office-file-api-spreadsheet`, `devexpress-office-file-api-pdf-new`)

> Patch 3 was a rename-only patch (no content changes). Patch 4 applies the feedback from `skills/office-file-api-skill-update-instructions.md`.

---

## Word Processing — New Reference Files

### `references/document-security.md` (new)
Covers document protection and encryption:
- `Document.Protect(DocumentProtectionType)` — restrict editing (read-only, allow comments, forms only)
- `Section.ProtectedForForms` — per-section form protection
- Range permissions: `RangePermissionCollection`, `RangePermission.UserName` / `.Group`
- File encryption: `Document.Encryption` (`EncryptionSettings`) — AES-256, open/modify passwords
- Opening encrypted files: `EncryptedFilePasswordRequested` event, `BeforeImport` options

### `references/shapes-and-images.md` (new)
Covers floating objects:
- `ShapeCollection.InsertShape(ShapeGeometryPreset, AnchorPoint, float, float)` — geometric shapes
- `ShapeCollection.InsertPicture(AnchorPoint, DocumentImageSource)` — images from file/stream/bytes
- `InsertTextBox(AnchorPoint, float, float)` + `ShapeFormat.TextBox.Document` — text boxes
- `InsertGroup` / `GroupItems.Ungroup` — shape groups
- Charts via `InsertChart` + `OfficeCharts.Instance.ActivateCrossPlatformCharts()`
- Wrapping, position, rotation, accessibility (alt text)

### `references/page-setup.md` (new)
Covers section and page layout:
- `SectionPage.PaperKind` (`DXPaperKind`) and `SectionPage.Landscape`
- `SectionMargins` (Left/Top/Right/Bottom, Gutter, MirrorMargins)
- Section insertion: `Document.AppendSection()`, `Document.InsertSection()`, `Section.StartType`
- Page breaks: `Characters.PageBreak`
- Page numbering: `SectionPageNumbering`
- Multi-column: `SectionColumns.CreateUniformColumns`

### `references/getting-started.md` (updated)
Added "Register Custom Fonts" section:
- `DXFontRepository.Instance.AddFont(path)` — register fonts before creating `RichEditDocumentServer`
- `QueryNotFoundFont` event for runtime font detection

### `SKILL.md` (updated)
Added navigation entries for the three new reference files.

---

## Spreadsheet — New Reference File + Content Updates

### `references/worksheet-operations.md` (new)
Covers basic worksheet management:
- Add: `Worksheets.Add(name)`, `Worksheets.Insert(index, name)`
- Remove: `worksheet.Remove()`, `Worksheets.RemoveAt(index)`
- Rename: `worksheet.Name`
- Copy: `worksheet.CopyFrom(source)`
- Move: `worksheet.Move(index)`
- Access/navigate: `Worksheets[name]`, `Worksheets[index]`, `workbook.ActiveWorksheet`
- Show/hide: `Worksheet.Visible` (`VisibilityType`, including `VeryHidden`)

### `references/formulas.md` (updated)
Merged content from deleted `dynamic-array-formulas.md`:
- New "Dynamic Array Formulas (v26.1+)" section with `worksheet.Cells["A1"].SetValue(new DynamicArrayFormula("=SORT(...)"))` and `GetSpillRange()` example
- Table of 6 supported functions: XLOOKUP, XMATCH, SORT, SORTBY, FILTER, UNIQUE
- Note that legacy functions like `LEN` and `TRANSPOSE` can also spill

### `references/dynamic-array-formulas.md` (deleted)
Content merged into `formulas.md`.

### `references/cell-formatting.md` (updated)
Added "Rich Text Formatting" section:
- `RichTextString` / `AddTextRun(text, RichTextRunFont)` — build formatted cell value
- `cell.GetRichText()` / `Characters(start, length).Font` — modify existing rich text

### `references/getting-started.md` (updated)
Added "Custom Fonts (DXFontRepository)" section:
- `DXFontRepository.Instance.AddFont(path)` before workbook load

### `references/advanced-features.md` (updated)
Added three new sections:

| New section | Key API |
|-------------|---------|
| Data Sorting | `AutoFilter.Apply(range)`, `SortState.Sort(colIndex, descending)`, multi-column `Sort(List<SortCondition>)` |
| Data Filtering | `ApplyCustomFilter(FilterComparisonOperator)`, `ApplyFilterCriteria(values[])`, `Clear()`, `Disable()` |
| Grouping and Outlines | `Rows.Group(start, end, collapsed)`, `Columns.Group(...)`, `Rows.UnGroup(...)` |

### `SKILL.md` (updated)
- Added navigation entry for `worksheet-operations.md`
- Removed navigation entry for deleted `dynamic-array-formulas.md`
- Updated Formulas, Cell Formatting, Getting Started, and Advanced Features nav entries

---

## New PDF — API Corrections

All changes fix incorrect API usage identified during review.

### Global — `AddTextFragment` → `AddFragment`
Replaced across all reference files and `examples/quickstart.cs`.

### `references/getting-started.md` and `examples/quickstart.cs`
- `AddTextFragment` → `AddFragment`
- Image loading: `DXImage.FromFile(...)` → `DXImage.FromStream(File.OpenRead(...))`
- Removed `Size` parameter from `DXImageFragment` constructor
- Removed `using DevExpress.Docs.Office` (incorrect namespace for PDF types)
- Fixed Key Namespaces table: `TextFont`/`TextFontStyle` moved from `DevExpress.Docs.Office` to `DevExpress.Docs.Pdf`

### `references/add-content.md`
- `TextFragment.Font`: `new DXFont(...)` → `new TextFont(...)`
- `ImageFragment`: constructor now accepts `DXImage` instance
- `PathFragment` rectangle: removed `Pen`/`Brush`; replaced with `Fill.CreateSolid(...)` and `Outline.Create(...)`
- Form fragment: `AddFormFragment(...)` → `AddFragment(...)`

### `references/form-fields.md`
- All 5 widget annotation types: bounds now passed via constructor
- `ListBoxWidgetAnnotation.Color` and `SignatureWidgetAnnotation.BorderColor`: `System.Drawing.Color` → `PdfColor`
- Form data: `Import` → `ImportFormData`, `Export` → `ExportFormData`
- Removed "Flatten Form Fields" example

### `references/metadata-attachments.md`
- Standard properties: `document.Metadata.Title` → `document.Metadata.DocumentInfo.Title`
- XMP: `Metadata.XmpMetadata` → `Metadata.Xmp`; `SynchronizeToXmp()` → `Metadata.Synchronize(MetadataSyncMode.InfoToXmp)`
- `Attachment` constructor: corrected to `new Attachment("filename", data)` + `.Description` property
- ZUGFeRD: replaced legacy example with `document.AttachZugferdInvoice(invoiceXml)` (`byte[]` overload)

### `references/search-replace-redact.md`
- `TextSearchOptions`: `caseSensitive` → `matchCase`, `wholeWords` → `wholeWordOnly`
- Format search results: replaced invalid property assignments with `TextFragment.Font = new TextFont(...)` and `TextFragment.ForegroundFill = Fill.CreateSolid(PdfColor.Red)`

### `references/structure-tree.md`
- Removed all `using DevExpress.Docs.Office` directives from code blocks
- `Pdf17StructureTypeDescriptor.X` → `Pdf17StructureType.X` (enum, not static class)
- `element.AddTextFragment(...)` → `element.AddFragment(...)`

---

## Requires Manual Review

None.

---

## New Features — Not Yet Covered in Skills

None identified in this patch.

---

*Generated by `devexpress-doc-skill-updater`. All API names verified against `articles/`, `examples/`, and `apidoc/` in the documentation repository.*
