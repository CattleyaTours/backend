using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace backend.Models
{
    public class ArchivoSitioTuristico
    {
        public int Id { get; set; }

        [Required]
        public byte[] Bytes { get; set; } = Array.Empty<byte>();

        [Required]
        public string MimeType { get; set; } = string.Empty;

        [ForeignKey(nameof(Sitio))]
        [Required]
        public int SitioId { get; set; }
        [JsonIgnore]
        public SitioTuristico? Sitio { get; set; }
    }
}