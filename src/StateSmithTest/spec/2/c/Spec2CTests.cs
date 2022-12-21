using Spec.Spec2;
using StateSmith.Input.Expansions;
using StateSmith.output.C99BalancedCoder1;
using StateSmith.Runner;
using System;
using System.Diagnostics;
using Xunit;
using FluentAssertions;
using System.Runtime.InteropServices;
using Xunit.Abstractions;

namespace Spec.Spec2.C;

public class Spec2CTests : Spec2CFixture
{
    SpecTester tester = new();

    public Spec2CTests()
    {
        tester.SpecificationRunner = Run;
    }

    [Fact]
    public void Test1_DoEventHandling()
    {
        tester.PreEvents = "EV1";
        
        tester.AddEventHandling("DO", t => t(@"
            State TEST1_S1_1: check behavior `do`. Behavior running.
            State TEST1_ROOT: check behavior `do`. Behavior running.
        ")); tester.AddEventHandling("EV1", t => t(@"
            State TEST1_S1_1: check behavior `EV1 TransitionTo(TEST1_S2)`. Behavior running.
            Exit TEST1_S1_1.
            Exit TEST1_S1.
            Transition action `` for TEST1_S1_1 to TEST1_S2.
            Enter TEST1_S2.
        ")); tester.AddEventHandling("DO", t => t(@"
            State TEST1_S2: check behavior `do / { consume_event = true; }`. Behavior running.
        "));

        tester.RunAndVerify();
    }

    

    [Fact]
    public void Test2_RegularEventHandling()
    {
		tester.PreEvents = "EV2";
        
        tester.AddEventHandling("EV2", t => t(@"
            State TEST2_ROOT: check behavior `EV2`. Behavior running.
        ")); tester.AddEventHandling("EV1", t => t(@"
            State TEST2_S1_1: check behavior `EV1`. Behavior running.
        ")); tester.AddEventHandling("DO", t => t(@"
            State TEST2_S1_1: check behavior `do TransitionTo(TEST2_S2)`. Behavior running.
            Exit TEST2_S1_1.
            Exit TEST2_S1.
            Transition action `` for TEST2_S1_1 to TEST2_S2.
            Enter TEST2_S2.
        ")); tester.AddEventHandling("EV1", t => t(@"
            State TEST2_S2: check behavior `EV1 / { consume_event = false; }`. Behavior running.
            State TEST2_ROOT: check behavior `EV1`. Behavior running.
        ")); tester.AddEventHandling("EV2", t => t(@"
            State TEST2_S2: check behavior `EV2 TransitionTo(TEST2_S2)`. Behavior running.
            Exit TEST2_S2.
            Transition action `` for TEST2_S2 to TEST2_S2.
            Enter TEST2_S2.
        "));

        tester.RunAndVerify();
    }

    [Fact]
    public void Test3_BehaviorOrdering()
    {
		tester.PreEvents = "EV3";
        
        tester.AddEventHandling("EV1", t => t(@"
            State TEST3_S1: check behavior `1. EV1 TransitionTo(TEST3_S2)`. Behavior running.
            Exit TEST3_S1.
            Transition action `` for TEST3_S1 to TEST3_S2.
            Enter TEST3_S2.
        ")); tester.AddEventHandling("EV1", t => t(@"
            State TEST3_S2: check behavior `1. EV1 / { trace(""1 woot!""); }`. Behavior running.
            1 woot!
            State TEST3_S2: check behavior `1.1. EV1 / { trace(""2 woot!""); }`. Behavior running.
            2 woot!
            State TEST3_S2: check behavior `2. EV1 / { trace(""3 woot!""); } TransitionTo(TEST3_S3)`. Behavior running.
            Exit TEST3_S2.
            Transition action `trace(""3 woot!"");` for TEST3_S2 to TEST3_S3.
            3 woot!
            Enter TEST3_S3.
        "));

        tester.RunAndVerify();
    }

    //-------------------------------------------------------------------------------------

    [Fact]
    public void Test4_ParentChildTransitions()
    {
        tester.PreEvents = "EV4 EV1";

        // should see transition to S1 without exiting ROOT
        tester.AddEventHandling("EV2", t => t(@"
            State TEST4_ROOT: check behavior `EV2 TransitionTo(TEST4_S1)`. Behavior running.
            Transition action `` for TEST4_ROOT to TEST4_S1.
            Enter TEST4_S1.
        "));

        // Already in S1. Root handler should exit S1, then re-enter S1.
        tester.AddEventHandling("EV2", t => t(@"
            State TEST4_ROOT: check behavior `EV2 TransitionTo(TEST4_S1)`. Behavior running.
            Exit TEST4_S1.
            Transition action `` for TEST4_ROOT to TEST4_S1.
            Enter TEST4_S1.
        "));

        // Should transition from S1 to S2
        tester.AddEventHandling("EV1", t => t(@"
            State TEST4_S1: check behavior `EV1 TransitionTo(TEST4_S2)`. Behavior running.
            Exit TEST4_S1.
            Transition action `` for TEST4_S1 to TEST4_S2.
            Enter TEST4_S2.
        "));

        // Root handler should cause transition to S1.
        tester.AddEventHandling("EV2", t => t(@"
            State TEST4_ROOT: check behavior `EV2 TransitionTo(TEST4_S1)`. Behavior running.
            Exit TEST4_S2.
            Transition action `` for TEST4_ROOT to TEST4_S1.
            Enter TEST4_S1.
        "));

        // S1 to S2
        tester.AddEventHandling("EV1", t => t(@"
            State TEST4_S1: check behavior `EV1 TransitionTo(TEST4_S2)`. Behavior running.
            Exit TEST4_S1.
            Transition action `` for TEST4_S1 to TEST4_S2.
            Enter TEST4_S2.
        "));

        // S2 to S3
        tester.AddEventHandling("EV1", t => t(@"
            State TEST4_S2: check behavior `EV1 TransitionTo(TEST4_S3)`. Behavior running.
            Exit TEST4_S2.
            Transition action `` for TEST4_S2 to TEST4_S3.
            Enter TEST4_S3.
        "));

        // S3 to ROOT
        tester.AddEventHandling("EV1", t => t(@"
            State TEST4_S3: check behavior `EV1 TransitionTo(TEST4_ROOT)`. Behavior running.
            Exit TEST4_S3.
            Transition action `` for TEST4_S3 to TEST4_ROOT.
        "));

        tester.RunAndVerify();
    }

    [Fact]
    public void Test4_ParentChildTransitions_SelfTransition()
    {
        tester.PreEvents = "EV4 EV1";

        // 
        tester.AddEventHandling("EV3", t => t(@"
            State TEST4_ROOT: check behavior `EV3 TransitionTo(TEST4_S10_1)`. Behavior running.
            Transition action `` for TEST4_ROOT to TEST4_S10_1.
            Enter TEST4_S10.
            Enter TEST4_S10_1.
        "));

        tester.AddEventHandling("EV4", t => t(@"
            State TEST4_S10: check behavior `EV4 TransitionTo(TEST4_S10)`. Behavior running.
            Exit TEST4_S10_1.
            Exit TEST4_S10.
            Transition action `` for TEST4_S10 to TEST4_S10.
            Enter TEST4_S10.
        "));

        tester.RunAndVerify();
    }

    // https://github.com/StateSmith/StateSmith/issues/49
    [Fact]
    public void Test4_ParentChildTransitions_SelfTransitionWithInitialState()
    {
        tester.PreEvents = "EV4 EV1";

        // 
        tester.AddEventHandling("EV4", t => t(@"
            State TEST4_ROOT: check behavior `EV4 TransitionTo(TEST4_S20)`. Behavior running.
            Transition action `` for TEST4_ROOT to TEST4_S20.
            Enter TEST4_S20.
            Transition action `` for TEST4_S20.InitialState to TEST4_S20_1.
            Enter TEST4_S20_1.
        "));

        tester.AddEventHandling("EV4", t => t(@"
            State TEST4_S20: check behavior `EV4 TransitionTo(TEST4_S20)`. Behavior running.
            Exit TEST4_S20_1.
            Exit TEST4_S20.
            Transition action `` for TEST4_S20 to TEST4_S20.
            Enter TEST4_S20.
            Transition action `` for TEST4_S20.InitialState to TEST4_S20_1.
            Enter TEST4_S20_1.
        "));

        tester.RunAndVerify();
    }

    //-------------------------------------------------------------------------------------

    [Fact]
    public void Test4B_LocalTransitionExample()
    {
        tester.PreEvents = "EV4 EV2";

        // 
        tester.AddEventHandling("EV1", t => t(@"
            State TEST4B_G: check behavior `EV1 TransitionTo(TEST4B_G_1)`. Behavior running.
            Transition action `` for TEST4B_G to TEST4B_G_1.
            Enter TEST4B_G_1.
        "));

        tester.AddEventHandling("EV2", t => t(@"
            State TEST4B_G_1: check behavior `EV2 TransitionTo(TEST4B_G)`. Behavior running.
            Exit TEST4B_G_1.
            Transition action `` for TEST4B_G_1 to TEST4B_G.
        "));

        tester.RunAndVerify();
    }

    [Fact]
    public void Test4C_LocalTransitionAliasExample()
    {
        tester.PreEvents = "EV4 EV3";

        // 
        tester.AddEventHandling("EV1", t => t(@"
            State TEST4C_G: check behavior `EV1 TransitionTo(TEST4C_G_1)`. Behavior running.
            Transition action `` for TEST4C_G to TEST4C_G_1.
            Enter TEST4C_G_1.
        "));

        tester.AddEventHandling("EV2", t => t(@"
            State TEST4C_G_1: check behavior `EV2 TransitionTo(TEST4C_G)`. Behavior running.
            Exit TEST4C_G_1.
            Transition action `` for TEST4C_G_1 to TEST4C_G.
        "));

        tester.RunAndVerify();
    }

    [Fact]
    public void Test4D_ExternalTransitionExample()
    {
        tester.PreEvents = "EV4 EV4";
        
        tester.AddEventHandling("EV1", t => t(@"
            State TEST4D_G: check behavior `EV1 TransitionTo(TEST4D_EXTERNAL.ChoicePoint())`. Behavior running.
            Exit TEST4D_G.
            Transition action `` for TEST4D_G to TEST4D_EXTERNAL.ChoicePoint().
            Transition action `` for TEST4D_EXTERNAL.ChoicePoint() to TEST4D_G_1.
            Enter TEST4D_G.
            Enter TEST4D_G_1.
        "));

        tester.AddEventHandling("EV2", t => t(@"
            State TEST4D_G_1: check behavior `EV2 TransitionTo(TEST4D_EXTERNAL.ChoicePoint())`. Behavior running.
            Exit TEST4D_G_1.
            Exit TEST4D_G.
            Transition action `` for TEST4D_G_1 to TEST4D_EXTERNAL.ChoicePoint().
            Transition action `` for TEST4D_EXTERNAL.ChoicePoint() to TEST4D_G.
            Enter TEST4D_G.
        "));

        tester.RunAndVerify();
    }

    //-------------------------------------------------------------------------------------

    /// <summary>
    /// Same as <see cref="TestParentChildTransitions"/>, but designed with parent alias nodes instead.
    /// </summary>
    [Fact]
    public void Test5_ParentAliasChildTransitions()
    {
        tester.PreEvents = "EV5";

        // should see transition to S1 without exiting ROOT
        tester.AddEventHandling("EV2", t => t(@"
            State TEST5_ROOT: check behavior `EV2 TransitionTo(TEST5_S1)`. Behavior running.
            Transition action `` for TEST5_ROOT to TEST5_S1.
            Enter TEST5_S1.
        "));

        // Already in S1. Root handler should exit S1, then re-enter S1.
        tester.AddEventHandling("EV2", t => t(@"
            State TEST5_ROOT: check behavior `EV2 TransitionTo(TEST5_S1)`. Behavior running.
            Exit TEST5_S1.
            Transition action `` for TEST5_ROOT to TEST5_S1.
            Enter TEST5_S1.
        "));

        // Should transition from S1 to S2
        tester.AddEventHandling("EV1", t => t(@"
            State TEST5_S1: check behavior `EV1 TransitionTo(TEST5_S2)`. Behavior running.
            Exit TEST5_S1.
            Transition action `` for TEST5_S1 to TEST5_S2.
            Enter TEST5_S2.
        "));

        // Root handler should cause transition to S1.
        tester.AddEventHandling("EV2", t => t(@"
            State TEST5_ROOT: check behavior `EV2 TransitionTo(TEST5_S1)`. Behavior running.
            Exit TEST5_S2.
            Transition action `` for TEST5_ROOT to TEST5_S1.
            Enter TEST5_S1.
        "));

        // S1 to S2
        tester.AddEventHandling("EV1", t => t(@"
            State TEST5_S1: check behavior `EV1 TransitionTo(TEST5_S2)`. Behavior running.
            Exit TEST5_S1.
            Transition action `` for TEST5_S1 to TEST5_S2.
            Enter TEST5_S2.
        "));

        // S2 to S3
        tester.AddEventHandling("EV1", t => t(@"
            State TEST5_S2: check behavior `EV1 TransitionTo(TEST5_S3)`. Behavior running.
            Exit TEST5_S2.
            Transition action `` for TEST5_S2 to TEST5_S3.
            Enter TEST5_S3.
        "));

        // S3 to ROOT
        tester.AddEventHandling("EV1", t => t(@"
            State TEST5_S3: check behavior `EV1 TransitionTo(TEST5_ROOT)`. Behavior running.
            Exit TEST5_S3.
            Transition action `` for TEST5_S3 to TEST5_ROOT.
        "));

        tester.RunAndVerify();
    }

    [Fact]
    public void Test6_Variables()
    {
        tester.PreEvents = "EV6";

        // 
        tester.AddEventHandling("EV1", t => t(@"
            State TEST6_S1: check behavior `1. EV1 / { count++; }`. Behavior running.
            State TEST6_S1: check behavior `2. EV1 [count >= 2] TransitionTo(TEST6_S2)`. Behavior skipped.
        "));

        // 
        tester.AddEventHandling("EV1", t => t(@"
            State TEST6_S1: check behavior `1. EV1 / { count++; }`. Behavior running.
            State TEST6_S1: check behavior `2. EV1 [count >= 2] TransitionTo(TEST6_S2)`. Behavior running.
            Exit TEST6_S1.
            Transition action `` for TEST6_S1 to TEST6_S2.
            Enter TEST6_S2.
        "));

        tester.RunAndVerify();
    }

    /////////////////////////////////////////////////////////////////////////////////////////

    [Fact]
    public void Test7_Choice_1_DirectToInitial()
    {
        int incCount = 1;
        var expectedState = "G_S1";
        Test7_RunWithXIncrementEvents(expectedState, incCount, directToInitialState: true);
    }

    [Fact]
    public void Test7_Choice_1()
    {
        int incCount = 1;
        var expectedState = "G_S1";
        Test7_RunWithXIncrementEvents(expectedState, incCount);
    }

    [Fact]
    public void Test7_Choice_2()
    {
        int incCount = 2;
        var expectedState = "G_S2";
        Test7_RunWithXIncrementEvents(expectedState, incCount);
    }

    [Fact]
    public void Test7_Choice_3()
    {
        int incCount = 0;
        var expectedState = "G_S3";
        Test7_RunWithXIncrementEvents(expectedState, incCount);
    }

    [Fact]
    public void Test7_Choice_3_2()
    {
        int incCount = 3;
        var expectedState = "G_S3";
        Test7_RunWithXIncrementEvents(expectedState, incCount);
    }

    private void Test7_RunWithXIncrementEvents(string expectedState, int incCount, bool directToInitialState = false)
    {
        tester.PreEvents = "EV7 EV1";

        for (int i = 0; i < incCount; i++)
        {
            // 
            tester.AddEventHandling("EV5", t => t(@"
                State PARENT: check behavior `EV5 / { count++; }`. Behavior running.
            "));
        }

        if (directToInitialState)
        {
            // 
            tester.AddEventHandling("EV3", t => t(@$"
                State S1: check behavior `EV3 TransitionTo(G.InitialState)`. Behavior running.
                Exit S1.
                Transition action `` for S1 to G.InitialState.
                Enter G.
                Transition action `` for G.InitialState to {expectedState}.
                Enter {expectedState}.
            "));
        }
        else
        {
            // 
            tester.AddEventHandling("EV1", t => t(@$"
                State S1: check behavior `EV1 TransitionTo(G)`. Behavior running.
                Exit S1.
                Transition action `` for S1 to G.
                Enter G.
                Transition action `` for G.InitialState to {expectedState}.
                Enter {expectedState}.
            "));
        }

        // 
        tester.AddEventHandling("EV2", t => t(@$"
            State G: check behavior `EV2 TransitionTo(PARENT.InitialState)`. Behavior running.
            Exit {expectedState}.
            Exit G.
            Transition action `` for G to PARENT.InitialState.
            Transition action `` for PARENT.InitialState to S1.
            Enter S1.
        "));

        tester.RunAndVerify();
    }

    ///////////////////////////////////////////////////////////////////////////////////

    [Fact]
    public void Test8_Choice_1_Direct1()
    {
        int incCount = 1;
        var expectedState = "TEST8_G_S1";
        Test8_RunWithXIncrementEvents(expectedState, incCount, variation: 1);
    }

    [Fact]
    public void Test8_Choice_1_Direct2()
    {
        int incCount = 1;
        var expectedState = "TEST8_G_S1";
        Test8_RunWithXIncrementEvents(expectedState, incCount, variation: 2);
    }

    [Fact]
    public void Test8_Choice_1()
    {
        int incCount = 1;
        var expectedState = "TEST8_G_S1";
        Test8_RunWithXIncrementEvents(expectedState, incCount);
    }

    [Fact]
    public void Test8_Choice_2()
    {
        int incCount = 2;
        var expectedState = "TEST8_G_S2";
        Test8_RunWithXIncrementEvents(expectedState, incCount);
    }

    [Fact]
    public void Test8_Choice_3()
    {
        int incCount = 0;
        var expectedState = "TEST8_G_S3";
        Test8_RunWithXIncrementEvents(expectedState, incCount);
    }

    [Fact]
    public void Test8_Choice_3_2()
    {
        int incCount = 3;
        var expectedState = "TEST8_G_S3";
        Test8_RunWithXIncrementEvents(expectedState, incCount);
    }

    private void Test8_RunWithXIncrementEvents(string expectedState, int incCount, int variation = 0)
    {
        tester.PreEvents = "EV8";

        for (int i = 0; i < incCount; i++)
        {
            // 
            tester.AddEventHandling("EV5", t => t(@"
                State TEST8_ROOT: check behavior `EV5 / { count++; }`. Behavior running.
            "));
        }

        if (variation == 0)
        {
            // 
            tester.AddEventHandling("EV1", t => t(@$"
                State TEST8_S1: check behavior `1. EV1 TransitionTo(TEST8_G.EntryPoint(1))`. Behavior running.
                Exit TEST8_S1.
                Transition action `` for TEST8_S1 to TEST8_G.EntryPoint(1).
                Enter TEST8_G.
                Transition action `` for TEST8_G.EntryPoint(1) to {expectedState}.
                Enter {expectedState}.
            "));
        }
        else if (variation == 1)
        {
            // 
            tester.AddEventHandling("EV6", t => t(@$"
                State TEST8_S1: check behavior `EV6 TransitionTo(TEST8_G.EntryPoint(3))`. Behavior running.
                Exit TEST8_S1.
                Transition action `` for TEST8_S1 to TEST8_G.EntryPoint(3).
                Enter TEST8_G.
                Transition action `count += 0;` for TEST8_G.EntryPoint(3) to TEST8_G.EntryPoint(1).
                Transition action `` for TEST8_G.EntryPoint(1) to {expectedState}.
                Enter {expectedState}.
            "));
        }
        else if (variation == 2)
        {
            // 
            tester.AddEventHandling("EV3", t => t(@$"
                State TEST8_S1: check behavior `EV3 TransitionTo(TEST8_G.EntryPoint(3))`. Behavior running.
                Exit TEST8_S1.
                Transition action `` for TEST8_S1 to TEST8_G.EntryPoint(3).
                Enter TEST8_G.
                Transition action `count += 0;` for TEST8_G.EntryPoint(3) to TEST8_G.EntryPoint(1).
                Transition action `` for TEST8_G.EntryPoint(1) to {expectedState}.
                Enter {expectedState}.
            "));
        }
        else
        {
            throw new Exception("unsupported variation " + variation);
        }

        // 
        tester.AddEventHandling("EV2", t => t(@$"
            State TEST8_G: check behavior `EV2 TransitionTo(TEST8_ROOT.EntryPoint(1))`. Behavior running.
            Exit {expectedState}.
            Exit TEST8_G.
            Transition action `` for TEST8_G to TEST8_ROOT.EntryPoint(1).
            Transition action `` for TEST8_ROOT.EntryPoint(1) to TEST8_S1.
            Enter TEST8_S1.
        "));

        tester.RunAndVerify();
    }

    //---------------------------------------------------------------------------------------------------

    [Fact]
    public void Test9_Choice_1()
    {
        int incCount = 1;
        var expectedState = "TEST9_G_S1";
        Test9_RunWithXIncrementEvents(expectedState, incCount);
    }

    [Fact]
    public void Test9_Choice_2()
    {
        int incCount = 2;
        var expectedState = "TEST9_G_S2";
        Test9_RunWithXIncrementEvents(expectedState, incCount);
    }

    [Fact]
    public void Test9_Choice_3()
    {
        int incCount = 0;
        var expectedState = "TEST9_G_S3";
        Test9_RunWithXIncrementEvents(expectedState, incCount);
    }

    [Fact]
    public void Test9_Choice_3_2()
    {
        int incCount = 3;
        var expectedState = "TEST9_G_S3";
        Test9_RunWithXIncrementEvents(expectedState, incCount);
    }

    [Fact]
    public void Test9_Choice_4()
    {
        int incCount = 4;
        var expectedState = "TEST9_G_S4";
        Test9_RunWithXIncrementEvents(expectedState, incCount);
    }

    private void Test9_RunWithXIncrementEvents(string expectedState, int incCount)
    {
        tester.PreEvents = "EV9 EV1";

        for (int i = 0; i < incCount; i++)
        {
            // 
            tester.AddEventHandling("EV5", t => t(@"
                State TEST9_ROOT: check behavior `EV5 / { count++; }`. Behavior running.
            "));
        }

        // 
        tester.AddEventHandling("EV1", t => t(@$"
            State TEST9_S1_1: check behavior `EV1 TransitionTo(TEST9_S1.ExitPoint(1))`. Behavior running.
            Exit TEST9_S1_1.
            Transition action `` for TEST9_S1_1 to TEST9_S1.ExitPoint(1).
            Exit TEST9_S1.
            Transition action `` for TEST9_S1.ExitPoint(1) to {expectedState}.
            Enter {expectedState}.
        "));

        tester.RunAndVerify();
    }

    ///////////////////////////////////////////////////////////////////////////////////

    [Fact]
    public void Test9A_ExitPointTargetsParent()
    {
		tester.PreEvents = "EV9 EV2";
        
        tester.AddEventHandling("EV1", t => t(@"
            State TEST9A_S1_1: check behavior `EV1 TransitionTo(TEST9A_S1.ExitPoint(1))`. Behavior running.
            Exit TEST9A_S1_1.
            State TEST9A_S1_1: check behavior `exit / { count = 100; }`. Behavior running.
            Transition action `` for TEST9A_S1_1 to TEST9A_S1.ExitPoint(1).
            Exit TEST9A_S1.
            Transition action `count++;` for TEST9A_S1.ExitPoint(1) to TEST9A_S1.
            Transition action `` for TEST9A_S1.InitialState to TEST9A_S1_1.
            Enter TEST9A_S1_1.
            State TEST9A_S1_1: check behavior `enter [count == 0] / { clear_output(); }`. Behavior skipped.
        "));

        tester.RunAndVerify();
    }

    ///////////////////////////////////////////////////////////////////////////////////

    [Fact]
    public void Test10_Choice_0()
    {
        int incCount = 0;
        var expectedState = "TEST10_G_S0";
        Test10_RunWithXIncrementEventsOverVariations(expectedState, incCount);
    }

    [Fact]
    public void Test10_Choice_1()
    {
        int incCount = 1;
        var expectedState = "TEST10_G_S1";
        Test10_RunWithXIncrementEventsOverVariations(expectedState, incCount);
    }

    [Fact]
    public void Test10_Choice_2()
    {
        int incCount = 2;
        var expectedState = "TEST10_G_S2";
        Test10_RunWithXIncrementEventsOverVariations(expectedState, incCount);
    }

    [Fact]
    public void Test10_Choice_3()
    {
        int incCount = 3;
        var expectedState = "TEST10_G_S3";
        Test10_RunWithXIncrementEventsOverVariations(expectedState, incCount);
    }

    [Fact]
    public void Test10_Choice_4()
    {
        int incCount = 4;
        var expectedState = "TEST10_S4";
        Test10_RunWithXIncrementEventsOverVariations(expectedState, incCount);
    }

    private void Test10_RunWithXIncrementEventsOverVariations(string expectedState, int incCount)
    {
        for (int i = 1; i <= 3; i++)
        {
            Test10_RunWithXIncrementEvents33(expectedState, incCount, variation: i);
        }
    }

    private void Test10_RunWithXIncrementEvents33(string expectedState, int incCount, int variation)
    {
        tester.PreEvents = "EV10";

        for (int i = 0; i < incCount; i++)
        {
            tester.AddEventHandling("EV5", t => t(@"
                State TEST10_ROOT: check behavior `EV5 / { count++; }`. Behavior running.
            "));
        }

        var end = "";

        if (incCount == 0)
        {
            end = @$"
            Transition action `` for TEST10_G.ChoicePoint(1) to {expectedState}.
            Enter {expectedState}.
            ";
        }
        else if (incCount == 1 || incCount == 2)
        {
            end = @$"
            Transition action `` for TEST10_G.ChoicePoint(1) to TEST10_G.ChoicePoint(lower).
            Transition action `` for TEST10_G.ChoicePoint(lower) to {expectedState}.
            Enter {expectedState}.
            ";
        }
        else if (incCount == 3)
        {
            end = @$"
            Transition action `` for TEST10_G.ChoicePoint(1) to TEST10_G.ChoicePoint(upper).
            Transition action `` for TEST10_G.ChoicePoint(upper) to {expectedState}.
            Enter {expectedState}.
            ";
        }
        else if (incCount == 4)
        {
            end = @$"
            Transition action `` for TEST10_G.ChoicePoint(1) to TEST10_G.ChoicePoint(upper).
            Exit TEST10_G.
            Transition action `` for TEST10_G.ChoicePoint(upper) to {expectedState}.
            Enter {expectedState}.
            ";
        }
        else
        {
            throw new Exception("unsupported incCount " + incCount);
        }

        end = PrepExpectedOutput(end);

        if (variation == 1)
        {
            // 
            tester.AddEventHandling("EV1", t => t(@$"
                State TEST10_S1: check behavior `EV1 TransitionTo(TEST10_G.EntryPoint(1))`. Behavior running.
                Exit TEST10_S1.
                Transition action `` for TEST10_S1 to TEST10_G.EntryPoint(1).
                Enter TEST10_G.
                Transition action `` for TEST10_G.EntryPoint(1) to TEST10_G.ChoicePoint().
                Transition action `` for TEST10_G.ChoicePoint() to TEST10_G.ChoicePoint(1).
                {end}
            "));
        }
        else if (variation == 2)
        {
            // 
            tester.AddEventHandling("EV2", t => t(@$"
                State TEST10_S1: check behavior `EV2 TransitionTo(TEST10_G.ChoicePoint())`. Behavior running.
                Exit TEST10_S1.
                Transition action `` for TEST10_S1 to TEST10_G.ChoicePoint().
                Enter TEST10_G.
                Transition action `` for TEST10_G.ChoicePoint() to TEST10_G.ChoicePoint(1).
                {end}
            "));
        }
        else if (variation == 3)
        {
            // 
            tester.AddEventHandling("EV3", t => t(@$"
                State TEST10_S1: check behavior `EV3 TransitionTo(TEST10_G)`. Behavior running.
                Exit TEST10_S1.
                Transition action `` for TEST10_S1 to TEST10_G.
                Enter TEST10_G.
                Transition action `` for TEST10_G.InitialState to TEST10_G.ChoicePoint().
                Transition action `` for TEST10_G.ChoicePoint() to TEST10_G.ChoicePoint(1).
                {end}
            "));
        }
        else
        {
            throw new Exception("unsupported variation " + variation);
        }

        tester.RunAndVerify();
    }
}



