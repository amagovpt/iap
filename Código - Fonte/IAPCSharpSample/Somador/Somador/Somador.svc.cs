using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Somador
{
    public class Somador : ISomador
    {
        /// <summary>
        /// Efectua o pedido de soma de 2 números
        /// </summary>
        /// <param name="numero1">Primeiro Número</param>
        /// <param name="numero2">Segundo Número</param>
        /// <returns>Sucesso/Insucesso</returns>
        public bool SomadorService(int numero1, int numero2)
        {
            try
            {
                // Início - Invocação Web Service - Preenchimento do pedido a efectuar para a Soma
                IAPSomadorService.TutorialSomadorSoapClient somadorClient = new IAPSomadorService.TutorialSomadorSoapClient();
                
                // Geração de Identificador para Mensagem de Envio - Necessário Guardar para Identificar Resposta
                Guid messageId = Guid.NewGuid();

                // Adiciona cabeçaçhos para WS-Addressing
                somadorClient.Endpoint.Behaviors.Add(new WSAMessageHeaderBehavior(messageId));

                // Efectua pedido para a plataforma
                somadorClient.Somador(numero1, numero2);

                // Tudo Ok.
                return true;
            }
            catch (Exception ex)
            {
                // Indtroduzir para log, em caso de erro

                // Erro
                return false;
            }
        }
    }
}
