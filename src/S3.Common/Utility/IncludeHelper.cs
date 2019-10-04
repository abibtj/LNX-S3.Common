using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace S3.Common.Utility
{
    public static class IncludeHelper<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> IncludeComponents(IQueryable<TEntity> set, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            foreach (var includeExpression in includeExpressions)
            {
                set = set.Include(includeExpression);
            }

            return set;
        }
    }
}
