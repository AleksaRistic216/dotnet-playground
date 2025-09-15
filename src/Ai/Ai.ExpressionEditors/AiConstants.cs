using Microsoft.Extensions.AI;

namespace Ai.ExpressionEditors {
    internal static class AiConstants {
        internal static readonly Dictionary<AiProvider, List<string>> MODELS = new() {
            { AiProvider.OpenAi, [ "gpt-4.1", "gpt-5-2025-08-07", "gpt-5-mini-2025-08-07" ] },
        };
    }
}
