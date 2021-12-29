using System;
using System.Collections.Generic;
using PROJETO2.Interfaces;

namespace PROJETO2
{
    
    public class SerieRepositorio : IRepositorio<Serie>
    {
        //Declarando a Lista que irá armazenar a Série
        private List<Serie> listaserie = new List<Serie>();

        //Implementando os Métodos da Interface:
        
        public void Atualiza(int id, Serie Entidade)
        {
            listaserie[id] = Entidade;
        }

        public void Exclui(int id)
        {
            listaserie[id].Excluir();
        }

        public void Insere(Serie Entidade)
        {
            listaserie.Add(Entidade);
        }

        public List<Serie> Lista()
        {
           return listaserie;
        }

        public int ProximoId()
        {
            return listaserie.Count; 
        }

        public Serie RetornaPorId(int Id)
        {
            return listaserie[Id];
        }

        public string RetornaTituloPorId(int Id)
        {
            return listaserie[Id].retornaTitulo();
        }
    }
}