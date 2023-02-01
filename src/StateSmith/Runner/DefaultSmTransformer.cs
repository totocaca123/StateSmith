﻿using StateSmith.Compiling;
using StateSmith.output.C99BalancedCoder1;
using System;

namespace StateSmith.Runner;

public class DefaultSmTransformer : SmTransformer
{
    public enum Id
    {
        RemoveNotesVertices,
        SupportParentAlias,
        SupportEntryExit,
        SupportPrefixingModder,
        SupportHistory,
        SupportOrderAndElse,
        Valdation1,
        DefaultUnspecifiedEventsAsDoEvent,
        AddUsedEventsToSm,
        FinalValdation,
    };

    public DefaultSmTransformer(CNameMangler mangler)
    {
        AddStep(Id.RemoveNotesVertices, (sm) => NotesProcessor.Process(sm));
        AddStep(Id.SupportParentAlias, (sm) => ParentAliasStateProcessor.Process(sm));
        AddStep(Id.SupportEntryExit, (sm) => EntryExitProcessor.Process(sm));
        AddStep(Id.SupportPrefixingModder, (sm) => PrefixingModder.Process(sm));
        AddStep(Id.SupportHistory, (sm) => HistoryProcessor.Process(sm, mangler));
        AddStep(Id.SupportOrderAndElse, (sm) => OrderAndElseProcessor.Process(sm)); // should happen after most steps as it orders behaviors
        AddStep(Id.Valdation1, (sm) => Validate(sm));
        AddStep(Id.DefaultUnspecifiedEventsAsDoEvent, (sm) => DefaultToDoEventVisitor.Process(sm));
        AddStep(Id.AddUsedEventsToSm, (sm) => AddUsedEventsToSmClass.Process(sm));
        AddStep(Id.FinalValdation, (sm) => Validate(sm));
    }

    private void AddStep(Id id, Action<Statemachine> action)
    {
        transformationPipeline.Add(new($"{nameof(DefaultSmTransformer)}.{id}", action));
    }

    public static void Validate(Statemachine sm)
    {
        var validator = new SpecificVertexValidator();
        sm.Accept(validator);
        var validator2 = new VertexValidator();
        sm.Accept(validator2);
    }
}
