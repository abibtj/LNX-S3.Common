using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Newtonsoft.Json;

namespace S3.Common.Types
{
    public class GetQuery<T>
    {
        public Guid Id { get; }
        public Expression<Func<T, object>>[]? IncludeExpressions { get; }

        [JsonConstructor]
        public GetQuery(Guid id, string[]? includeArray = null)
        {
            Id = id;
            IncludeExpressions = null;

            if (!(includeArray is null) && includeArray.Length > 0)
            {
                var includeExpressions = new List<Expression<Func<T, object>>>();
                var options = ScriptOptions.Default.AddReferences(typeof(T).Assembly);

                foreach (var includeItem in includeArray)
                {
                    var expressionString = $"x => x.{includeItem}";
                    try
                    {
                        var expressionLambda = CSharpScript.EvaluateAsync<Expression<Func<T, object>>>(expressionString, options).Result;
                        includeExpressions.Add(expressionLambda);
                    }
                    catch (CompilationErrorException)
                    {
                        //TODO: Log this exception or throw a customised exception and handle it elsewhere.
                        //throw;
                    }

                }

                IncludeExpressions = includeExpressions.ToArray();
            }
        }
    }
}
