﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Notificacoes
{
    public class Notifica
    {
        public Notifica()
        {
            notificacoes = new List<Notifica>();
        }
        [NotMapped]
        public string NomePropriedade { get; set; }
        [NotMapped]
        public string mensagem { get; set; }
        [NotMapped]
        public List<Notifica> notificacoes;

        public bool ValidaPropriedadeString(string valor,string nomePropriedade)
        {
            if(string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                notificacoes.Add(new()
                {
                    mensagem = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade

                });
                return false;
            }
            return true;
        }
        public bool ValidarPropriedadeInt(int valor,string nomePropriedade)
        {
            if(valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                notificacoes.Add(new()
                {
                    mensagem = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }
    }
}
