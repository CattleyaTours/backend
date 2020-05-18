using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Archivo_SitioTuristicoController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public Archivo_SitioTuristicoController(CattleyaToursContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BufferedSingleFileUploadDb FileUpload { get; set; }


        // GET: api/Archivos_SitioTuristico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Archivo_SitioTuristico>>> GetArchivos_SitioTuristico()
        {
            return await _context.Archivos_SitioTuristico.ToListAsync();
        }


        // GET: api/Archivos_SitioTuristico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Archivo_SitioTuristico>> GetArchivo_SitioTuristico(int id)
        {
            var archivo_SitioTuristico = await _context.Archivos_SitioTuristico.FindAsync(id);

            if (archivo_SitioTuristico == null)
            {
                return NotFound();
            }

            ///////aca tenia que hacer algo lol
            //creo que era formatear bien los archivos

            return archivo_SitioTuristico;
        }

        
        // PUT: api/Archivos_SitioTuristico/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchivo_SitioTuristico(int id, Archivo_SitioTuristico archivo_SitioTuristico)
        {
            if (id != archivo_SitioTuristico.Id)
            {
                return BadRequest();
            }

            _context.Entry(archivo_SitioTuristico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Archivo_SitioTuristicoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Archivo_SitioTuristico
        [HttpPost]
        public async Task<ActionResult<Archivo_SitioTuristico>> PostArchivo_SitioTuristico([FromForm(Name = "files")] BufferedSingleFileUploadDb files)
                                                //TENER EN CUENTA QUE LO QUE TRAIGA DEL BODY DEL REQUEST EN EL FRONT SE LLAME files
        {
            
                using (var uploadedFile = new MemoryStream()){
                    
                    // Extract file name from whatever was posted by browser
                        //traer nombre de base de datos para verificar que el archivo existe o no
                        //verificar si el nombre pertenece al archivo turistico,
                    //var fileName = System.IO.Path.GetFileName(file.FileName);
                    /*
                    // Don't trust the file name sent by the client. To display
                    // the file name, HTML-encode the value.
                    var trustedFileNameForDisplay = WebUtility.HtmlEncode(
                        FormFile.FileName); //Aca faltaria declarar el nombre en el modelo
                    */
                    //if (files.Length < 2097152){

                        await FileUpload.FormFile.CopyToAsync(uploadedFile);
                        var archivo = new Archivo_SitioTuristico()
                        {
                            info_file = uploadedFile.ToArray()
                        };
                
                        //Adds file to DB
                        _context.Archivos_SitioTuristico.Add(archivo);

                    //}else{
                        //aca ponddria lo del log pero no se puede :(
                        //return BadRequest();
                    //}
                }     
            
            await _context.SaveChangesAsync();
            return Ok();
        }


        // DELETE: api/Archivo_SitioTuristico/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Archivo_SitioTuristico>> DeleteArchivo_SitioTuristico(int id)
        {
            var archivo_SitioTuristico = await _context.Archivos_SitioTuristico.FindAsync(id);
            if (archivo_SitioTuristico == null)
            {
                return NotFound();
            }

            _context.Archivos_SitioTuristico.Remove(archivo_SitioTuristico);
            await _context.SaveChangesAsync();

            return archivo_SitioTuristico;
        }

        private bool Archivo_SitioTuristicoExists(int id)
        {
            return _context.Archivos_SitioTuristico.Any(e => e.Id == id);
        }
    }
}