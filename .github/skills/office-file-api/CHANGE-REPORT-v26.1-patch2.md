# Skill Change Report — v26.1 Patch 2

**Date**: 2026-06-03  
**Baseline commit**: `c5a96ff6e891a1c2633c6621186093faaefabefd`  
**New source-commit**: `ed145afcf2b6422fb9b2dd475324ed80ed62ee4d`  
**Skills updated**: all 10

---

## Summary of Changes

### 1. NuGet Feed Removal (all 10 skills)

**Affected files** (one per skill):
- `devexpress-office-file-api-barcode/references/getting-started.md`
- `devexpress-office-file-api-pdf-new/references/getting-started.md`
- `devexpress-office-file-api-zip/references/getting-started.md`
- `devexpress-office-file-api-excel-export/references/getting-started.md`
- `devexpress-office-file-api-unit-conversion/references/getting-started.md`
- `devexpress-office-file-api-word-processing/references/getting-started.md`
- `devexpress-office-file-api-presentation/references/getting-started.md`
- `devexpress-office-file-api-ai-powered-extensions/references/getting-started.md`
- `devexpress-office-file-api-pdf/references/getting-started.md`
- `devexpress-office-file-api-spreadsheet/references/getting-started.md`

**Change**: Removed all references to `nuget.devexpress.com` (private NuGet feed). DevExpress packages are now available on **nuget.org** — no special feed configuration is required. The "Step 1: Add the DevExpress NuGet Feed" installation section was removed from each file. Remaining steps renumbered.

**Source article**: `articles/installation-guide/install-nuget-packages.md`

---

### 2. Barcode Skill — Public Fluent Builder API (v26.1+)

**Affected files**:
- `devexpress-office-file-api-barcode/SKILL.md`

**Changes**:
- **Prerequisites section**: Added `DevExpress.Docs.Barcode` as a standalone barcode-only NuGet package option alongside `DevExpress.Document.Processor`.
- **Common Patterns section**: Removed the obsolete note "`QRCodeOptionsBuilder` does not exist in v25.2. Always configure options by assigning properties directly." Replaced with two sub-patterns: direct assignment (always available) and fluent builder via `XxxOptionsBuilder.Create()...Build()` (v26.1+), pointing to `new-barcode-api.md` for details.
- **Micro QR Code note**: Updated from "Reference to be added in a future update" to point to `references/new-barcode-api.md`.

**Source articles**: `articles/barcode-generation-api/migrate-from-legacy-barcode-generation-api.md` and related barcode articles.

---

### 3. Presentation Skill — Chart Reference Expanded

**Affected files**:
- `devexpress-office-file-api-presentation/references/charts.md`

**Changes**: Added new sections covering 6 new documentation topics:

| New section | Source article |
|-------------|---------------|
| **When You Need to** (updated bullets) | `overview.md` |
| **Load Data from Embedded Spreadsheet Cells** | `load-data.md` |
| **Axes** (Chart — primary, secondary, scale, titles, labels, gridlines) | `chart/chart-axes.md` |
| **ChartEx Axes** (`CategoryAxisEx`, `ValueAxisEx`) | `chartex/chartex-axes.md` |
| **Data Labels** (view-level, series-level, per-point override, hide, number format) | `data-labels.md` |
| **Combo Charts** (mix Line + Bar + Area in one Chart) | `create-combo-chart.md` |
| **Error Bars and Trend Lines** (`ErrorBar`, `TrendLine`) | `chart/add-indicators.md` |

Also updated the **Key API** table with `ChartDataReference`, axis properties, `ErrorBar`, `TrendLine`.

---

### 4. Source-Commit Bump (all 10 skills)

Updated `metadata.source-commit` in all 10 `SKILL.md` files from `c5a96ff6e...` to `ed145afcf2...`.

---

## Patched Reference Files

| File | Change type |
|------|------------|
| `devexpress-office-file-api-barcode/SKILL.md` | Section update + prerequisites update |
| `devexpress-office-file-api-barcode/references/getting-started.md` | NuGet feed removal |
| `devexpress-office-file-api-pdf-new/references/getting-started.md` | NuGet feed removal |
| `devexpress-office-file-api-zip/references/getting-started.md` | NuGet feed removal |
| `devexpress-office-file-api-excel-export/references/getting-started.md` | NuGet feed removal |
| `devexpress-office-file-api-unit-conversion/references/getting-started.md` | NuGet feed removal |
| `devexpress-office-file-api-word-processing/references/getting-started.md` | NuGet feed removal |
| `devexpress-office-file-api-presentation/references/getting-started.md` | NuGet feed removal |
| `devexpress-office-file-api-ai-powered-extensions/references/getting-started.md` | NuGet feed removal |
| `devexpress-office-file-api-pdf/references/getting-started.md` | NuGet feed removal |
| `devexpress-office-file-api-spreadsheet/references/getting-started.md` | NuGet feed removal |
| `devexpress-office-file-api-presentation/references/charts.md` | New sections added |

---

## Already Up-to-Date (No Changes Needed)

These reference files were verified to already contain correct v26.1 content from the previous update session (patch 1):

| File | Status |
|------|--------|
| `devexpress-office-file-api-word-processing/references/safe-document-processing.md` | ✓ Complete |
| `devexpress-office-file-api-spreadsheet/references/safe-spreadsheet-processing.md` | ✓ Complete |
| `devexpress-office-file-api-spreadsheet/references/dynamic-array-functions.md` | ✓ Complete |
| `devexpress-office-file-api-barcode/references/new-barcode-api.md` | ✓ Complete (fluent builder, async, Micro QR) |
| `devexpress-office-file-api-pdf-new/references/redaction.md` | ✓ Complete |
| `devexpress-office-file-api-pdf-new/references/form-fields.md` | ✓ Complete |
| `devexpress-office-file-api-pdf-new/references/security.md` | ✓ Complete |
| `devexpress-office-file-api-pdf-new/references/structure-tree.md` | ✓ Complete |

---

## Requires Manual Review

None for this patch. The following items were verified as already covered in the skills.

---

## New Features — Not Yet Covered in Skills

The following new documentation topics were added in the 2026.1 cycle but do not yet have dedicated skill reference sections. They are flagged here for future reference:

| New article | Target skill | Suggested reference file |
|-------------|--------------|------------------------|
| `articles/security-considerations/fips-compliance.md` | Note briefly in spreadsheet, word, PDF skills | No standalone reference needed per instructions |
| `articles/presentation-api/slides/charts/chart/get-started.md` | devexpress-office-file-api-presentation | Covered by existing `charts.md` |
| `articles/presentation-api/slides/charts/chartex/get-started.md` | devexpress-office-file-api-presentation | Covered by existing `charts.md` |
