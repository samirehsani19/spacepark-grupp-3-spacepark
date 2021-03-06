﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpacePort.Models;
using SpacePort.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace SpacePort.Controllers
{
    [ApiController]
    [Route("api/v1.0/parkingspots")]
    public class ParkingspotController : Controller
    {
        private readonly IParkingspotRepository _repo;

        public ParkingspotController(IParkingspotRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<Parkingspot[]>> GetAll()
        {
            try
            {
                var result = await _repo.GetAll();
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Parkinglot>> GetParkingspotById(int id)
        {
            try
            {
                var result = await _repo.GetparkingspotById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure {e.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Parkingspot>> UpdateParkingspot(Parkingspot spot)
        {
            try
            {
                var parkingspot = await _repo.GetparkingspotById(spot.ParkingspotId);
                if (parkingspot == null)
                {
                    return NotFound();
                }

                parkingspot.Occupied = spot.Occupied;
                _repo.Update(parkingspot);
                if(await _repo.Save())
                {
                    return Ok(parkingspot);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure {e.Message}");
            }
        }
    }
}