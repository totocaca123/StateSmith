//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from StateSmithLabelGrammar.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public partial class StateSmithLabelGrammarLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, LINE_ENDER=16, 
		IDENTIFIER=17, LINE_COMMENT=18, STAR_COMMENT=19, STRING=20, TICK_STRING=21, 
		BACKTICK_STRING=22, DIGIT=23, DOUBLE_QUOTE=24, SINGLE_QUOTE=25, BACKTICK=26, 
		PERIOD=27, COMMA=28, PLUS=29, DASH=30, COLON=31, GT=32, LT=33, OTHER_SYMBOLS=34, 
		HWS=35;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "LINE_ENDER", "IDENTIFIER", 
		"NOT_NL_CR", "LINE_COMMENT", "STAR_COMMENT", "ESCAPED_CHAR", "NON_QUOTE_CHAR", 
		"STRING_CHAR", "STRING", "TICK_STRING", "BACKTICK_STRING", "IDENTIFIER_NON_DIGIT", 
		"DIGIT", "DOUBLE_QUOTE", "SINGLE_QUOTE", "BACKTICK", "PERIOD", "COMMA", 
		"PLUS", "DASH", "COLON", "GT", "LT", "OTHER_SYMBOLS", "HWS"
	};


	public StateSmithLabelGrammarLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public StateSmithLabelGrammarLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'$STATEMACHINE'", "'$NOTES'", "'$ORTHO'", "'#'", "'entry'", "'exit'", 
		"'via'", "'('", "')'", "'['", "']'", "'/'", "'{'", "'}'", "'e'", null, 
		null, null, null, null, null, null, null, "'\"'", "'''", "'`'", "'.'", 
		"','", "'+'", "'-'", "':'", "'>'", "'<'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, "LINE_ENDER", "IDENTIFIER", "LINE_COMMENT", "STAR_COMMENT", 
		"STRING", "TICK_STRING", "BACKTICK_STRING", "DIGIT", "DOUBLE_QUOTE", "SINGLE_QUOTE", 
		"BACKTICK", "PERIOD", "COMMA", "PLUS", "DASH", "COLON", "GT", "LT", "OTHER_SYMBOLS", 
		"HWS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "StateSmithLabelGrammar.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static StateSmithLabelGrammarLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '%', '\xF7', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x4', '&', 
		'\t', '&', '\x4', '\'', '\t', '\'', '\x4', '(', '\t', '(', '\x4', ')', 
		'\t', ')', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', 
		'\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', 
		'\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', 
		'\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\x10', '\x3', '\x10', '\x3', 
		'\x11', '\x6', '\x11', '\x92', '\n', '\x11', '\r', '\x11', '\xE', '\x11', 
		'\x93', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\a', '\x12', '\x99', 
		'\n', '\x12', '\f', '\x12', '\xE', '\x12', '\x9C', '\v', '\x12', '\x3', 
		'\x13', '\x3', '\x13', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', 
		'\x14', '\a', '\x14', '\xA4', '\n', '\x14', '\f', '\x14', '\xE', '\x14', 
		'\xA7', '\v', '\x14', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', 
		'\x15', '\a', '\x15', '\xAD', '\n', '\x15', '\f', '\x15', '\xE', '\x15', 
		'\xB0', '\v', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', 
		'\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x17', '\x3', '\x17', '\x3', 
		'\x18', '\x3', '\x18', '\x5', '\x18', '\xBC', '\n', '\x18', '\x3', '\x19', 
		'\x3', '\x19', '\a', '\x19', '\xC0', '\n', '\x19', '\f', '\x19', '\xE', 
		'\x19', '\xC3', '\v', '\x19', '\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', 
		'\x3', '\x1A', '\a', '\x1A', '\xC9', '\n', '\x1A', '\f', '\x1A', '\xE', 
		'\x1A', '\xCC', '\v', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1B', 
		'\x3', '\x1B', '\a', '\x1B', '\xD2', '\n', '\x1B', '\f', '\x1B', '\xE', 
		'\x1B', '\xD5', '\v', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1C', 
		'\x3', '\x1C', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1E', '\x3', '\x1E', 
		'\x3', '\x1F', '\x3', '\x1F', '\x3', ' ', '\x3', ' ', '\x3', '!', '\x3', 
		'!', '\x3', '\"', '\x3', '\"', '\x3', '#', '\x3', '#', '\x3', '$', '\x3', 
		'$', '\x3', '%', '\x3', '%', '\x3', '&', '\x3', '&', '\x3', '\'', '\x3', 
		'\'', '\x3', '(', '\x3', '(', '\x3', ')', '\x6', ')', '\xF4', '\n', ')', 
		'\r', ')', '\xE', ')', '\xF5', '\x3', '\xAE', '\x2', '*', '\x3', '\x3', 
		'\x5', '\x4', '\a', '\x5', '\t', '\x6', '\v', '\a', '\r', '\b', '\xF', 
		'\t', '\x11', '\n', '\x13', '\v', '\x15', '\f', '\x17', '\r', '\x19', 
		'\xE', '\x1B', '\xF', '\x1D', '\x10', '\x1F', '\x11', '!', '\x12', '#', 
		'\x13', '%', '\x2', '\'', '\x14', ')', '\x15', '+', '\x2', '-', '\x2', 
		'/', '\x2', '\x31', '\x16', '\x33', '\x17', '\x35', '\x18', '\x37', '\x2', 
		'\x39', '\x19', ';', '\x1A', '=', '\x1B', '?', '\x1C', '\x41', '\x1D', 
		'\x43', '\x1E', '\x45', '\x1F', 'G', ' ', 'I', '!', 'K', '\"', 'M', '#', 
		'O', '$', 'Q', '%', '\x3', '\x2', '\b', '\x4', '\x2', '\f', '\f', '\xF', 
		'\xF', '\x3', '\x2', '$', '$', '\x6', '\x2', '&', '&', '\x43', '\\', '\x61', 
		'\x61', '\x63', '|', '\x3', '\x2', '\x32', ';', '\r', '\x2', '#', '#', 
		'%', '(', ',', ',', '\x31', '\x31', '<', '=', '?', '?', '\x41', '\x42', 
		'^', '^', '`', '`', '~', '~', '\x80', '\x80', '\x4', '\x2', '\v', '\v', 
		'\"', '\"', '\x2', '\xFB', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '\x13', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x17', '\x3', '\x2', '\x2', '\x2', '\x2', '\x19', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1D', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\'', '\x3', '\x2', '\x2', '\x2', '\x2', ')', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x31', '\x3', '\x2', '\x2', '\x2', '\x2', '\x33', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x35', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x39', '\x3', '\x2', '\x2', '\x2', '\x2', ';', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '=', '\x3', '\x2', '\x2', '\x2', '\x2', '?', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x41', '\x3', '\x2', '\x2', '\x2', '\x2', '\x43', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x45', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'G', '\x3', '\x2', '\x2', '\x2', '\x2', 'I', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'K', '\x3', '\x2', '\x2', '\x2', '\x2', 'M', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 'O', '\x3', '\x2', '\x2', '\x2', '\x2', 'Q', '\x3', 
		'\x2', '\x2', '\x2', '\x3', 'S', '\x3', '\x2', '\x2', '\x2', '\x5', '\x61', 
		'\x3', '\x2', '\x2', '\x2', '\a', 'h', '\x3', '\x2', '\x2', '\x2', '\t', 
		'o', '\x3', '\x2', '\x2', '\x2', '\v', 'q', '\x3', '\x2', '\x2', '\x2', 
		'\r', 'w', '\x3', '\x2', '\x2', '\x2', '\xF', '|', '\x3', '\x2', '\x2', 
		'\x2', '\x11', '\x80', '\x3', '\x2', '\x2', '\x2', '\x13', '\x82', '\x3', 
		'\x2', '\x2', '\x2', '\x15', '\x84', '\x3', '\x2', '\x2', '\x2', '\x17', 
		'\x86', '\x3', '\x2', '\x2', '\x2', '\x19', '\x88', '\x3', '\x2', '\x2', 
		'\x2', '\x1B', '\x8A', '\x3', '\x2', '\x2', '\x2', '\x1D', '\x8C', '\x3', 
		'\x2', '\x2', '\x2', '\x1F', '\x8E', '\x3', '\x2', '\x2', '\x2', '!', 
		'\x91', '\x3', '\x2', '\x2', '\x2', '#', '\x95', '\x3', '\x2', '\x2', 
		'\x2', '%', '\x9D', '\x3', '\x2', '\x2', '\x2', '\'', '\x9F', '\x3', '\x2', 
		'\x2', '\x2', ')', '\xA8', '\x3', '\x2', '\x2', '\x2', '+', '\xB4', '\x3', 
		'\x2', '\x2', '\x2', '-', '\xB7', '\x3', '\x2', '\x2', '\x2', '/', '\xBB', 
		'\x3', '\x2', '\x2', '\x2', '\x31', '\xBD', '\x3', '\x2', '\x2', '\x2', 
		'\x33', '\xC6', '\x3', '\x2', '\x2', '\x2', '\x35', '\xCF', '\x3', '\x2', 
		'\x2', '\x2', '\x37', '\xD8', '\x3', '\x2', '\x2', '\x2', '\x39', '\xDA', 
		'\x3', '\x2', '\x2', '\x2', ';', '\xDC', '\x3', '\x2', '\x2', '\x2', '=', 
		'\xDE', '\x3', '\x2', '\x2', '\x2', '?', '\xE0', '\x3', '\x2', '\x2', 
		'\x2', '\x41', '\xE2', '\x3', '\x2', '\x2', '\x2', '\x43', '\xE4', '\x3', 
		'\x2', '\x2', '\x2', '\x45', '\xE6', '\x3', '\x2', '\x2', '\x2', 'G', 
		'\xE8', '\x3', '\x2', '\x2', '\x2', 'I', '\xEA', '\x3', '\x2', '\x2', 
		'\x2', 'K', '\xEC', '\x3', '\x2', '\x2', '\x2', 'M', '\xEE', '\x3', '\x2', 
		'\x2', '\x2', 'O', '\xF0', '\x3', '\x2', '\x2', '\x2', 'Q', '\xF3', '\x3', 
		'\x2', '\x2', '\x2', 'S', 'T', '\a', '&', '\x2', '\x2', 'T', 'U', '\a', 
		'U', '\x2', '\x2', 'U', 'V', '\a', 'V', '\x2', '\x2', 'V', 'W', '\a', 
		'\x43', '\x2', '\x2', 'W', 'X', '\a', 'V', '\x2', '\x2', 'X', 'Y', '\a', 
		'G', '\x2', '\x2', 'Y', 'Z', '\a', 'O', '\x2', '\x2', 'Z', '[', '\a', 
		'\x43', '\x2', '\x2', '[', '\\', '\a', '\x45', '\x2', '\x2', '\\', ']', 
		'\a', 'J', '\x2', '\x2', ']', '^', '\a', 'K', '\x2', '\x2', '^', '_', 
		'\a', 'P', '\x2', '\x2', '_', '`', '\a', 'G', '\x2', '\x2', '`', '\x4', 
		'\x3', '\x2', '\x2', '\x2', '\x61', '\x62', '\a', '&', '\x2', '\x2', '\x62', 
		'\x63', '\a', 'P', '\x2', '\x2', '\x63', '\x64', '\a', 'Q', '\x2', '\x2', 
		'\x64', '\x65', '\a', 'V', '\x2', '\x2', '\x65', '\x66', '\a', 'G', '\x2', 
		'\x2', '\x66', 'g', '\a', 'U', '\x2', '\x2', 'g', '\x6', '\x3', '\x2', 
		'\x2', '\x2', 'h', 'i', '\a', '&', '\x2', '\x2', 'i', 'j', '\a', 'Q', 
		'\x2', '\x2', 'j', 'k', '\a', 'T', '\x2', '\x2', 'k', 'l', '\a', 'V', 
		'\x2', '\x2', 'l', 'm', '\a', 'J', '\x2', '\x2', 'm', 'n', '\a', 'Q', 
		'\x2', '\x2', 'n', '\b', '\x3', '\x2', '\x2', '\x2', 'o', 'p', '\a', '%', 
		'\x2', '\x2', 'p', '\n', '\x3', '\x2', '\x2', '\x2', 'q', 'r', '\a', 'g', 
		'\x2', '\x2', 'r', 's', '\a', 'p', '\x2', '\x2', 's', 't', '\a', 'v', 
		'\x2', '\x2', 't', 'u', '\a', 't', '\x2', '\x2', 'u', 'v', '\a', '{', 
		'\x2', '\x2', 'v', '\f', '\x3', '\x2', '\x2', '\x2', 'w', 'x', '\a', 'g', 
		'\x2', '\x2', 'x', 'y', '\a', 'z', '\x2', '\x2', 'y', 'z', '\a', 'k', 
		'\x2', '\x2', 'z', '{', '\a', 'v', '\x2', '\x2', '{', '\xE', '\x3', '\x2', 
		'\x2', '\x2', '|', '}', '\a', 'x', '\x2', '\x2', '}', '~', '\a', 'k', 
		'\x2', '\x2', '~', '\x7F', '\a', '\x63', '\x2', '\x2', '\x7F', '\x10', 
		'\x3', '\x2', '\x2', '\x2', '\x80', '\x81', '\a', '*', '\x2', '\x2', '\x81', 
		'\x12', '\x3', '\x2', '\x2', '\x2', '\x82', '\x83', '\a', '+', '\x2', 
		'\x2', '\x83', '\x14', '\x3', '\x2', '\x2', '\x2', '\x84', '\x85', '\a', 
		']', '\x2', '\x2', '\x85', '\x16', '\x3', '\x2', '\x2', '\x2', '\x86', 
		'\x87', '\a', '_', '\x2', '\x2', '\x87', '\x18', '\x3', '\x2', '\x2', 
		'\x2', '\x88', '\x89', '\a', '\x31', '\x2', '\x2', '\x89', '\x1A', '\x3', 
		'\x2', '\x2', '\x2', '\x8A', '\x8B', '\a', '}', '\x2', '\x2', '\x8B', 
		'\x1C', '\x3', '\x2', '\x2', '\x2', '\x8C', '\x8D', '\a', '\x7F', '\x2', 
		'\x2', '\x8D', '\x1E', '\x3', '\x2', '\x2', '\x2', '\x8E', '\x8F', '\a', 
		'g', '\x2', '\x2', '\x8F', ' ', '\x3', '\x2', '\x2', '\x2', '\x90', '\x92', 
		'\t', '\x2', '\x2', '\x2', '\x91', '\x90', '\x3', '\x2', '\x2', '\x2', 
		'\x92', '\x93', '\x3', '\x2', '\x2', '\x2', '\x93', '\x91', '\x3', '\x2', 
		'\x2', '\x2', '\x93', '\x94', '\x3', '\x2', '\x2', '\x2', '\x94', '\"', 
		'\x3', '\x2', '\x2', '\x2', '\x95', '\x9A', '\x5', '\x37', '\x1C', '\x2', 
		'\x96', '\x99', '\x5', '\x37', '\x1C', '\x2', '\x97', '\x99', '\x5', '\x39', 
		'\x1D', '\x2', '\x98', '\x96', '\x3', '\x2', '\x2', '\x2', '\x98', '\x97', 
		'\x3', '\x2', '\x2', '\x2', '\x99', '\x9C', '\x3', '\x2', '\x2', '\x2', 
		'\x9A', '\x98', '\x3', '\x2', '\x2', '\x2', '\x9A', '\x9B', '\x3', '\x2', 
		'\x2', '\x2', '\x9B', '$', '\x3', '\x2', '\x2', '\x2', '\x9C', '\x9A', 
		'\x3', '\x2', '\x2', '\x2', '\x9D', '\x9E', '\n', '\x2', '\x2', '\x2', 
		'\x9E', '&', '\x3', '\x2', '\x2', '\x2', '\x9F', '\xA0', '\a', '\x31', 
		'\x2', '\x2', '\xA0', '\xA1', '\a', '\x31', '\x2', '\x2', '\xA1', '\xA5', 
		'\x3', '\x2', '\x2', '\x2', '\xA2', '\xA4', '\x5', '%', '\x13', '\x2', 
		'\xA3', '\xA2', '\x3', '\x2', '\x2', '\x2', '\xA4', '\xA7', '\x3', '\x2', 
		'\x2', '\x2', '\xA5', '\xA3', '\x3', '\x2', '\x2', '\x2', '\xA5', '\xA6', 
		'\x3', '\x2', '\x2', '\x2', '\xA6', '(', '\x3', '\x2', '\x2', '\x2', '\xA7', 
		'\xA5', '\x3', '\x2', '\x2', '\x2', '\xA8', '\xA9', '\a', '\x31', '\x2', 
		'\x2', '\xA9', '\xAA', '\a', ',', '\x2', '\x2', '\xAA', '\xAE', '\x3', 
		'\x2', '\x2', '\x2', '\xAB', '\xAD', '\v', '\x2', '\x2', '\x2', '\xAC', 
		'\xAB', '\x3', '\x2', '\x2', '\x2', '\xAD', '\xB0', '\x3', '\x2', '\x2', 
		'\x2', '\xAE', '\xAF', '\x3', '\x2', '\x2', '\x2', '\xAE', '\xAC', '\x3', 
		'\x2', '\x2', '\x2', '\xAF', '\xB1', '\x3', '\x2', '\x2', '\x2', '\xB0', 
		'\xAE', '\x3', '\x2', '\x2', '\x2', '\xB1', '\xB2', '\a', ',', '\x2', 
		'\x2', '\xB2', '\xB3', '\a', '\x31', '\x2', '\x2', '\xB3', '*', '\x3', 
		'\x2', '\x2', '\x2', '\xB4', '\xB5', '\a', '^', '\x2', '\x2', '\xB5', 
		'\xB6', '\v', '\x2', '\x2', '\x2', '\xB6', ',', '\x3', '\x2', '\x2', '\x2', 
		'\xB7', '\xB8', '\n', '\x3', '\x2', '\x2', '\xB8', '.', '\x3', '\x2', 
		'\x2', '\x2', '\xB9', '\xBC', '\x5', '+', '\x16', '\x2', '\xBA', '\xBC', 
		'\x5', '-', '\x17', '\x2', '\xBB', '\xB9', '\x3', '\x2', '\x2', '\x2', 
		'\xBB', '\xBA', '\x3', '\x2', '\x2', '\x2', '\xBC', '\x30', '\x3', '\x2', 
		'\x2', '\x2', '\xBD', '\xC1', '\x5', ';', '\x1E', '\x2', '\xBE', '\xC0', 
		'\x5', '/', '\x18', '\x2', '\xBF', '\xBE', '\x3', '\x2', '\x2', '\x2', 
		'\xC0', '\xC3', '\x3', '\x2', '\x2', '\x2', '\xC1', '\xBF', '\x3', '\x2', 
		'\x2', '\x2', '\xC1', '\xC2', '\x3', '\x2', '\x2', '\x2', '\xC2', '\xC4', 
		'\x3', '\x2', '\x2', '\x2', '\xC3', '\xC1', '\x3', '\x2', '\x2', '\x2', 
		'\xC4', '\xC5', '\x5', ';', '\x1E', '\x2', '\xC5', '\x32', '\x3', '\x2', 
		'\x2', '\x2', '\xC6', '\xCA', '\x5', '=', '\x1F', '\x2', '\xC7', '\xC9', 
		'\x5', '/', '\x18', '\x2', '\xC8', '\xC7', '\x3', '\x2', '\x2', '\x2', 
		'\xC9', '\xCC', '\x3', '\x2', '\x2', '\x2', '\xCA', '\xC8', '\x3', '\x2', 
		'\x2', '\x2', '\xCA', '\xCB', '\x3', '\x2', '\x2', '\x2', '\xCB', '\xCD', 
		'\x3', '\x2', '\x2', '\x2', '\xCC', '\xCA', '\x3', '\x2', '\x2', '\x2', 
		'\xCD', '\xCE', '\x5', '=', '\x1F', '\x2', '\xCE', '\x34', '\x3', '\x2', 
		'\x2', '\x2', '\xCF', '\xD3', '\x5', '?', ' ', '\x2', '\xD0', '\xD2', 
		'\x5', '/', '\x18', '\x2', '\xD1', '\xD0', '\x3', '\x2', '\x2', '\x2', 
		'\xD2', '\xD5', '\x3', '\x2', '\x2', '\x2', '\xD3', '\xD1', '\x3', '\x2', 
		'\x2', '\x2', '\xD3', '\xD4', '\x3', '\x2', '\x2', '\x2', '\xD4', '\xD6', 
		'\x3', '\x2', '\x2', '\x2', '\xD5', '\xD3', '\x3', '\x2', '\x2', '\x2', 
		'\xD6', '\xD7', '\x5', '?', ' ', '\x2', '\xD7', '\x36', '\x3', '\x2', 
		'\x2', '\x2', '\xD8', '\xD9', '\t', '\x4', '\x2', '\x2', '\xD9', '\x38', 
		'\x3', '\x2', '\x2', '\x2', '\xDA', '\xDB', '\t', '\x5', '\x2', '\x2', 
		'\xDB', ':', '\x3', '\x2', '\x2', '\x2', '\xDC', '\xDD', '\a', '$', '\x2', 
		'\x2', '\xDD', '<', '\x3', '\x2', '\x2', '\x2', '\xDE', '\xDF', '\a', 
		')', '\x2', '\x2', '\xDF', '>', '\x3', '\x2', '\x2', '\x2', '\xE0', '\xE1', 
		'\a', '\x62', '\x2', '\x2', '\xE1', '@', '\x3', '\x2', '\x2', '\x2', '\xE2', 
		'\xE3', '\a', '\x30', '\x2', '\x2', '\xE3', '\x42', '\x3', '\x2', '\x2', 
		'\x2', '\xE4', '\xE5', '\a', '.', '\x2', '\x2', '\xE5', '\x44', '\x3', 
		'\x2', '\x2', '\x2', '\xE6', '\xE7', '\a', '-', '\x2', '\x2', '\xE7', 
		'\x46', '\x3', '\x2', '\x2', '\x2', '\xE8', '\xE9', '\a', '/', '\x2', 
		'\x2', '\xE9', 'H', '\x3', '\x2', '\x2', '\x2', '\xEA', '\xEB', '\a', 
		'<', '\x2', '\x2', '\xEB', 'J', '\x3', '\x2', '\x2', '\x2', '\xEC', '\xED', 
		'\a', '@', '\x2', '\x2', '\xED', 'L', '\x3', '\x2', '\x2', '\x2', '\xEE', 
		'\xEF', '\a', '>', '\x2', '\x2', '\xEF', 'N', '\x3', '\x2', '\x2', '\x2', 
		'\xF0', '\xF1', '\t', '\x6', '\x2', '\x2', '\xF1', 'P', '\x3', '\x2', 
		'\x2', '\x2', '\xF2', '\xF4', '\t', '\a', '\x2', '\x2', '\xF3', '\xF2', 
		'\x3', '\x2', '\x2', '\x2', '\xF4', '\xF5', '\x3', '\x2', '\x2', '\x2', 
		'\xF5', '\xF3', '\x3', '\x2', '\x2', '\x2', '\xF5', '\xF6', '\x3', '\x2', 
		'\x2', '\x2', '\xF6', 'R', '\x3', '\x2', '\x2', '\x2', '\r', '\x2', '\x93', 
		'\x98', '\x9A', '\xA5', '\xAE', '\xBB', '\xC1', '\xCA', '\xD3', '\xF5', 
		'\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
