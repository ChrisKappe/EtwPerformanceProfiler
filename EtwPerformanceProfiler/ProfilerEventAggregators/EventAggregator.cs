﻿//--------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//--------------------------------------------------------------------------

using Microsoft.Diagnostics.Tracing;

namespace EtwPerformanceProfiler
{
    abstract class EventAggregator
    {
        protected static string GetUserName(TraceEvent traceEvent)
        {
            return (string)traceEvent.PayloadValue(NavEventsPayloadIndexes.UserNamePayloadIndex);
        }

        protected static int GetSessionId(TraceEvent traceEvent)
        {
            return (int)traceEvent.PayloadValue(NavEventsPayloadIndexes.SessionIdPayloadIndex);
        }

        protected static bool GetStatementIndexAndEventType(
            TraceEvent traceEvent,
            out int statementIndex,
            out string statement,
            out EventType eventType,
            out EventSubType eventSubType,
            out SqlEventType sqlEventType)
        {
            statement = null;
            sqlEventType = SqlEventType.None;

            switch ((int)traceEvent.ID)
            {
                case NavEvents.ALFunctionStart:
                    statementIndex = NavEventsPayloadIndexes.ALFunctionNamePayloadIndex;
                    eventType = EventType.StartMethod;
                    eventSubType = EventSubType.AlEvent;
                    break;
                case NavEvents.ALFunctionStop:
                    statementIndex = NavEventsPayloadIndexes.ALFunctionNamePayloadIndex;
                    eventType = EventType.StopMethod;
                    eventSubType = EventSubType.AlEvent;
                    break;
                case NavEvents.ALFunctionStatement:
                    statementIndex = NavEventsPayloadIndexes.ALStatementPayloadIndex;
                    eventType = EventType.Statement;
                    eventSubType = EventSubType.AlEvent;
                    break;
                case NavEvents.SqlExecuteScalarStart:
                    statementIndex = NavEventsPayloadIndexes.SqlStatementPayloadIndex;
                    eventType = EventType.StartMethod;
                    eventSubType = EventSubType.SqlEvent;
                    sqlEventType = SqlEventType.SqlExecuteScalar;
                    break;
                case NavEvents.SqlExecuteScalarStop:
                    statementIndex = NavEventsPayloadIndexes.SqlStatementPayloadIndex;
                    eventType = EventType.StopMethod;
                    eventSubType = EventSubType.SqlEvent;
                    sqlEventType = SqlEventType.SqlExecuteScalar;
                    break;
                case NavEvents.SqlExecuteNonQueryStart:
                    statementIndex = NavEventsPayloadIndexes.SqlStatementPayloadIndex;
                    eventType = EventType.StartMethod;
                    eventSubType = EventSubType.SqlEvent;
                    sqlEventType = SqlEventType.SqlExecuteNonQuery;
                    break;
                case NavEvents.SqlExecuteNonQueryStop:
                    statementIndex = NavEventsPayloadIndexes.SqlStatementPayloadIndex;
                    eventType = EventType.StopMethod;
                    eventSubType = EventSubType.SqlEvent;
                    sqlEventType = SqlEventType.SqlExecuteNonQuery;
                    break;
                case NavEvents.SqlExecuteReaderStart:
                    statementIndex = NavEventsPayloadIndexes.SqlStatementPayloadIndex;
                    eventType = EventType.StartMethod;
                    eventSubType = EventSubType.SqlEvent;
                    sqlEventType = SqlEventType.SqlExecuteReader;
                    break;
                case NavEvents.SqlExecuteReaderStop:
                    statementIndex = NavEventsPayloadIndexes.SqlStatementPayloadIndex;
                    eventType = EventType.StopMethod;
                    eventSubType = EventSubType.SqlEvent;
                    sqlEventType = SqlEventType.SqlExecuteReader;
                    break;
                case NavEvents.SqlReadNextResultStart:
                    statementIndex = NavEventsPayloadIndexes.SqlStatementPayloadIndex;
                    eventType = EventType.StartMethod;
                    eventSubType = EventSubType.SqlEvent;
                    sqlEventType = SqlEventType.SqlReadNextResult;
                    break;
                case NavEvents.SqlReadNextResultStop:
                    statementIndex = NavEventsPayloadIndexes.SqlStatementPayloadIndex;
                    eventType = EventType.StopMethod;
                    eventSubType = EventSubType.SqlEvent;
                    sqlEventType = SqlEventType.SqlReadNextResult;
                    break;
                case NavEvents.SqlReadNextRowStart:
                    statementIndex = NavEventsPayloadIndexes.SqlStatementPayloadIndex;
                    eventType = EventType.StartMethod;
                    eventSubType = EventSubType.SqlEvent;
                    sqlEventType = SqlEventType.SqlReadNextRow;
                    break;
                case NavEvents.SqlReadNextRowStop:
                    statementIndex = NavEventsPayloadIndexes.SqlStatementPayloadIndex;
                    eventType = EventType.StopMethod;
                    eventSubType = EventSubType.SqlEvent;
                    sqlEventType = SqlEventType.SqlReadNextRow;
                    break;
                case NavEvents.SqlCommitStart:
                    statement = "SQL COMMIT";
                    statementIndex = NavEventsPayloadIndexes.NonPayloadIndex;
                    eventType = EventType.StartMethod;
                    eventSubType = EventSubType.SqlEvent;
                    sqlEventType = SqlEventType.SqlCommit;
                    break;
                case NavEvents.SqlCommitStop:
                    statement = "SQL COMMIT";
                    statementIndex = NavEventsPayloadIndexes.NonPayloadIndex;
                    eventType = EventType.StopMethod;
                    eventSubType = EventSubType.SqlEvent;
                    sqlEventType = SqlEventType.SqlCommit;
                    break;
                case NavEvents.CreateServiceSessionStart:
                    statement = "Open Session: ";
                    statementIndex = NavEventsPayloadIndexes.ConnectionTypePayloadIndex;
                    eventType = EventType.StartMethod;
                    eventSubType = EventSubType.SystemEvent;
                    break;
                case NavEvents.CreateServiceSessionStop:
                    statement = "Open Session: ";
                    statementIndex = NavEventsPayloadIndexes.ConnectionTypePayloadIndex;
                    eventType = EventType.StopMethod;
                    eventSubType = EventSubType.SystemEvent;
                    break;
                case NavEvents.EndServiceSessionStart:
                    statement = "Close Session: ";
                    statementIndex = NavEventsPayloadIndexes.ConnectionTypePayloadIndex;
                    eventType = EventType.StartMethod;
                    eventSubType = EventSubType.SystemEvent;
                    break;
                case NavEvents.EndServiceSessionStop:
                    statement = "Close Session: ";
                    statementIndex = NavEventsPayloadIndexes.ConnectionTypePayloadIndex;
                    eventType = EventType.StopMethod;
                    eventSubType = EventSubType.SystemEvent;
                    break;
                default:
                    statementIndex = -1;
                    eventType = EventType.None;
                    eventSubType = EventSubType.None;
                    return false;
            }

            return true;
        }
    }
}
