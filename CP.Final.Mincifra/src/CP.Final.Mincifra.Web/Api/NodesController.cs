using CP.Final.Mincifra.Core.Entities;
using CP.Final.Mincifra.Infrastructure.Extensions;
using CP.Final.Mincifra.SharedKernel.Interfaces;
using CP.Final.Mincifra.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP.Final.Mincifra.Web.Api
{

    public class NodesController : BaseApiController
    {
        private readonly IRepository _repository;

        public NodesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> List()
        {
            var nodes = (await _repository.ListWithIncludeAsync<Entity>("MetaDatas")).Select(EntityDTO.FromEntity);
            var links = (await _repository.ListAsync<Link>()).Select(LinkDTO.FromLink);
            return Ok(new ResponseDTO(links.ToList(), nodes.ToList()));
        }

        [HttpGet("{searchText}")]
        public async Task<ActionResult<ResponseDTO>> Filtered(string searchText)
        {
            var query = _repository.GetQuery<Entity>().Include(x => x.MetaDatas);
            var filteredEntity = new List<Guid>();
            foreach (var e in query)
            {
                foreach (var m in e.MetaDatas)
                {
                    if (m.Key.ToLower().Contains(searchText.ToLower())) filteredEntity.Add(e.Id);
                }
            }
            var items = EntityDTO
                .GetDTOs(
                await _repository
                .GetQuery<Entity>()
                .Include(x => x.MetaDatas)
                .WhereIf(searchText != null, x => filteredEntity.Contains(x.Id))
                .ToListAsync());

            return Ok(new ResponseDTO(new List<LinkDTO>(), items));
        }
    }
}
