using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


public class BufferedSingleFileUploadDb
{
    [Required]
    public IFormFile FormFile { get; set; }
    
}