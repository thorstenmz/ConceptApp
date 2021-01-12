using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TG.ConceptApp.Application.ConsoleApp.Interfaces;
using TG.ConceptApp.Application.ConsoleApp.Services.Helpers;
using TG.ConceptApp.Application.QueryModel.Entities;
using TG.ConceptApp.Application.QueryModel.Interfaces;

namespace TG.ConceptApp.Application.ConsoleApp.Services
{
    public class ReadService : ICrudService
    {
        private readonly IQueryService _queryService;

        public ReadService(IQueryService queryService) =>
            _queryService = queryService;

        public async Task<IProcessResult> ProcessAsync(string[] input)
        {
            for (int i = 1; i < input.Length - 1; i++)
            {
                if (input[i] == "-i" || input[i] == "--id")
                {
                    ReadonlyConcept result =
                        await _queryService.GetConceptById(int.Parse(input[i + 1]));

                    return result == null
                        ? ProcessResult.Error($"? No item with Id {input[i + 1]} found.")
                        : ProcessResult.Result(result.ToString());
                }

                if (input[i] == "-p" || input[i] == "--super")
                {
                    IEnumerable<ReadonlyConcept> result =
                        await _queryService.GetConceptsBySuper(input[i + 1]);

                    return ProcessResult.Result(result.ToOutputString());
                }
            }

            IEnumerable<ReadonlyConcept> all =
                await _queryService.GetAllConcepts();

            return ProcessResult.Result(all.ToOutputString());
        }
    }

    public static class Extensions
    {
        [DebuggerStepThrough]
        public static string ToOutputString<T>(this IEnumerable<T> items) =>
            string.Join(Environment.NewLine, items.Select(c => c.ToString()));
    }
}
