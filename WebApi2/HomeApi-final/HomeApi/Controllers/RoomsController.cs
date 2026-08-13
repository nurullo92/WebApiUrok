using System.Threading.Tasks;
using AutoMapper;
using HomeApi.Contracts.Models.Rooms;
using HomeApi.Data.Models;
using HomeApi.Data.Repos;
using Microsoft.AspNetCore.Mvc;
using System;


namespace HomeApi.Controllers
{
    /// <summary>
    /// Контроллер комнат
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository _repository;
        private readonly IMapper _mapper;

        public RoomsController(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //TODO: Задание - добавить метод на получение всех существующих комнат

        /// <summary>
        /// Добавление комнаты
        /// </summary>
        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] AddRoomRequest request)
        {
            var existingRoom = await _repository.GetRoomByName(request.Name);
            if (existingRoom != null)
                return Conflict(
                    $"Ошибка: Комната {request.Name} уже существует.");

            var newRoom = _mapper.Map<AddRoomRequest, Room>(request);

            await _repository.AddRoom(newRoom);

            return CreatedAtAction(nameof(Update), new { id = newRoom.Id }, newRoom);

        }

        [HttpPut("Update/{id}")]
         public async Task<IActionResult> Update(
         [FromRoute] Guid id,
         [FromBody] UpdateRoomRequest request)
        {
            var room = await _repository.GetRoomById(id);

            if (room == null)
                return NotFound($"Комната с id {id} не найдена.");

            var existingRoom = await _repository.GetRoomByName(request.Name);

            if (existingRoom != null && existingRoom.Id != id)
                return Conflict($"Ошибка: Комната {request.Name} уже существует.");

            room.Name = request.Name;
            room.Area = request.Area;
            room.Type = request.Type;

            await _repository.UpdateRoom(room);

            return Ok(room);
        }
    }
}