using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Tag;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class TagController : MatLidStoreBaseController
{
    private readonly IMapper _mapper;
    private readonly ITagRepository _tagRepository;

    public TagController(ITagRepository tagRepository, IMapper mapper)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
    }

    // GET: api/<TagController>
    [HttpGet]
    public async Task<IReadOnlyList<TagDto>> GetAllTags()
    {
        var tags = await _tagRepository.GetAllAsync();
        var data = _mapper.Map<List<TagDto>>(tags);
        return data;
    }

    // GET api/<TagController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TagDetailsDto>> GetTag(int id)
    {
        var tag = await _tagRepository.GetByIdAsync(id);

        if (tag is null || tag.IsDeleted)
            throw new NotFoundException(nameof(Tag), id);

        var data = _mapper.Map<TagDetailsDto>(tag);
        return Ok(data);
    }

    // POST api/<TagController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateTag([FromBody] CreateTagDto tag)
    {
        var tagToCreate = _mapper.Map<Tag>(tag);
        await _tagRepository.CreateAsync(tagToCreate);
        return CreatedAtAction(nameof(CreateTag), tagToCreate.Id);
    }

    // PUT api/<TagController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateTag([FromBody] UpdateTagDto tag)
    {
        var tagToUpdate = _mapper.Map<Tag>(tag);
        await _tagRepository.UpdateAsync(tagToUpdate);
        return NoContent();
    }

    // DELETE api/<TagController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteTag(int id)
    {
        var tagToDelete = await _tagRepository.GetByIdAsync(id);

        if (tagToDelete is null || tagToDelete.IsDeleted)
            throw new NotFoundException(nameof(Tag), id);

        await _tagRepository.DeleteAsync(tagToDelete);
        return NoContent();
    }
}