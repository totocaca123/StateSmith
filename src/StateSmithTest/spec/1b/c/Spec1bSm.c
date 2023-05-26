// Autogenerated with StateSmith.
// Algorithm: Balanced1. See https://github.com/StateSmith/StateSmith/wiki/Algorithms

#include "Spec1bSm.h"
#include "../../lang-helpers/c/helper.h"
#include "printer.h"
#include <stdbool.h> // required for `consume_event` flag
#include <string.h> // for memset

// This function is used when StateSmith doesn't know what the active leaf state is at
// compile time due to sub states or when multiple states need to be exited.
static void exit_up_to_state_handler(Spec1bSm* sm, Spec1bSm_Func desired_state_exit_handler);

static void ROOT_enter(Spec1bSm* sm);

static void ROOT_exit(Spec1bSm* sm);

static void S_enter(Spec1bSm* sm);

static void S_exit(Spec1bSm* sm);

static void S1_enter(Spec1bSm* sm);

static void S1_exit(Spec1bSm* sm);

static void S1_t1(Spec1bSm* sm);

static void S1_1_enter(Spec1bSm* sm);

static void S1_1_exit(Spec1bSm* sm);

static void S2_enter(Spec1bSm* sm);

static void S2_exit(Spec1bSm* sm);

static void S2_1_enter(Spec1bSm* sm);

static void S2_1_exit(Spec1bSm* sm);


// State machine constructor. Must be called before start or dispatch event functions. Not thread safe.
void Spec1bSm_ctor(Spec1bSm* sm)
{
    memset(sm, 0, sizeof(*sm));
}

// Starts the state machine. Must be called before dispatching events. Not thread safe.
void Spec1bSm_start(Spec1bSm* sm)
{
    ROOT_enter(sm);
    // ROOT behavior
    // uml: TransitionTo(ROOT.<InitialState>)
    {
        // Step 1: Exit states until we reach `ROOT` state (Least Common Ancestor for transition). Already at LCA, no exiting required.
        
        // Step 2: Transition action: ``.
        
        // Step 3: Enter/move towards transition target `ROOT.<InitialState>`.
        // ROOT.<InitialState> is a pseudo state and cannot have an `enter` trigger.
        
        // ROOT.<InitialState> behavior
        // uml: TransitionTo(S)
        {
            // Step 1: Exit states until we reach `ROOT` state (Least Common Ancestor for transition). Already at LCA, no exiting required.
            
            // Step 2: Transition action: ``.
            
            // Step 3: Enter/move towards transition target `S`.
            S_enter(sm);
            
            // S.<InitialState> behavior
            // uml: TransitionTo(S1)
            {
                // Step 1: Exit states until we reach `S` state (Least Common Ancestor for transition). Already at LCA, no exiting required.
                
                // Step 2: Transition action: ``.
                
                // Step 3: Enter/move towards transition target `S1`.
                S1_enter(sm);
                
                // S1.<InitialState> behavior
                // uml: TransitionTo(S1_1)
                {
                    // Step 1: Exit states until we reach `S1` state (Least Common Ancestor for transition). Already at LCA, no exiting required.
                    
                    // Step 2: Transition action: ``.
                    
                    // Step 3: Enter/move towards transition target `S1_1`.
                    S1_1_enter(sm);
                    
                    // Step 4: complete transition. Ends event dispatch. No other behaviors are checked.
                    sm->state_id = Spec1bSm_StateId_S1_1;
                    // No ancestor handles event. Can skip nulling `ancestor_event_handler`.
                    return;
                } // end of behavior for S1.<InitialState>
            } // end of behavior for S.<InitialState>
        } // end of behavior for ROOT.<InitialState>
    } // end of behavior for ROOT
}

// Dispatches an event to the state machine. Not thread safe.
void Spec1bSm_dispatch_event(Spec1bSm* sm, Spec1bSm_EventId event_id)
{
    Spec1bSm_Func behavior_func = sm->current_event_handlers[event_id];
    
    while (behavior_func != NULL)
    {
        sm->ancestor_event_handler = NULL;
        behavior_func(sm);
        behavior_func = sm->ancestor_event_handler;
    }
}

// This function is used when StateSmith doesn't know what the active leaf state is at
// compile time due to sub states or when multiple states need to be exited.
static void exit_up_to_state_handler(Spec1bSm* sm, Spec1bSm_Func desired_state_exit_handler)
{
    while (sm->current_state_exit_handler != desired_state_exit_handler)
    {
        sm->current_state_exit_handler(sm);
    }
}


////////////////////////////////////////////////////////////////////////////////
// event handlers for state ROOT
////////////////////////////////////////////////////////////////////////////////

static void ROOT_enter(Spec1bSm* sm)
{
    // setup trigger/event handlers
    sm->current_state_exit_handler = ROOT_exit;
}

static void ROOT_exit(Spec1bSm* sm)
{
    // State machine root is a special case. It cannot be exited. Mark as unused.
    (void)sm;
}


