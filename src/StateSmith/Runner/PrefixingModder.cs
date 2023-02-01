﻿using StateSmith.compiler.Visitors;
using StateSmith.Compiling;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using StateSmith.compiler;

// spell-checker: ignore modder

#nullable enable

namespace StateSmith.Runner
{
    public class PrefixingModder : OnlyVertexVisitor
    {
        private const string AUTO_PREFIX_STRING = "prefix.auto(";
        private static readonly Regex addPrefixRegex = new(@"prefix.add\((\w+)\)");
        private static readonly Regex setPrefixRegex = new(@"prefix.set\((\w+)\)");

        private Stack<string> prefixStack = new();

        public static void Process(Statemachine sm)
        {
            new PrefixingModder().Visit(sm);
        }

        public PrefixingModder()
        {
            prefixStack.Push(""); // dummy
        }

        public override void Visit(Vertex v)
        {
            if (v is NamedVertex namedVertex)
            {
                HandleNamedVertex(namedVertex);
            }
        }

        private void HandleNamedVertex(NamedVertex state)
        {
            var activePrefix = prefixStack.Peek();
            state.Rename($"{activePrefix}{state.Name}");    // may rename to the same if no prefix
            
            string foundPrefix = GetPrefix(state, activePrefix);

            prefixStack.Push(foundPrefix);
            VisitChildren(state);
            prefixStack.Pop();
        }

        private static string GetPrefix(NamedVertex state, string prefix)
        {
            foreach (var b in state.GetBehaviorsWithTrigger("$cmd"))
            {
                string? newPrefix = MaybeGetPrefixFromBehavior(state, b, prefix);

                if (newPrefix != null)
                {
                    state.RemoveBehaviorAndUnlink(b);
                    prefix = newPrefix;
                    break;
                }
            }

            return prefix;
        }

        private static string? MaybeGetPrefixFromBehavior(NamedVertex state, Behavior b, string prefix)
        {
            string actionCode = b.actionCode;

            if (actionCode.Contains(AUTO_PREFIX_STRING))
            {
                return state.Name + "__"; // note that state name may have already been prefixed by parent at this point.
            }

            var match = addPrefixRegex.Match(actionCode);
            if (match.Success)
            {
                return prefix + match.Groups[1] + "__";
            }

            match = setPrefixRegex.Match(actionCode);
            if (match.Success)
            {
                return match.Groups[1] + "__";
            }

            return null;
        }
    }
}
