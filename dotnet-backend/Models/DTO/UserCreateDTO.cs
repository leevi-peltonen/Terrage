﻿namespace TerrageApi.Models.DTO
{
    public class UserCreateDTO
    {
        public string Username { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
    }
}
