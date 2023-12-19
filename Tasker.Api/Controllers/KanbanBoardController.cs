﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasker.Application.DTOs.Application.KanbanBoard;
using Tasker.Application.Interfaces.Services;

namespace Tasker.Controllers
{
    [ApiController]
    [Route("api/kanbanBoards")]
    public class KanbanBoardController : ControllerBase
    {
        private readonly IKanbanBoardService _service;

        public KanbanBoardController(IKanbanBoardService service)
        {
            _service = service;
        }

        //[Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByProject([FromRoute] string id)
        {
            var allKanbanBoards = await _service.GetAllAsync();


            return Ok(allKanbanBoards.Where(b => b.ProjectId == id));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var dto = await _service.GetByIdAsync(id);

            return dto is null
                ? NotFound()
                : Ok(dto);
        }
        
        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] KanbanBoardCreateDto dto)
        {
            var createdDto = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(Get), new { id = createdDto.Id }, createdDto);
        }
        
        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] KanbanBoardUpdateDto dto)
        {
            var updatedDto = await _service.UpdateAsync(dto);

            return Ok(updatedDto);
        }
        
        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var deleted = await _service.DeleteAsync(id);

            return deleted
                ? NoContent()
                : NotFound(new { error = $"KanbanBoard with id {id} does not exist" });
        }
    }
}