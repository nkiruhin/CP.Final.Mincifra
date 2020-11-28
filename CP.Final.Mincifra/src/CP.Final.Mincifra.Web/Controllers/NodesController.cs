using CP.Final.Mincifra.Core.Entities;
using CP.Final.Mincifra.SharedKernel.Interfaces;
using CP.Final.Mincifra.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CP.Final.Mincifra.Web.Api
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Разбиение на страницы
        /// </summary>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skipCount, int maxResultCount)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return query.Skip(skipCount).Take(maxResultCount);
        }

        /// <summary>
        /// Фильтрация по условию
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <param name="condition">Выражение</param>
        /// <param name="predicate">Предикат</param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition
                ? query.Where(predicate)
                : query;
        }
    }
    public class NodesController : BaseApiController
    {
        private readonly IRepository _repository;

        public NodesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var nodes = (await _repository.ListWithIncludeAsync<Entity>("MetaDatas")).Select(EntityDTO.FromEntity);
            var links = (await _repository.ListAsync<Link>()).Select(LinkDTO.FromLink);
            return Ok(new ResponseDTO
            {
                Nodes = nodes.ToList(),
                Links = links.ToList()
            });
        }

        [HttpGet("{searchText}")]
        public async Task<IActionResult> Filtered(string searchText)
        {
            var rs = _repository.GetQuery<Entity>().Include(x => x.MetaDatas);
            List<Guid> filteredEntity = new List<Guid>();
            foreach (var e in rs)
            {
                foreach (var m in e.MetaDatas)
                {
                    if (m.Key.ToLower().Contains(searchText.ToLower())) filteredEntity.Add(e.Id);
                }
            }
            //IQueryable<Guid> filtredEntity = rs
            //    .WhereIf(searchText != null, x => x.MetaDatas.Where(y => y.Key.ToLower().Contains(searchText.ToLower())).Count() > 0)
            //    .GroupBy(x => x.Id)
            //    .Select(x => x.Key);

            IEnumerable<EntityDTO> items = EntityDTO
                .GetDTOs(
                await _repository
                .GetQuery<Entity>()
                .Include(x => x.MetaDatas)
                .WhereIf(searchText != null, x => filteredEntity.Contains(x.Id))
                .ToListAsync());

            return Ok(items);
        }
    }
}
