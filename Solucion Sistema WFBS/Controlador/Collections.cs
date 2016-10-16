using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class Collections
    {
        /* Usuario */
        public List<Usuario> ReadAllUsuarios()
        {
            List<Modelo.USUARIO> usuariosBDD = CommonBC.ModeloWfbs.USUARIO.ToList();
            return GenerarListado(usuariosBDD);
        }

        private List<Controlador.Usuario> GenerarListado(List<Modelo.USUARIO> usuariosBDD)
        {
            List<Controlador.Usuario> usuariosController = new List<Usuario>();

            foreach (Modelo.USUARIO item in usuariosBDD)
            {
                Controlador.Usuario us = new Usuario();

                us.Rut = item.RUT;
                us.Nombre = item.NOMBRE;
                us.Sexo = item.SEXO;
                us.Id_Area = Convert.ToInt32(item.ID_AREA);
                us.Id_Perfil = Convert.ToInt32(item.ID_PERFIL);
                us.Jefe = item.JEFE_RESPECTIVO;

                usuariosController.Add(us);
            }

            return usuariosController;

        }

        /* Area */
        public List<Area> ReadAllAreas()
        {
            List<Modelo.AREA> areasBDD = CommonBC.ModeloWfbs.AREA.ToList();
            return GenerarListado(areasBDD);
        }

        private List<Controlador.Area> GenerarListado(List<Modelo.AREA> areasBDD)
        {
            List<Controlador.Area> areasController = new List<Area>();

            foreach (Modelo.AREA item in areasBDD)
            {
                Controlador.Area ar = new Area();

                ar.id_area = Convert.ToInt32(item.ID_AREA);
                ar.obsoleta = Convert.ToInt32(item.OBSOLETA);
                ar.abreviacion = item.ABREVIACION;
                ar.area = item.NOMBRE;

                areasController.Add(ar);
            }

            return areasController;
        }

        /* Perfil */
        public List<Perfil> ReadAllPerfiles()
        {
            List<Modelo.PERFIL> perfilesBDD = CommonBC.ModeloWfbs.PERFIL.ToList();
            return GenerarListadoPerfil(perfilesBDD);
        }

        private List<Perfil> GenerarListadoPerfil(List<PERFIL> perfilesBDD)
        {
            List<Controlador.Perfil> perfilesController = new List<Perfil>();

            foreach (Modelo.PERFIL item in perfilesBDD)
            {
                Controlador.Perfil p = new Perfil();

                p.id_pefil = Convert.ToInt32(item.ID_PERFIL);
                p.perfil = item.TIPO_USUARIO;

                perfilesController.Add(p);
            }

            return perfilesController;
        }

        /* Usuario Jefe */
        public List<Usuario> ObtenerJefes()
        {
            var Jefes = CommonBC.ModeloWfbs.USUARIO.Where(usu => usu.ID_PERFIL == 1);
            return (GenerarListado(Jefes.ToList()));
        }

        /* Competencia */
        public List<Competencia> ReadAllCompetencias()
        {
            List<Modelo.COMPETENCIA> CompetenciasBDD = CommonBC.ModeloWfbs.COMPETENCIA.ToList();
            return GenerarListadoCompetencia(CompetenciasBDD);
        }

        private List<Controlador.Competencia> GenerarListadoCompetencia(List<Modelo.COMPETENCIA> CompetenciaBDD)
        {
            List<Controlador.Competencia> competenciasController = new List<Competencia>();

            foreach (Modelo.COMPETENCIA item in CompetenciaBDD)
            {
                Controlador.Competencia com = new Competencia();

                com.Id_competencia = Convert.ToInt32(item.ID_COMPETENCIA);
                com.Nombre = item.NOMBRE;
                com.Descripcion = item.DESCRIPCION;
                com.Sigla = item.SIGLA;
                com.Obsoleta = Convert.ToInt32(item.OBSOLETA);
                com.Nivel_Optimo = Convert.ToInt32(item.NIVEL_OPTIMO_ESPERADO);

                competenciasController.Add(com);
            }

            return competenciasController;
        }

        /* Nivel */
        public List<Nivel> ReadAllNiveles()
        {
            List<Modelo.NIVEL> nivelesBDD = CommonBC.ModeloWfbs.NIVEL.ToList();
            return GenerarListado(nivelesBDD);
        }

        private List<Controlador.Nivel> GenerarListado(List<Modelo.NIVEL> nivelesBDD)
        {
            List<Controlador.Nivel> nivelesController = new List<Nivel>();

            foreach (Modelo.NIVEL item in nivelesBDD)
            {
                Controlador.Nivel nivel = new Nivel();

                nivel.nota_Encuesta = Convert.ToInt32(item.NOTA_ENCUESTA);
                nivel.Nombre = item.NOMBRE;

                nivelesController.Add(nivel);
            }

            return nivelesController;
        }

    }
}
