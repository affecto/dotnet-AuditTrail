using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Affecto.AuditTrail.Store.Model;
using PredicateExtensions;

namespace Affecto.AuditTrail.Store.EntityFramework.Queries
{
    internal class AuditTrailEntriesByFilterQuery
    {
        private readonly IQueryable<AuditTrailEntry> auditTrailEntries;

        public AuditTrailEntriesByFilterQuery(IQueryable<AuditTrailEntry> auditTrailEntries)
        {
            if (auditTrailEntries == null)
            {
                throw new ArgumentNullException("auditTrailEntries");
            }
            this.auditTrailEntries = auditTrailEntries;
        }

        public IQueryable<AuditTrailEntry> Execute(AuditTrailFilter filter)
        {
            var resultEntries = auditTrailEntries;

            #region filtering
            resultEntries = resultEntries.Where(
                MakeTimestampFilterExpression(filter.TimestampFilterLogic, filter.TimestampFilterParameters)
                .And(MakeSummaryFilterExpression(filter.SummaryFilterLogic, filter.SummaryFilterParameters))
                .And(MakeSubjectNameFilterExpression(filter.SubjectNameFilterLogic, filter.SubjectNameFilterParameters))
                .And(MakeUserNameFilterExpression(filter.UserNameFilterLogic, filter.UserNameFilterParameters))
                );
            #endregion

            #region ordering
            foreach (AuditTrailSortParameter sortParam in filter.SortParameters)
            {
                switch (sortParam.SortField)
                {
                    case AuditTrailSortField.TIMESTAMP:
                        if (sortParam.SortDirection == AuditTrailSortDirection.ASC)
                        {
                            resultEntries = resultEntries.OrderBy(e => e.Timestamp);
                        }
                        else
                        {
                            resultEntries = resultEntries.OrderByDescending(e => e.Timestamp);
                        }
                        break;
                    case AuditTrailSortField.SUMMARY:
                        if (sortParam.SortDirection == AuditTrailSortDirection.ASC)
                        {
                            resultEntries = resultEntries.OrderBy(e => e.Summary);
                        }
                        else
                        {
                            resultEntries = resultEntries.OrderByDescending(e => e.Summary);
                        }
                        break;
                    case AuditTrailSortField.SUBJECTNAME:
                        if (sortParam.SortDirection == AuditTrailSortDirection.ASC)
                        {
                            resultEntries = resultEntries.OrderBy(e => e.SubjectName);
                        }
                        else
                        {
                            resultEntries = resultEntries.OrderByDescending(e => e.SubjectName);
                        }
                        break;
                    case AuditTrailSortField.USERNAME:
                        if (sortParam.SortDirection == AuditTrailSortDirection.ASC)
                        {
                            resultEntries = resultEntries.OrderBy(e => e.UserName);
                        }
                        else
                        {
                            resultEntries = resultEntries.OrderByDescending(e => e.UserName);
                        }
                        break;
                }
            }
            #endregion


            return resultEntries;
        }


        #region timestamp
        private Expression<Func<AuditTrailEntry, bool>> MakeTimestampFilterExpression(AuditTrailFilterLogic filterLogic, List<AuditTrailDateFilterParameter> filterParameters)
        {

            Expression<Func<AuditTrailEntry, bool>> dateFilter = PredicateExtensions.PredicateExtensions.Begin<AuditTrailEntry>(true);

            if (filterParameters.Count > 0)
            {
                if (filterLogic == AuditTrailFilterLogic.AND)
                {
                    foreach (AuditTrailDateFilterParameter param in filterParameters)
                    {
                        dateFilter = dateFilter.And(MakeTimestampFilterParameterExpression(param));
                    }
                }

                if (filterLogic == AuditTrailFilterLogic.OR)
                {
                    dateFilter = PredicateExtensions.PredicateExtensions.Begin<AuditTrailEntry>(false);
                    foreach (AuditTrailDateFilterParameter param in filterParameters)
                    {
                        dateFilter = dateFilter.Or(MakeTimestampFilterParameterExpression(param));
                    }
                }

            }

            return dateFilter;
        }

