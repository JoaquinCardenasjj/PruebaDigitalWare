using PruebaDigitalWare.DAL.Clientes;
using PruebaDigitalWare.DTO;
using PruebaDigitalWare.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.BL.Clientes
{
    public class ClienteBl : IGeneralMethodsBl<ClienteDto>
    {
        public IGeneralMethodsDal<ClienteDto> clienteI;
        public ClienteBl(IGeneralMethodsDal<ClienteDto> _ICliente)
        {
            clienteI = _ICliente;
        }
        public ResponseRegisterResult<ClienteDto> Consultar(ClienteDto input)
        {
            ResponseRegisterResult<ClienteDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.clienteI.Consultar(input);
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }

        public ResponseRegister<ClienteDto> Crear(ClienteDto input)
        {
            ResponseRegister<ClienteDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.clienteI.Crear(input);
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }

        public ResponseRegister<ClienteDto> Detalle(ClienteDto input)
        {
            ResponseRegister<ClienteDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.clienteI.Detalle(input);
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }

        public ResponseRegister<ClienteDto> Editar(ClienteDto input)
        {
            ResponseRegister<ClienteDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.clienteI.Editar(input);
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }
        
    }
}
