using UbsAPI.Models;

namespace UbsAPI.Services
{
    public class MedicoService
    {

        MedicoModel Medico1 = new()
        {
            Crm = "1",
            Nome = "Dra. Ana",
            Especialidade = "Clínica geral"
        };

        MedicoModel Medico2 = new()
        {
            Crm = "2",
            Nome = "Dr. João",
            Especialidade = "Cardiologista"
        };

        private static List<MedicoModel> _ListaMedicos = new List<MedicoModel>
        {
            new MedicoModel {Crm = "2101PE",
            Nome = "Dra. Ana",
            Telefone = "81977742345",
            Especialidade = "Clínica geral"},
            new MedicoModel {Crm = "2304PE",
            Nome = "Dr. João",
            Especialidade = "Cardiologista" }
        };
           

        //Validação se o CRM do Médico Existe
        public bool ValidarMedico (string crm)
        {
            foreach (MedicoModel medico in _ListaMedicos)
            {
                if(medico.Crm == crm)
                {
                    return true;
                }
            }

            return false;
        }

        //Cadastrar Médico
        public bool CadastrarMedico (MedicoModel novoMedico)
        {
            if (ValidarMedico(novoMedico.Crm))
            {
                return false;
            }
            _ListaMedicos.Add(novoMedico);
            return true;
        }

        //Editar Médico

        //Excluir Médico

        //Listar Médicos
        public List<MedicoModel> ListarMedicos()
        {
            return _ListaMedicos;
        }

        //Buscar Médico por CRM
        public MedicoModel BuscarMedico(string crmBuscar)
        {
            foreach (MedicoModel medico in _ListaMedicos)
            {
                if(medico.Crm == crmBuscar)
                {
                    return medico;
                }
            }
            return null;
        }


    }
}
