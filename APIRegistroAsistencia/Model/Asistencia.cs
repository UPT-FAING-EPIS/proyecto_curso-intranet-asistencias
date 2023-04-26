namespace APIRegistroAsistencia.Model
{
    public class Asistencia
    {
        public DateTime fecha { get; set; }
        public int idAlumno { get; set; }
        public string nombreAlumno { get; set; }
        
        public int idCurso { get; set; }
        public string nombreCurso { get; set; }

        public bool asistio { get; set; }
    }
}
