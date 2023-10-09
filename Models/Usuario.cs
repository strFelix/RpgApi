using System.ComponentModel.DataAnnotations.Schema;


namespace RpgApi.Models
{
    public class Usuario
    {        
        public int Id { get; set; } //Atalho para propridade (PROP + TAB)
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } 
        public byte[] PasswordSalt { get; set; } 
        public byte[]? Foto { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? DataAcesso { get; set; } //using System;

        [NotMapped] // using System.ComponentModel.DataAnnotations.Schema
        public string PasswordString { get; set; } = string.Empty;
        public List<Personagem> Personagens { get; set; }//using System.Collections.Generic;
        public string Perfil { get; set; }  = string.Empty;
        public string Email { get; set; } = string.Empty;



    }
}