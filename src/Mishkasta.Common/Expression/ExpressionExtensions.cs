using System;
using System.Linq.Expressions;
using LinqExpression = System.Linq.Expressions.Expression;

namespace Mishkasta.Common.Expression
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> And<T>(
            this Expression<Func<T, bool>> self,
            Expression<Func<T, bool>> other)
        {
            return GetExpression(self, other, Operation.And);
        }

        public static Expression<Func<T, bool>> Or<T>(
            this Expression<Func<T, bool>> self,
            Expression<Func<T, bool>> other)
        {
            return GetExpression(self, other, Operation.Or);
        }

        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> self)
        {
            var parameter = LinqExpression.Parameter(typeof(T));
            var expression = GetExpression(self, parameter);

            return LinqExpression.Lambda<Func<T, bool>>(LinqExpression.Not(expression), parameter);
        }


        private static Expression<Func<T, bool>> GetExpression<T>(this Expression<Func<T, bool>> one, Expression<Func<T, bool>> other, Operation operation)
        {
            var parameter = LinqExpression.Parameter(typeof(T));
            var left = GetExpression(one, parameter);
            var right = GetExpression(other, parameter);

            return operation switch
            {
                Operation.And => LinqExpression.Lambda<Func<T, bool>>(LinqExpression.AndAlso(left, right), parameter),
                Operation.Or => LinqExpression.Lambda<Func<T, bool>>(LinqExpression.OrElse(left, right), parameter),
                _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, "Unknown operation")
            };
        }

        private static LinqExpression GetExpression<T>(Expression<Func<T, bool>> expression, LinqExpression parameter)
        {
            var visitor = new ReplaceExpressionVisitor(expression.Parameters[0], parameter);
            var visitedExpression = visitor.Visit(expression.Body);

            return visitedExpression;
        }



        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly LinqExpression _oldValue;
            private readonly LinqExpression _newValue;

            public ReplaceExpressionVisitor(LinqExpression oldValue, LinqExpression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override LinqExpression Visit(LinqExpression node)
            {
                return node == _oldValue ? _newValue : base.Visit(node);
            }
        }

        private enum Operation
        {
            And,
            Or
        }
    }
}