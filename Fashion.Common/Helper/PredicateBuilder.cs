using Fashion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Fashion.Common.Helper
{
	public static class PredicateBuilder
	{
		/// <summary>
		/// 返回lambda表达式
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="conditions"></param>
		/// <returns></returns>
		public static Expression<Func<T, bool>> GetWherePredicate<T>(List<Condition> conditions)
		{
			var p = Expression.Parameter(typeof(T), "p");
			var expr1 = Expression.Equal(Expression.Constant(1), Expression.Constant(1));
			foreach (var item in conditions)
			{
				if (!string.IsNullOrEmpty(item.Value))
				{
					var expr2 = Expression.Equal(Expression.Constant(1), Expression.Constant(1));
					//转换数据类型
					switch (item.DataType)
					{
						case 1://int
							expr2 = Expression.Equal(Expression.Property(p, item.Field), Expression.Constant(Convert.ToInt32(item.Value)));
							break;
						case 2://string
							expr2 = Expression.Equal(Expression.Property(p, item.Field), Expression.Constant(item.Value.ToString()));
							break;
						case 3://datetime
							expr2 = Expression.Equal(Expression.Property(p, item.Field), Expression.Constant(Convert.ToDateTime(item.Value)));
							break;
						case 4://bool
							expr2 = Expression.Equal(Expression.Property(p, item.Field), Expression.Constant(Convert.ToBoolean(item.Value)));
							break;
						default:
							expr2 = Expression.Equal(Expression.Property(p, item.Field), Expression.Constant(item.Value.ToString()));
							break;
					}
					switch (item.Option)
					{
						case 1://等于
							expr1 = Expression.And(expr1, expr2);
							break;
						case 2://不等于
							expr2 = Expression.NotEqual(Expression.Property(p, item.Field), Expression.Constant(item.Value));
							expr1 = Expression.And(expr1, expr2);
							break;
						case 3://大于
							expr2 = Expression.GreaterThan(Expression.Property(p, item.Field), Expression.Constant(item.Value));
							expr1 = Expression.And(expr1, expr2);
							break;
						case 4://大于等于
							expr2 = Expression.GreaterThanOrEqual(Expression.Property(p, item.Field), Expression.Constant(item.Value));
							expr1 = Expression.And(expr1, expr2);
							break;
						case 5://小于
							expr2 = Expression.LessThan(Expression.Property(p, item.Field), Expression.Constant(item.Value));
							expr1 = Expression.And(expr1, expr2);
							break;
						case 6://小于等于
							expr2 = Expression.LessThanOrEqual(Expression.Property(p, item.Field), Expression.Constant(item.Value));
							expr1 = Expression.And(expr1, expr2);
							break;
						case 7://like
							expr2 = Expression.Equal(Expression.Call(Expression.Property(p, item.Field), typeof(String).GetMethod("Contains"), new Expression[] { Expression.Constant(item.Value) }), Expression.Constant(true));
							expr1 = Expression.And(expr1, expr2);
							break;
					}

				}
			}
			var expr3 = Expression.Lambda<Func<T, bool>>(expr1, p);
			return expr3;
		}

		/// <summary>
		/// 返回值为true的表达式
		/// </summary>
		public static Expression<Func<T, bool>> True<T>() { return param => true; }

		/// <summary>
		/// 返回值为false的表达式
		/// </summary>
		public static Expression<Func<T, bool>> False<T>() { return param => false; }

		/// <summary>
		/// 指定表达式树的表达式
		/// </summary>
		public static Expression<Func<T, bool>> Create<T>(Expression<Func<T, bool>> predicate) { return predicate; }

		/// <summary>
		/// And连接的表达式
		/// </summary>
		public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
		{
			if (first == null)
			{
				return Create(second);
			}
			return first.Compose(second, Expression.AndAlso);
		}

		/// <summary>
		/// Or连接的表达式
		/// </summary>
		public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
		{
			if (first == null)
			{
				return Create(second);
			}
			return first.Compose(second, Expression.OrElse);
		}

		/// <summary>
		/// Not连接的表达式
		/// </summary>
		public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
		{
			var negated = Expression.Not(expression.Body);
			return Expression.Lambda<Func<T, bool>>(negated, expression.Parameters);
		}

		/// <summary>
		/// 使用指定的表达式函数合并两个表达式
		/// </summary>
		static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
		{
			var map = first.Parameters
				.Select((f, i) => new { f, s = second.Parameters[i] })
				.ToDictionary(p => p.s, p => p.f);

			var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

			return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
		}

		class ParameterRebinder : ExpressionVisitor
		{
			readonly Dictionary<ParameterExpression, ParameterExpression> map;

			ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
			{
				this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
			}

			public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
			{
				return new ParameterRebinder(map).Visit(exp);
			}

			protected override Expression VisitParameter(ParameterExpression p)
			{
				ParameterExpression replacement;

				if (map.TryGetValue(p, out replacement))
				{
					p = replacement;
				}

				return base.VisitParameter(p);
			}
		}
	}
}