        private Expression<Func<AuditTrailEntry, bool>> MakeTimestampFilterParameterExpression(AuditTrailDateFilterParameter param)
        {
            var filterValue = param.FilterValue.ToLocalTime();

            DateTime filterDayStart = new DateTime(filterValue.Year, filterValue.Month, filterValue.Day, 0, 0, 0, 0);
            DateTime filterDayEnd = new DateTime(filterValue.Year, filterValue.Month, filterValue.Day, 23, 59, 59, 999);

            switch (param.FilterOperator)
            {
                case AuditTrailDateFilterOperator.EQ:
                    return e => e.Timestamp >= filterDayStart && e.Timestamp <= filterDayEnd;
                case AuditTrailDateFilterOperator.GT:
                    return e => e.Timestamp > filterDayEnd;
                case AuditTrailDateFilterOperator.GTE:
                    return e => e.Timestamp >= filterDayStart;
                case AuditTrailDateFilterOperator.LT:
                    return e => e.Timestamp < filterDayStart;
                case AuditTrailDateFilterOperator.LTE:
                    return e => e.Timestamp <= filterDayEnd;
                case AuditTrailDateFilterOperator.NEQ:
                    return e => !(e.Timestamp >= filterDayStart && e.Timestamp <= filterDayEnd);
                default:
                    return e => false;
            }
        }
        #endregion

        #region summary
        private Expression<Func<AuditTrailEntry, bool>> MakeSummaryFilterExpression(AuditTrailFilterLogic filterLogic, List<AuditTrailTextFilterParameter> filterParameters)
        {

            Expression<Func<AuditTrailEntry, bool>> textFilter = PredicateExtensions.PredicateExtensions.Begin<AuditTrailEntry>(true);

            if (filterParameters.Count > 0)
            {
                if (filterLogic == AuditTrailFilterLogic.AND)
                {
                    foreach (AuditTrailTextFilterParameter param in filterParameters)
                    {
                        textFilter = textFilter.And(MakeSummaryFilterParameterExpression(param));
                    }
                }

                if (filterLogic == AuditTrailFilterLogic.OR)
                {
                    textFilter = PredicateExtensions.PredicateExtensions.Begin<AuditTrailEntry>(false);
                    foreach (AuditTrailTextFilterParameter param in filterParameters)
                    {
                        textFilter = textFilter.Or(MakeSummaryFilterParameterExpression(param));
                    }
                }

            }

            return textFilter;
        }

        private Expression<Func<AuditTrailEntry, bool>> MakeSummaryFilterParameterExpression(AuditTrailTextFilterParameter param)
        {
            var filterValue = param.FilterValue;

            switch (param.FilterOperator)
            {
                case AuditTrailTextFilterOperator.CONTAINS:
                    return e => e.Summary.Contains(filterValue);
                case AuditTrailTextFilterOperator.DOESNOTCONTAIN:
                    return e => !e.Summary.Contains(filterValue);
                case AuditTrailTextFilterOperator.ENDSWITH:
                    return e => e.Summary.EndsWith(filterValue);
                case AuditTrailTextFilterOperator.EQ:
                    return e => e.Summary.Equals(filterValue);
                case AuditTrailTextFilterOperator.NEQ:
                    return e => !e.Summary.Equals(filterValue);
                case AuditTrailTextFilterOperator.STARTSWITH:
                    return e => e.Summary.StartsWith(filterValue);
                default:
                    return e => false;
            }
        }
        #endregion

