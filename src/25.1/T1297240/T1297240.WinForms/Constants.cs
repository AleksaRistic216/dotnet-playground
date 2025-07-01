namespace T1297240.WinForms
{
	internal static class Constants
	{
		internal static readonly Dictionary<string, string> HiddenCharsMap = new Dictionary<
			string,
			string
		>
		{
			// No-Break Space
			{ "\u00A0", "<0xA0>" },
			// Soft Hyphen
			{ "\u00AD", "<0xAD>" },
			// Arabic Letter Mark
			{ "\u061C", "<0x61C>" },
			// Mongolian Vowel Separator
			{ "\u180E", "<0x180E>" },
			// Zero Width characters e formatação
			{ "\u200B", "<0x200B>" }, // Zero Width Space
			{ "\u200C", "<0x200C>" }, // Zero Width Non-Joiner
			{ "\u200D", "<0x200D>" }, // Zero Width Joiner
			{ "\u200E", "<0x200E>" }, // Left-to-Right Mark
			{ "\u200F", "<0x200F>" }, // Right-to-Left Mark
			// Directional formatting
			{ "\u202A", "<0x202A>" }, // Left-to-Right Embedding
			{ "\u202B", "<0x202B>" }, // Right-to-Left Embedding
			{ "\u202C", "<0x202C>" }, // Pop Directional Formatting
			{ "\u202D", "<0x202D>" }, // Left-to-Right Override
			{ "\u202E", "<0x202E>" }, // Right-to-Left Override
			// Word Joiner
			{ "\u2060", "<0x2060>" },
			// Mathematical invisible operators
			{ "\u2062", "<0x2062>" }, // Invisible Times
			{ "\u2063", "<0x2063>" }, // Invisible Separator
			{ "\u2064", "<0x2064>" }, // Invisible Plus
			// Directional isolates
			{ "\u2066", "<0x2066>" }, // Left-to-Right Isolate
			{ "\u2067", "<0x2067>" }, // Right-to-Left Isolate
			{ "\u2068", "<0x2068>" }, // First Strong Isolate
			{ "\u2069", "<0x2069>" }, // Pop Directional Isolate
			// Variation Selectors (mais comuns)
			{ "\uFE00", "<0xFE00>" },
			{ "\uFE01", "<0xFE01>" },
			{ "\uFE02", "<0xFE02>" },
			{ "\uFE03", "<0xFE03>" },
			{ "\uFE04", "<0xFE04>" },
			{ "\uFE05", "<0xFE05>" },
			{ "\uFE06", "<0xFE06>" },
			{ "\uFE07", "<0xFE07>" },
			{ "\uFE08", "<0xFE08>" },
			{ "\uFE09", "<0xFE09>" },
			{ "\uFE0A", "<0xFE0A>" },
			{ "\uFE0B", "<0xFE0B>" },
			{ "\uFE0C", "<0xFE0C>" },
			{ "\uFE0D", "<0xFE0D>" },
			{ "\uFE0E", "<0xFE0E>" },
			{ "\uFE0F", "<0xFE0F>" },
			// Zero Width No-Break Space (BOM)
			{ "\uFEFF", "<0xFEFF>" },
		};
	}
}