////////////////////////////////////////////////////////////////////////////////
// event handlers for state S
////////////////////////////////////////////////////////////////////////////////

static void S_enter(Spec1bSm* sm)
{
    // setup trigger/event handlers
    sm->current_state_exit_handler = S_exit;
}

static void S_exit(Spec1bSm* sm)
{
    // adjust function pointers for this state's exit
    sm->current_state_exit_handler = ROOT_exit;
}


////////////////////////////////////////////////////////////////////////////////
// event handlers for state S1
////////////////////////////////////////////////////////////////////////////////

static void S1_enter(Spec1bSm* sm)
{
    // setup trigger/event handlers
    sm->current_state_exit_handler = S1_exit;
    sm->current_event_handlers[Spec1bSm_EventId_T1] = S1_t1;
}

static void S1_exit(Spec1bSm* sm)
{
    // S1 behavior
    // uml: exit / { b(); }
    {
        // Step 1: execute action `b();`
        print("b(); ");
    } // end of behavior for S1
    
    // adjust function pointers for this state's exit
    sm->current_state_exit_handler = S_exit;
    sm->current_event_handlers[Spec1bSm_EventId_T1] = NULL;  // no ancestor listens to this event
}

static void S1_t1(Spec1bSm* sm)
{
    // No ancestor state handles `t1` event.
    
    // S1 behavior
    // uml: T1 [g()] / { t(); } TransitionTo(S2)
    if (print("g() "))
    {
        // Step 1: Exit states until we reach `S` state (Least Common Ancestor for transition).
        exit_up_to_state_handler(sm, S_exit);
        
        // Step 2: Transition action: `t();`.
        print("t(); ");
        
        // Step 3: Enter/move towards transition target `S2`.
        S2_enter(sm);
        
        // S2.<InitialState> behavior
        // uml: / { d(); } TransitionTo(S2_1)
        {
            // Step 1: Exit states until we reach `S2` state (Least Common Ancestor for transition). Already at LCA, no exiting required.
            
            // Step 2: Transition action: `d();`.
            print("d(); ");
            
            // Step 3: Enter/move towards transition target `S2_1`.
            S2_1_enter(sm);
            
            // Step 4: complete transition. Ends event dispatch. No other behaviors are checked.
            sm->state_id = Spec1bSm_StateId_S2_1;
            // No ancestor handles event. Can skip nulling `ancestor_event_handler`.
            return;
        } // end of behavior for S2.<InitialState>
    } // end of behavior for S1
}


////////////////////////////////////////////////////////////////////////////////
// event handlers for state S1_1
////////////////////////////////////////////////////////////////////////////////

static void S1_1_enter(Spec1bSm* sm)
{
    // setup trigger/event handlers
    sm->current_state_exit_handler = S1_1_exit;
}

static void S1_1_exit(Spec1bSm* sm)
{
    // S1_1 behavior
    // uml: exit / { a(); }
    {
        // Step 1: execute action `a();`
        print("a(); ");
    } // end of behavior for S1_1
    
    // adjust function pointers for this state's exit
    sm->current_state_exit_handler = S1_exit;
}


////////////////////////////////////////////////////////////////////////////////
// event handlers for state S2
////////////////////////////////////////////////////////////////////////////////

static void S2_enter(Spec1bSm* sm)
{
    // setup trigger/event handlers
    sm->current_state_exit_handler = S2_exit;
    
    // S2 behavior
    // uml: enter / { c(); }
    {
        // Step 1: execute action `c();`
        print("c(); ");
    } // end of behavior for S2
}

static void S2_exit(Spec1bSm* sm)
{
    // adjust function pointers for this state's exit
    sm->current_state_exit_handler = S_exit;
}


////////////////////////////////////////////////////////////////////////////////
// event handlers for state S2_1
////////////////////////////////////////////////////////////////////////////////

static void S2_1_enter(Spec1bSm* sm)
{
    // setup trigger/event handlers
    sm->current_state_exit_handler = S2_1_exit;
    
    // S2_1 behavior
    // uml: enter / { e(); }
    {
        // Step 1: execute action `e();`
        print("e(); ");
    } // end of behavior for S2_1
}

static void S2_1_exit(Spec1bSm* sm)
{
    // adjust function pointers for this state's exit
    sm->current_state_exit_handler = S2_exit;
}

// Thread safe.
char const * Spec1bSm_state_id_to_string(Spec1bSm_StateId id)
{
    switch (id)
    {
        case Spec1bSm_StateId_ROOT: return "ROOT";
        case Spec1bSm_StateId_S: return "S";
        case Spec1bSm_StateId_S1: return "S1";
        case Spec1bSm_StateId_S1_1: return "S1_1";
        case Spec1bSm_StateId_S2: return "S2";
        case Spec1bSm_StateId_S2_1: return "S2_1";
        default: return "?";
    }
}

// Thread safe.
char const * Spec1bSm_event_id_to_string(Spec1bSm_EventId id)
{
    switch (id)
    {
        case Spec1bSm_EventId_T1: return "T1";
        default: return "?";
    }
}