        #region subjectName
        private Expression<Func<AuditTrailEntry, bool>> MakeSubjectNameFilterExpression(AuditTrailFilterLogic filterLogic, List<AuditTrailTextFilterParameter> filterParameters)
        {

            Expression<Func<AuditTrailEntry, bool>> textFilter = PredicateExtensions.PredicateExtensions.Begin<AuditTrailEntry>(true);

            if (filterParameters.Count > 0)
            {
                if (filterLogic == AuditTrailFilterLogic.AND)
                {
                    foreach (AuditTrailTextFilterParameter param in filterParameters)
                    {
                        textFilter = textFilter.And(MakeSubjectNameFilterParameterExpression(param));
                    }
                }

                if (filterLogic == AuditTrailFilterLogic.OR)
                {
                    textFilter = PredicateExtensions.PredicateExtensions.Begin<AuditTrailEntry>(false);
                    foreach (AuditTrailTextFilterParameter param in filterParameters)
                    {
                        textFilter = textFilter.Or(MakeSubjectNameFilterParameterExpression(param));
                    }
                }

            }

            return textFilter;
        }

        private Expression<Func<AuditTrailEntry, bool>> MakeSubjectNameFilterParameterExpression(AuditTrailTextFilterParameter param)
        {
            var filterValue = param.FilterValue;

            switch (param.FilterOperator)
            {
                case AuditTrailTextFilterOperator.CONTAINS:
                    return e => e.SubjectName.Contains(filterValue);
                case AuditTrailTextFilterOperator.DOESNOTCONTAIN:
                    return e => !e.SubjectName.Contains(filterValue);
                case AuditTrailTextFilterOperator.ENDSWITH:
                    return e => e.SubjectName.EndsWith(filterValue);
                case AuditTrailTextFilterOperator.EQ:
                    return e => e.SubjectName.Equals(filterValue);
                case AuditTrailTextFilterOperator.NEQ:
                    return e => !e.SubjectName.Equals(filterValue);
                case AuditTrailTextFilterOperator.STARTSWITH:
                    return e => e.SubjectName.StartsWith(filterValue);
                default:
                    return e => false;
            }
        }
        #endregion

        #region subjectName
        private Expression<Func<AuditTrailEntry, bool>> MakeUserNameFilterExpression(AuditTrailFilterLogic filterLogic, List<AuditTrailTextFilterParameter> filterParameters)
        {

            Expression<Func<AuditTrailEntry, bool>> textFilter = PredicateExtensions.PredicateExtensions.Begin<AuditTrailEntry>(true);

            if (filterParameters.Count > 0)
            {
                if (filterLogic == AuditTrailFilterLogic.AND)
                {
                    foreach (AuditTrailTextFilterParameter param in filterParameters)
                    {
                        textFilter = textFilter.And(MakeUserNameFilterParameterExpression(param));
                    }
                }

                if (filterLogic == AuditTrailFilterLogic.OR)
                {
                    textFilter = PredicateExtensions.PredicateExtensions.Begin<AuditTrailEntry>(false);
                    foreach (AuditTrailTextFilterParameter param in filterParameters)
                    {
                        textFilter = textFilter.Or(MakeUserNameFilterParameterExpression(param));
                    }
                }

            }

            return textFilter;
        }

        private Expression<Func<AuditTrailEntry, bool>> MakeUserNameFilterParameterExpression(AuditTrailTextFilterParameter param)
        {
            var filterValue = param.FilterValue;

            switch (param.FilterOperator)
            {
                case AuditTrailTextFilterOperator.CONTAINS:
                    return e => e.UserName.Contains(filterValue);
                case AuditTrailTextFilterOperator.DOESNOTCONTAIN:
                    return e => !e.UserName.Contains(filterValue);
                case AuditTrailTextFilterOperator.ENDSWITH:
                    return e => e.UserName.EndsWith(filterValue);
                case AuditTrailTextFilterOperator.EQ:
                    return e => e.UserName.Equals(filterValue);
                case AuditTrailTextFilterOperator.NEQ:
                    return e => !e.UserName.Equals(filterValue);
                case AuditTrailTextFilterOperator.STARTSWITH:
                    return e => e.UserName.StartsWith(filterValue);
                default:
                    return e => false;
            }
        }
        #endregion


    }
}
