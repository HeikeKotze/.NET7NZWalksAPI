using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    //Example of where the info will be available in API
    //https://localhost:portnumber/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        //---------------------------------DB--------------------------------------

        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        //inject DBCONTEXT here
        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
           this.dbContext = dbContext;
           this.regionRepository = regionRepository;
           this.mapper = mapper;
        }

        //---------------------------------CRUD------------------------------------

        //GET ALL REGIONS
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Create domain models from database, then map the domain models to the dto's to add security, separation of concerns etc
            //Client--> DTO --> API --> Domain Models --> Datbase
            //Return type for async is a Task

            //Get data from database - domain models
            //Controller calls the repository, repository calls the database
            var regionsDomain = await regionRepository.GetAllAsync();

            //map domain models to dtos
            var regionsDto = mapper.Map<List<Region>>(regionsDomain);

            //return dtos back to the client
            return Ok(regionsDto);
        }

        //GET SINGLE REGION (Get by Id)
        //GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            //varregion = dbContext.Regions.Find(id);
            //Get Region domain model from database
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //Map or convert the region domain model to region Dto
            var regionDto = mapper.Map<RegionDto>(regionDomain);
            //return dto back to client
            return Ok(regionDto);
        }

        //POST (Create) create new Region
        //POST: https://localhost:portnumber/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or Convert dto to domain model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            //Use domain model to create region with dbcontext
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            //Map domain model back to dto
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);
            
            //NB returns a 201 because it just has to confirm that the entity was created
            return CreatedAtAction(nameof(GetById), new {id = regionDto.Id}, regionDto);
        }

        // UPDATE REGION
        // PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //map dto to domain model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

            //Check if region exists
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //convert domain model to dto
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }

        // DELETE REGION
        // DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //return deleted region back ?
            //Map domain model to dto first
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);    

            //can also send empty ok response back
            return Ok(regionDto);
        }
    }
}
