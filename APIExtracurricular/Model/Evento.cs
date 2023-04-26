namespace APIExtracurricular.Model
{
    public class Evento
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreAlumno { get; set; }
        public int CodAlumno { get; set;}
        public bool Asistio { get; set; }
    }
}
